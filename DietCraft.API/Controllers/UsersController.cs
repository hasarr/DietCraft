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



        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDto);
        }



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
            var isLoggedIn = _userRepository.VerifyUserSession();
                if(isLoggedIn) return Ok("You are already logged in");

            var fullUser = await _userRepository.GetUserByNameAsync(user.UserName);
            if (fullUser == null)
                return NotFound("User not found");

            bool isValid = await _userRepository.LoginUserAsync(fullUser, user.Password,rememberMe);
            if (isValid)
                return Ok("Logged in");

            return Unauthorized("Not authorized to log in");
        }



        [HttpPost("logout")]
        public async Task<ActionResult<bool>> LogOut()
        {
            if(!_userRepository.VerifyUserSession())
                return Unauthorized("You are not logged in");

            await _userRepository.LogoutUserAsync();
            return Ok("You were successfully logged out");
        }



        [HttpGet("loggedAs")]
        public async Task<ActionResult<User>> GetLoggedInUser()
        {
            var user = await _userRepository.GetLoggedInUserAsync();
            if(user == null)
                return Unauthorized("You are not logged in as a User");
            return Ok(user);
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
            bool userExists = await _userRepository.UserExists(userName);
            if(!userExists)
                return BadRequest($"User with username of {userName} does not exist");

            var user = await _userRepository.GetUserByNameAsync(userName);
            if (user != null)
            {
                _userRepository.DeleteUser(user);
                await _userRepository.SaveChangesAsync();
                return Ok($"User with username of {userName} was deleted");
            }

            return Conflict($"Something went wrong while deleteing user with userName: {userName}");
             
        }
    }
}
