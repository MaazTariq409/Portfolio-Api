using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio_API.Data;
using Portfolio_API.DTOs;
using Portfolio_API.Models;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API.Controllers
{
    [Route("api/aboutDetails")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAbout _userRepository;
        private readonly IMapper _mapper;

        public AboutController(IAbout UserRepository, IMapper mapper)
        {
            _userRepository = UserRepository;
            _mapper = mapper;
        }

        // GET: api/<AboutController>
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<AboutDto>> aboutDetails(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var aboutFromDB = _userRepository.GetAbout(id);

            var AboutDto = _mapper.Map<AboutDto>(aboutFromDB);

            return Ok(AboutDto);
        }

        // POST api/<AboutController>
        [HttpPost]
        public ActionResult AddAboutDetails (int id, AboutDto about)
        {
            if(id == 0)
            {
                return NotFound();
            }
            
            var 

            _userRepository.AddAbout(id, about);

            return Ok();
        }

        //// PUT api/<AboutController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AboutController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
