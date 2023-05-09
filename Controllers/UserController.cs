using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Portfolio_API.Data;
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
        private ResponseObject _responseObject;
        private ResponseInfo _responseInfo;

        public UserController(IUser UserRepository, 
            IMapper mapper, 
            TokenGeneration token
            )
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
        public ActionResult<User> GetUserDetials ()
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            if (userId == 0)
            {
				_responseInfo = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "User not Found");
                return NotFound(_responseInfo);
            }
            else
            {
				var users = _userRepository.GetUserById(userId, false);
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Authorized.ToString(), "Request Successfull", users);
			}

			return Ok(_responseObject);
        }


        // POST api/<UserController>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Tokenmodel> AddUser (UserDto user)
        {
            if (user == null)
            {
				_responseInfo = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "User not found");
                return NotFound(_responseInfo);
			}

			var finalUser = _mapper.Map<User>(user);

            var userExists = _userRepository.validateUser(finalUser);

            // TODO : Existing user 

            // TODO : Response should return common
            // Error : Message, Data, Status
            // Success : Data, Message, Status

            if (userExists)
            {
                return BadRequest();
            }

            _userRepository.addUser(finalUser);

            var Token = _token.TokenGenerator(finalUser);

            var tokenToReturn = new Tokenmodel();
            tokenToReturn.Token = Token;

            _responseObject = ResponseBuilder.GenerateResponse(ResultCode.Authorized.ToString(), "Request Successfull", tokenToReturn);

            return Ok(_responseObject);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateUser(UserDto user)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            if (userId == 0)
            {
                _responseInfo = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "Result not found");
                return NotFound(_responseInfo);
            }

            var users = _mapper.Map<User>(user);

            _userRepository.updateUser(userId, users);
            _responseInfo = ResponseBuilder.GenerateResponse(ResultCode.Success.ToString(), "User Info updated successfully");

            return Ok(_responseInfo);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser()
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            if (userId == 0)
            {
                _responseInfo = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "Result not found");
                return NotFound(_responseInfo);
            }

            _userRepository.removeUser(userId);
            _responseInfo = ResponseBuilder.GenerateResponse(ResultCode.Success.ToString(), "User Deleted successfully");
            return Ok(_responseInfo);
        }
    }
}
