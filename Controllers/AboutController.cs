using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.DTOs;
using Portfolio_API.Models;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API.Controllers
{
    [Route("api/aboutDetails")]
    [Authorize]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAbout _userRepository;
        private readonly IMapper _mapper;
		private ResponseObject _responseObject;


		public AboutController(IAbout UserRepository, IMapper mapper)
        {
            _userRepository = UserRepository;
            _mapper = mapper;
        }

        // GET: api/<AboutController>
        [HttpGet]
        public ActionResult<IEnumerable<AboutDto>> aboutDetails()
        {
            var id = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);

            if (id == null)
            {
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "Result not found");
			}
            else
            {
				var aboutFromDB = _userRepository.GetAbout(id);

				var AboutDto = _mapper.Map<AboutDto>(aboutFromDB);
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Success.ToString(), null, AboutDto);
			}
			return Ok(_responseObject);
        }

        // POST api/<AboutController>
        [HttpPost]
        public ActionResult AddAboutDetails (AboutDto about)
        {
            var id = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);

            if (id == null)
            {
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "Result not found");
			}
            else
            {
				var finalAbout = _mapper.Map<About>(about);

				_userRepository.AddAbout(id, finalAbout);
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Success.ToString(), null, finalAbout);
			}

			return Ok(_responseObject);
        }

        // PUT api/<AboutController>/5
        [HttpPut]
        public ActionResult Put(AboutDto about)
        {
            var id = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            if (id == null)
            {
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "Result not found");
			}
            else
            {
				_userRepository.updateAbout(id, about);
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Success.ToString(), "Result updated successfully");
			}
			//var finalAbout = _mapper.Map<About>(about);

			return Ok(_responseObject);
        }

        // DELETE api/<AboutController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete()
        {
            var id = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);

            if (id == null)
            {
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Failure.ToString(), "Result not found");
			}
            else
            {
				_userRepository.removeAbout(id);
				_responseObject = ResponseBuilder.GenerateResponse(ResultCode.Success.ToString(), "Result Deleted successfully");

			}
			return Ok(_responseObject);
        }
    }
}
