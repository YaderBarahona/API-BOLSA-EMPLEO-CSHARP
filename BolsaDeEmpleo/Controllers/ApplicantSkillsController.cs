using AutoMapper;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantSkillsController : ControllerBase
    {
        private readonly IApplicantSkillsRepository _applicantSkillsRepository;

        public ApplicantSkillsController(IApplicantSkillsRepository applicantSkillsRepository)
        {
            _applicantSkillsRepository = applicantSkillsRepository;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ApplicantSkillsDto>>> GetApplicantSkills()
        {
            List<ApplicantSkillsDto> applicantSkillsListDto = await _applicantSkillsRepository.GetAll();

            if (applicantSkillsListDto == null)
            {
                return NotFound();
            }

            return Ok(applicantSkillsListDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApplicantSkills>> PostApplicantSkills(ApplicantSkillsDto applicantSkillsDto)
        {
            if (applicantSkillsDto == null)
            {
                return BadRequest();
            }

            ApplicantSkills applicantSkills = await _applicantSkillsRepository.Create(applicantSkillsDto);

            return CreatedAtAction("GetApplicantSkills", new { id = applicantSkills.IdApplicantSkills }, applicantSkills);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteApplicantSkills(int idApplicant, int idSkill)
        {
            var applicantSkill = await _applicantSkillsRepository.GetById(idApplicant, idSkill);
            if (applicantSkill == null)
            {
                return NotFound();
            }

            await _applicantSkillsRepository.Delete(idApplicant, idSkill);
            return NoContent();
        }
    }
}
