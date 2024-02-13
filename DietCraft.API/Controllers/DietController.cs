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
                return NotFound("Diet with given id was not found");
            else return Ok(_mapper.Map<DietDto>(diet));
        }

        [HttpPost]
        public async Task<ActionResult<DietDto>> AddDiet( [Required] DietForCreationDto diet)
        {
            if(!await _dietRepository.DietTypeExistsAsync(diet.DietTypeId))
                return BadRequest("DietType with id of: " + diet.DietTypeId + " does not exist");

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
                return BadRequest($"Diet with id of {dietId} does not exist");

            var diet = await _dietRepository.GetDietByIdAsync(dietId);
            if (diet != null)
            {
                _dietRepository.DeleteDiet(diet);
                await _dbSaveService.SaveChangesAsync();
                return Ok($"Diet with id of {dietId} was deleted");
            }

            return Conflict($"Something went wrong while deleteing diet with id: {dietId}");
        }
    }
}
