﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio_API.DTOs;
using Portfolio_API.Models;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API.Controllers
{
    [Route("api/User")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepository;
        private readonly IMapper _mapper;
        private readonly TokenGeneration _token;
        private readonly AuthController _auth;

        public UserController(IUser UserRepository, IMapper mapper, TokenGeneration token)
        {
            _userRepository = UserRepository;
            _mapper = mapper;
            _token = token;
        }

        //// GET: api/<UserController>
        //[HttpGet]
        //public ActionResult<IEnumerable<User>> GetAllUsers ()
        //{
        //    var users = _userRepository.Users();
        //    return Ok(users);
        //}

        // GET api/<UserController>/5
        [HttpGet]
        public ActionResult<User> GetUserById (int id)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            if (userId == 0)
            {
                return Unauthorized();
            }

            var users = _userRepository.GetUserById(userId, false);

            return Ok(users);
        }


        // POST api/<UserController>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<string> AddUser (UserDto user)
        {
            if (user == null)
            {
                return NotFound();
            }

            var finalUser = _mapper.Map<User>(user);

            // TODO : Existing user 

            // TODO : Response should return common
                // Error : Message, Data, Status
                // Success : Data, Message, Status
            _userRepository.addUser(finalUser);

            var Token = _token.TokenGenerator(finalUser);
            var JsonToken = JsonConvert.SerializeObject(Token);
            return Ok(JsonToken);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(UserDto user)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            if (userId == 0)
            {
                return NotFound();
            }

            var users = _mapper.Map<User>(user);

            _userRepository.updateUser(userId, users);

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser ()
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            if (userId == 0)
            {
                return NotFound();
            }

            _userRepository.removeUser(userId);

            return Ok();
        }
    }
}
