using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DietCraft.API.DbContexts;
using DietCraft.API.Entities;
using DietCraft.API.Models;
using AutoMapper;
using DietCraft.API.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace DietCraft.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DietCraftContext _context;
        private readonly IMapper _mapper;
        private IUserRepository _userRepository { get; }

        public UsersController(DietCraftContext context, IMapper mapper, IUserRepository userRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }

        // GET: api/Users/5
        [HttpGet("{userName}")]
        public async Task<ActionResult<UserDto>> GetUserByName(string userName)
        {
            var user = await _userRepository.GetUserByNameAsync(userName);
            if (user == null)
                return NotFound("User with given username was not found");
            else return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([Required] UserLoginDto user, [Required] bool rememberMe)
        {
            var fullUser = await _userRepository.GetUserByNameAsync(user.UserName);
            if(fullUser == null)
                return NotFound("User not found");

            bool isValid = await _userRepository.LoginUserAsync(fullUser, user.Password,rememberMe);
            if (isValid)
            {
                return Ok("Zalogowano");
            }
            return Unauthorized("Nie zalogowano");
        }

        [HttpPost("logout")]
        public async Task<ActionResult<bool>> LogOut()
        {
            if(await _userRepository.LogoutUserAsync())
                return Ok("You were successfully logged out");
            else return BadRequest("You are not logged in");
        }

        [HttpGet("loggedAs")]
        public string GetLoggedInUsername()
        {
            return _userRepository.GetLoggedInUsernameAsync();
        }


        [HttpPost("create")]
        public async Task<ActionResult<UserDto>> CreateUser([Required] UserForCreationDto user)
        {
            if(await _userRepository.UserExists(user.UserName))
                return BadRequest("User with username " + user.UserName + " already exists");
            if(user.Role != "User" || user.Role != "Admin")
                return BadRequest("Invalid role set for user, allowed roles: Admin | User");

            var hashedPassword = _userRepository.HashPassword(user.Password);
            user.Password = hashedPassword;

            var userToReturn = _mapper.Map<User>(user);

            await _userRepository.AddUserAsync(userToReturn);
            await _userRepository.SaveChangesAsync();

            return Created();

        }

        [HttpDelete("delete")]
        public async Task<ActionResult<UserDto>> DeleteUser(string userName)
        {
            return null;
        }
    }
}
