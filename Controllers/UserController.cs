using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUser UserRepository, IMapper mapper)
        {
            _userRepository = UserRepository;
            _mapper = mapper;
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
        public ActionResult AddUser (UserDto user)
        {
            if (user == null)
            {
                return NotFound();
            }

            var finalUser = _mapper.Map<User>(user);

            _userRepository.addUser(finalUser);

            return Ok();
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
