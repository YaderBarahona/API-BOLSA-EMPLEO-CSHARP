using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;
using BolsaDeEmpleo.Repository;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;

        public EducationController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducations()
        {
            List<EducationDto> educationList = await _educationRepository.GetAll();

            if (educationList == null)
            {
                return NotFound();
            }

            return Ok(educationList);
        }

        [HttpGet("{id}", Name = "GetEducation")]
        //documentamos el tipo de codigo de respuesta mediante ProducesResponseType
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Education>> GetEducation(int id)
        {
            var education = await _educationRepository.GetById2(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);

        }

        //[HttpGet("{id}", Name = "GetEducationA")]
        ////documentamos el tipo de codigo de respuesta mediante ProducesResponseType
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<IEnumerable<Education>>> GetEducationA(int id)
        //{
        //    List<EducationDtoGet> education = await _educationRepository.GetById(id);

        //    if (education == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(education);
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Education>> PostEducation(EducationDto educationDto)
        {
            if (educationDto == null)
            {
                return BadRequest();
            }

            Education education = await _educationRepository.Create(educationDto);

            return CreatedAtAction("GetEducation", new { id = education.IdEducation }, education);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutEducation(int id, EducationDto educationDto)
        {
            if (educationDto == null)
            {
                return BadRequest();
            }

            var education = await _educationRepository.GetById3(id);

            if (education == null)
            {
                return NotFound();
            }

            await _educationRepository.Update(id, educationDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var education = await _educationRepository.GetById3(id);
            if (education == null)
            {
                return NotFound();
            }

            await _educationRepository.Delete(id);
            return NoContent();
        }

    }
}
