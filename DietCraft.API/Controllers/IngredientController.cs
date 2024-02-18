using AutoMapper;
using DietCraft.API.Services.DietService;
using DietCraft.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DietCraft.API.Services.IngredientService;
using DietCraft.API.Models.Diet;
using Newtonsoft.Json;
using DietCraft.API.Models.Ingredient;
using System.ComponentModel.DataAnnotations;
using DietCraft.API.Entities;

namespace DietCraft.API.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IMapper _mapper;
        private IIngredientRepository _ingredientRepository;
        private readonly DbSaveService _dbSaveService;
        const int MaxPageSize = 5;

        public IngredientController(IMapper mapper, IIngredientRepository ingredientRepository, DbSaveService dbSaveService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));
            _dbSaveService = dbSaveService ?? throw new ArgumentNullException(nameof(dbSaveService));
        }

        #region IngrdientEndpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredients([Required] int pageNumber = 1,[Required] int pageSize = 5)
        {
            pageSize = pageSize > MaxPageSize ? 5 : pageSize;
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            var (ingredients, paginationMetaData) = await _ingredientRepository.GetIngredientsAsync(pageNumber, pageSize);
            if (ingredients == null)
                return NotFound("No ingredients found in the database");

            Response.Headers.Append("X-Pagination",
                JsonConvert.SerializeObject(paginationMetaData));

            return Ok(_mapper.Map<IEnumerable<IngredientDto>>(ingredients));
        }

        [HttpGet("{ingredientId}")]
        public async Task<ActionResult<IngredientDto>> GetIngredient([Required] int ingredientId)
        {
            var ingredient = await _ingredientRepository.GetIngredientByIdAsync(ingredientId);
            if (ingredient == null)
                return NotFound($"Ingredient with given id of {ingredientId} was not found");
            else return Ok(_mapper.Map<IngredientDto>(ingredient));
        }

        [HttpPost]
        public async Task<ActionResult<IngredientDto>> AddIngredient( [Required] IngredientForCreationDto ingredient)
        {
            if(!await _ingredientRepository.IngredientNameExistsAsync(ingredient.Name))
                return BadRequest($"Ingredient with name of: {ingredient.Name} already exists");

            var ingredientToReturn = _mapper.Map<Ingredient>(ingredient);

            _ingredientRepository.AddIngredient(ingredientToReturn);
            await _dbSaveService.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{ingredientId}")]
        public async Task<ActionResult> UpdateIngredient([Required] int ingredientId, [Required] IngredientForUpdateDto ingredient)
        {
            if (!await _ingredientRepository.IngredientExistsAsync(ingredientId))
            {
                return NotFound($"Ingredient with id of {ingredientId} does not exist");
            }

            var ingredientEntity = await _ingredientRepository
                .GetIngredientByIdAsync(ingredientId);

            if (ingredientEntity == null)
            {
                return NotFound();
            }

            //mapper forces modification of input data to source data in database
            _mapper.Map(ingredient, ingredientEntity);

            await _dbSaveService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{ingredientId}")]
        public async Task<ActionResult> DeleteIngredient([Required] int ingredientId)
        {
            bool ingredientExists = await _ingredientRepository.IngredientExistsAsync(ingredientId);
            if(!ingredientExists)
                return BadRequest($"Ingredient with id of {ingredientId} does not exist");

            var ingredient = await _ingredientRepository.GetIngredientByIdAsync(ingredientId);
            if (ingredient != null)
            {
                _ingredientRepository.DeleteIngredient(ingredient);
                await _dbSaveService.SaveChangesAsync();
                return Ok($"Ingredient with id of {ingredientId} was deleted");
            }

            return Conflict($"Something went wrong while deleteing ingredient with id: {ingredientId}");
        }
        #endregion
    }
}
