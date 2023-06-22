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
    public class EducationApplicantController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;

        public EducationApplicantController(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        [HttpGet("{id}", Name = "GetEducationA")]
        //documentamos el tipo de codigo de respuesta mediante ProducesResponseType
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Education>>> GetEducationA(int id)
        {
            List<EducationDtoGet> education = await _educationRepository.GetById(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }



    }
}
