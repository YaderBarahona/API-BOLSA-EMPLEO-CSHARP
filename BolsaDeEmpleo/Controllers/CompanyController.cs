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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            List<CompanyDtoGet> companyList = await _companyRepository.GetAll();

            if (companyList == null)
            {
                return NotFound();
            }

            return Ok(companyList);
        }

        [HttpGet("{id}", Name = "GetCompany")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _companyRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Company>> PostCompany(CompanyDto companyDto)
        {

            if (companyDto == null)
            {
                return BadRequest();
            }

            Company company = await _companyRepository.Create(companyDto);

            return CreatedAtAction("GetCompany", new { id = company.IdCompany }, company);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutCompany(int id, CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest();
            }

            var candidato = await _companyRepository.GetById(id);

            if (candidato == null)
            {
                return NotFound();
            }

            await _companyRepository.Update(id, companyDto);
            return NoContent();
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyRepository.GetById(id);
            if (company == null)
            {
                return NotFound();
            }

            await _companyRepository.Delete(id);
            return NoContent();
        }


    }
}
