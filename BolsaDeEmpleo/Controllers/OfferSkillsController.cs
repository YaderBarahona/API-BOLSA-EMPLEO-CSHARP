using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferSkillsController : ControllerBase
    {
        private readonly IOfferSkillsRepository _offerSkillRepository;

        public OfferSkillsController(IOfferSkillsRepository offerSkillRepository)
        {
            _offerSkillRepository = offerSkillRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<OfferSkillsDto>>> GetOfferSkills()
        {
            List<OfferSkillsDto> offerSkillsListDto = await _offerSkillRepository.GetAll();

            if (offerSkillsListDto == null)
            {
                return NotFound();
            }

            return Ok(offerSkillsListDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OfferSkills>> PostOfferSkill(OfferSkillsDto offerSkillDto)
        {
            if (offerSkillDto == null)
            {
                return BadRequest();
            }

            OfferSkills offerSkill = await _offerSkillRepository.Create(offerSkillDto);

            return CreatedAtAction("GetOfferSkills", new { id = offerSkill.IdOfferSkills }, offerSkill);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOfferSkills(int idOffer, int idSkill)
        {
            var offerSkills = await _offerSkillRepository.GetById(idOffer, idSkill);
            if (offerSkills == null)
            {
                return NotFound();
            }

            await _offerSkillRepository.Delete(idOffer, idSkill);
            return NoContent();
        }
    }
}
