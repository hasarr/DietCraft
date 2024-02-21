using AutoMapper;
using DietCraft.API.Services.DietService;
using DietCraft.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DietCraft.API.Services.MealService;
using DietCraft.API.Models.Diet;
using DietCraft.API.Models.Meal;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using DietCraft.API.Entities;
using DietCraft.API.Services.IngredientService;

namespace DietCraft.API.Controllers
{
    [Route("api/meals")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IMapper _mapper;
        private IMealRepository _mealRepository;
        private IIngredientRepository _ingredientRepository;
        private readonly DbSaveService _dbSaveService;
        const int MaxPageSize = 5;

        public MealController(IMapper mapper, IMealRepository mealRepository, DbSaveService dbSaveService, IIngredientRepository ingredientRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mealRepository = mealRepository ?? throw new ArgumentNullException(nameof(mealRepository));
            _ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
            _dbSaveService = dbSaveService ?? throw new ArgumentNullException(nameof(dbSaveService));
        }

        #region MealEndpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealDto>>> GetMeals([Required] int pageNumber = 1,[Required] int pageSize = 5)
        {
            pageSize = pageSize > MaxPageSize ? 5 : pageSize;
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            var (meals, paginationMetaData) = await _mealRepository.GetMealsAsync(pageNumber, pageSize);
            if (meals == null)
                return NotFound("No meals found in the database");

            Response.Headers.Append("X-Pagination",
                JsonConvert.SerializeObject(paginationMetaData));

            return Ok(_mapper.Map<IEnumerable<MealDto>>(meals));
        }

        [HttpGet("{mealId}")]
        public async Task<ActionResult<MealDto>> GetDiet([Required] int mealId)
        {
            var meal = await _mealRepository.GetMealByIdAsync(mealId);
            if (meal == null)
                return NotFound($"Meal with given id of {mealId} was not found");
            else return Ok(_mapper.Map<MealDto>(meal));
        }

        [HttpPost]
        public async Task<ActionResult<MealDto>> AddMeal( [Required] MealForCreationDto meal)
        {

            if(meal.IsCustom == true && meal.UserIdIfCustom <= 0)
                return BadRequest("You need to provide valid UserId for custom meal");

            if(meal.IsCustom == false && meal.UserIdIfCustom > 0)
                return BadRequest("Can't provide UserId for non-custom meal");

            var mealToReturn = _mapper.Map<Meal>(meal);

            _mealRepository.AddMeal(mealToReturn);
            await _dbSaveService.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{mealId}")]
        public async Task<ActionResult> UpdateDiet([Required] int mealId, [Required] MealForUpdateDto meal)
        {
            if (!await _mealRepository.MealExistsAsync(mealId))
            {
                return NotFound($"Meal with id of {mealId} does not exist");
            }

            var mealEntity = await _mealRepository
                .GetMealByIdAsync(mealId);

            if (mealEntity == null)
            {
                return NotFound();
            }

            //mapper forces modification of input data to source data in database
            _mapper.Map(meal, mealEntity);
            await _dbSaveService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{mealId}")]
        public async Task<ActionResult> DeleteDiet([Required] int mealId)
        {
            bool mealExists = await _mealRepository.MealExistsAsync(mealId);
            if(!mealExists)
                return BadRequest($"Meal with id of {mealId} does not exist");

            var meal = await _mealRepository.GetMealByIdAsync(mealId);
            if (meal != null)
            {
                _mealRepository.DeleteMeal(meal);
                await _dbSaveService.SaveChangesAsync();
                return Ok($"Meal with id of {mealId} was deleted");
            }

            return Conflict($"Something went wrong while deleteing meal with id: {mealId}");
        }
        #endregion

        #region MealIngredientEndpoints
        [HttpGet("{mealId}/ingredients")]
        public async Task<ActionResult<IEnumerable<MealIngredientDto>>> GetMealIngredients([Required] int mealId, [Required] int pageNumber = 1,[Required] int pageSize = 5)
        {
            bool mealExists = await _mealRepository.MealExistsAsync(mealId);
            if(!mealExists)
                return BadRequest($"Meal with an id of {mealId} does not exist");

            pageSize = pageSize > MaxPageSize ? 5 : pageSize;
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            var (mealIngredients, paginationMetaData) = await _mealRepository.GetMealIngredientsAsync(mealId, pageNumber, pageSize);
            if (mealIngredients.Count() == 0)
                return NotFound($"Ingredients for meal with an id of {mealId} weren't found in the database");

            Response.Headers.Append("X-Pagination",
                JsonConvert.SerializeObject(paginationMetaData));

            return Ok(_mapper.Map<IEnumerable<MealIngredientDto>>(mealIngredients));
        }

        [HttpPost("ingredients")]
        public async Task<ActionResult<DietDto>> AddMealIngredient( [Required] MealIngredientForCreationDto mealIngredient)
        {
            if(!await _mealRepository.MealExistsAsync(mealIngredient.MealId))
                return BadRequest($"Meal with an id of: {mealIngredient.MealId} does not exist");

            if(!await _ingredientRepository.IngredientExistsAsync(mealIngredient.IngredientId))
                return BadRequest($"Ingredient with an id of: {mealIngredient.IngredientId} does not exist");

            if(await _mealRepository.MealIngredientExistsAsync(mealIngredient.MealId,mealIngredient.IngredientId))
                return NotFound($"Meal Ingredient already exists");

            var (isValidData,validatorMessage) = _mealRepository.VerifyGramMililiters(mealIngredient.Grams, mealIngredient.Mililiters);
            if(!isValidData) 
                return BadRequest(validatorMessage);
            
            var objToReturn = _mapper.Map<MealIngredient>(mealIngredient);

            _mealRepository.AddMealIngredient(objToReturn);
            await _dbSaveService.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{mealId}/ingredients/{ingredientId}")]
        public async Task<ActionResult> UpdateDiet([Required] int mealId, [Required] int ingredientId
            , [Required] MealIngredientForUpdateDto mealIngredient)
        {
            if(!await _mealRepository.MealExistsAsync(mealId))
                return BadRequest($"Meal with an id of: {mealId} does not exist");

            if(!await _ingredientRepository.IngredientExistsAsync(ingredientId))
                return BadRequest($"Ingredient with an id of: {ingredientId} does not exist");

            if(!await _mealRepository.MealIngredientExistsAsync(mealId,ingredientId))
                return NotFound($"Meal Ingredient was not found");

            var (isValidData,validatorMessage) = _mealRepository.VerifyGramMililiters(mealIngredient.Grams, mealIngredient.Mililiters);
            if(!isValidData) 
                return BadRequest(validatorMessage);

            var mealIngredientEntity = await _mealRepository.GetMealIngredientAsync(mealId, ingredientId);

            if (mealIngredientEntity == null)
            {
                return NotFound();
            }

            //mapper forces modification of input data to source data in database
            _mapper.Map(mealIngredient, mealIngredientEntity);

            await _dbSaveService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{mealId}/ingredients/{ingredientId}")]
        public async Task<ActionResult> DeleteMealIngredient(int mealId, int ingredientId)
        {
            if(!await _mealRepository.MealIngredientExistsAsync(mealId,ingredientId))
                return NotFound($"Meal Ingredient was not found");

            var mealIngredient = await _mealRepository.GetMealIngredientAsync(mealId, ingredientId);
            if (mealIngredient != null)
            {
                _mealRepository.DeleteMealIngredient(mealIngredient);
                await _dbSaveService.SaveChangesAsync();
                return Ok();
            }

            return Conflict($"Something went wrong while deleting mealIngredient");
        }
        #endregion

        
    }
}
