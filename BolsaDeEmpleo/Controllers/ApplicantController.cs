using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository _applicantRepository; 

        public ApplicantController(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicants()
        {
            List<ApplicantDtoGet> applicantList = await _applicantRepository.GetAll();

            if (applicantList == null)
            {
                return NotFound();
            }

            return Ok(applicantList);
        }

        [HttpGet("{id}", Name="GetApplicant")]
        //documentamos el tipo de codigo de respuesta mediante ProducesResponseType
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Applicant>> GetApplicant(int id)
        {
            var applicant = await _applicantRepository.GetById(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Applicant>> PostApplicant(ApplicantDto applicantDto)
        {
            if (applicantDto == null)
            {
                return BadRequest();
            }

            Applicant applicant = await _applicantRepository.Create(applicantDto);

            return CreatedAtAction("GetApplicant", new { id = applicant.IdApplicant }, applicant);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutApplicant(int id, ApplicantDto applicantDto)
        {

            if (applicantDto == null)
            {
                return BadRequest();
            }

            var applicant = await _applicantRepository.GetById(id);

            if (applicant == null)
            {
                return NotFound();
            }

            await _applicantRepository.Update(id, applicantDto);
            return NoContent();
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteApplicant(int idApplicant)
        {
            var applicant = await _applicantRepository.GetById(idApplicant);
            if (applicant == null)
            {
                return NotFound();
            }

            await _applicantRepository.Delete(idApplicant);
            return NoContent();
        }
    }
}
