using AutoMapper;
using DietCraft.API.Entities;
using DietCraft.API.Enums;
using DietCraft.API.Models.Role;
using DietCraft.API.Models.User;
using DietCraft.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DietCraft.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RolesController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {

            var roles = await _roleRepository.GetRolesAsync();
            if(roles == null)
                return NotFound("No roles found in the database");
            return Ok(_mapper.Map<IEnumerable<RoleDto>>(roles));
        }
    }
}
