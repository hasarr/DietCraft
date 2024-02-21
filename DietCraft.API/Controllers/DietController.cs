using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using AutoMapper;
using DietCraft.API.Entities;
using DietCraft.API.Enums;
using DietCraft.API.Models.Diet;
using DietCraft.API.Models.User;
using DietCraft.API.Services;
using DietCraft.API.Services.DietService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace DietCraft.API.Controllers
{
    [Route("api/diets")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private IMapper _mapper;
        private IDietRepository _dietRepository;
        private readonly DbSaveService _dbSaveService;
        const int MaxPageSize = 5;

        public DietController(IMapper mapper, IDietRepository dietRepository, DbSaveService dbSaveService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dietRepository = dietRepository ?? throw new ArgumentNullException(nameof(dietRepository));
            _dbSaveService = dbSaveService ?? throw new ArgumentNullException(nameof(dbSaveService));
        }

        #region Dietendpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DietDto>>> GetDiets([Required] int pageNumber = 1,[Required] int pageSize = 5)
        {
            pageSize = pageSize > MaxPageSize ? 5 : pageSize;
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            var (diets, paginationMetaData) = await _dietRepository.GetDietsAsync(pageNumber, pageSize);
            if (diets == null)
                return NotFound("No diets found in the database");

            Response.Headers.Append("X-Pagination",
                JsonConvert.SerializeObject(paginationMetaData));

            return Ok(_mapper.Map<IEnumerable<DietDto>>(diets));
        }

        [HttpGet("{dietId}")]
        public async Task<ActionResult<DietDto>> GetDiet([Required] int dietId)
        {
            var diet = await _dietRepository.GetDietByIdAsync(dietId);
            if (diet == null)
                return NotFound($"Diet with given id of {dietId} was not found");
            else return Ok(_mapper.Map<DietDto>(diet));
        }

        [HttpPost]
        public async Task<ActionResult<DietDto>> AddDiet( [Required] DietForCreationDto diet)
        {
            if(!await _dietRepository.DietTypeExistsAsync(diet.DietTypeId))
                return BadRequest($"DietType with id of: {diet.DietTypeId} does not exist");

            if(diet.IsCustom == true && diet.UserIdIfCustom <= 0)
                return BadRequest("You need to provide valid UserId for custom diet");

            if(diet.IsCustom == false && diet.UserIdIfCustom > 0)
                return BadRequest("Can't provide UserId for non-custom diet");

            var dietToReturn = _mapper.Map<Diet>(diet);

            _dietRepository.AddDiet(dietToReturn);
            await _dbSaveService.SaveChangesAsync();

            return Created();
        }

        [HttpPut("{dietId}")]
        public async Task<ActionResult> UpdateDiet([Required] int dietId, [Required] DietForUpdateDto diet)
        {
            if (!await _dietRepository.DietExistsAsync(dietId))
            {
                return NotFound($"Diet with id of {dietId} does not exist");
            }

            if (!await _dietRepository.DietTypeExistsAsync(diet.DietTypeId))
            {
                return BadRequest($"DietType with id of {diet.DietTypeId} does not exist");
            }

            var dietEntity = await _dietRepository
                .GetDietByIdAsync(dietId);

            if (dietEntity == null)
            {
                return NotFound();
            }

            //mapper forces modification of input data to source data in database
            _mapper.Map(diet, dietEntity);

            await _dbSaveService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{dietId}")]
        public async Task<ActionResult> DeleteDiet([Required] int dietId)
        {
            bool dietExists = await _dietRepository.DietExistsAsync(dietId);
            if(!dietExists)
                return NotFound($"Diet with id of {dietId} does not exist");

            var diet = await _dietRepository.GetDietByIdAsync(dietId);
            if (diet != null)
            {
                _dietRepository.DeleteDiet(diet);
                await _dbSaveService.SaveChangesAsync();
                return Ok($"Diet with id of {dietId} was deleted");
            }

            return Conflict($"Something went wrong while deleteing diet with id: {dietId}");
        }
        #endregion

        #region DietTypeEndpoints
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<DietTypeDto>>> GetDietTypes([Required] int pageNumber = 1,[Required] int pageSize = 5)
        {
            pageSize = pageSize > MaxPageSize ? 5 : pageSize;
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            var (dietTypes, paginationMetaData) = await _dietRepository.GetDietTypesAsync(pageNumber, pageSize);
            if (dietTypes == null)
                return NotFound("No dietTypes found in the database");

            Response.Headers.Append("X-Pagination",
                JsonConvert.SerializeObject(paginationMetaData));

            return Ok(_mapper.Map<IEnumerable<DietTypeDto>>(dietTypes));
        }

        [HttpGet("types/{dietTypeId}")]
        public async Task<ActionResult<DietTypeDto>> GetDietType([Required] int dietTypeId)
        {
            var dietType = await _dietRepository.GetDietTypeByIdAsync(dietTypeId);
            if (dietType == null)
                return NotFound("Diet with given id was not found");
            else return Ok(_mapper.Map<DietTypeDto>(dietType));
        }

        [HttpPost("types")]
        public async Task<ActionResult<DietTypeDto>> AddDietType( [Required] DietTypeForCreationDto dietType)
        {
            if(dietType.IsCustom == false && dietType.UserIdIfCustom > 0)
                return BadRequest("Can't provide UserId for non-custom dietType");

            if(dietType.IsCustom == true && dietType.UserIdIfCustom <= 0)
                return BadRequest("You need to provide valid UserId for custom dietType");

            if((dietType.CarbPercent + dietType.FatPercent + dietType.ProteinPercent) != 100)
                return BadRequest("Sum of carb, fat and protein percent must be equal to 100%");

            var dietTypeToReturn = _mapper.Map<DietType>(dietType);

            _dietRepository.AddDietType(dietTypeToReturn);
            await _dbSaveService.SaveChangesAsync();

            return Created();
        }

        [HttpPut("types/{dietTypeId}")]
        public async Task<ActionResult> UpdateDietType([Required] int dietTypeId, [Required] DietTypeForUpdateDto dietType)
        {
            if (!await _dietRepository.DietTypeExistsAsync(dietTypeId))
            {
                return NotFound($"DietType with id of {dietTypeId} does not exist");
            }
            
            if((dietType.CarbPercent + dietType.FatPercent + dietType.ProteinPercent) != 100)
                return BadRequest("Sum of carb, fat and protein percent must be equal to 100%");

            var dietTypeEntity = await _dietRepository
                .GetDietTypeByIdAsync(dietTypeId);

            if (dietTypeEntity == null)
            {
                return NotFound();
            }

            //mapper forces modification of input data to source data in database
            _mapper.Map(dietType, dietTypeEntity);

            await _dbSaveService.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("types/{dietTypeId}")]
        public async Task<ActionResult> DeleteDietType([Required] int dietTypeId)
        {
            bool dietTypeExists = await _dietRepository.DietTypeExistsAsync(dietTypeId);
            if(!dietTypeExists)
                return BadRequest($"DietType with id of {dietTypeId} does not exist");

            var dietType = await _dietRepository.GetDietTypeByIdAsync(dietTypeId);
            if (dietType != null)
            {
                _dietRepository.DeleteDietType(dietType);
                await _dbSaveService.SaveChangesAsync();
                return Ok($"Diet with id of {dietTypeId} was deleted");
            }

            return Conflict($"Something went wrong while deleteing diet with id: {dietTypeId}");
        }

        #endregion
    }



}
