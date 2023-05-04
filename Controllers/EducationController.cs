﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio_API.DTOs;
using Portfolio_API.Models;
using Portfolio_API.Repository;
using Portfolio_API.Repository.Repository_Interface;

namespace Portfolio_API.Controllers
{
    [Route("api/education")]
    [Authorize]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducation _EducationRepository;
        private readonly IMapper _mapper;

        public EducationController (IEducation education, IMapper mapper)
        {
            _EducationRepository = education;
            _mapper = mapper;
        }

        // GET: api/<EducationController>
        [HttpGet]
        public ActionResult<IEnumerable<EducationDto>> GetEducationDetails(int userid)
        {
            var educationDetails = _EducationRepository.GetDetails(userid);
            var finalEduDetail = _mapper.Map< IEnumerable<EducationDto>>(educationDetails);

            return Ok(finalEduDetail);
        }

        // POST api/<EducationController>
        [HttpPost]
        public ActionResult AddEduDetails(int id, EducationDto Edu)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var finalEdu = _mapper.Map<Education>(Edu);

            _EducationRepository.AddEducation(id, finalEdu);

            return Ok();
        }

        //// PUT api/<EducationController>/5
        [HttpPut]
        public ActionResult UpdateEdu(int id, int eduId, EducationDto Edu)
        {
            if (id == 0 || eduId == 0)
            {
                return NotFound();
            }

            var finalEdu = _mapper.Map<Education>(Edu);

            _EducationRepository.updateEducation(id, eduId, finalEdu);

            return Ok();
        }

        // DELETE api/<EducationController>/5
        [HttpDelete]
        public ActionResult DeleteEdu (int id, int eduId)
        {
            if (id == 0 || eduId == 0)
            {
                return NotFound();
            }

            _EducationRepository.removeEducation(id, eduId);

            return Ok();
        }
    }
}