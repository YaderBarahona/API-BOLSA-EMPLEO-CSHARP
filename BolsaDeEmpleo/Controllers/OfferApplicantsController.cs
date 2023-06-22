using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferApplicantsController : ControllerBase
    {

        private readonly IOfferApplicants _offerAplicantsRepository;

        public OfferApplicantsController(IOfferApplicants offerAplicantsRepository)
        {
            _offerAplicantsRepository = offerAplicantsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<IEnumerable<OfferApplicantsDto>>> GetOfferApplicants()
        {
            List<OfferApplicantsDto> offerApplicantListDto = await _offerAplicantsRepository.GetAll();

            if (offerApplicantListDto == null)
            {
                return NotFound();
            }

            return Ok(offerApplicantListDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OfferApplicants>> PostOfferApplicant(OfferApplicantsDto offerApplicantsDto)
        {
            if (offerApplicantsDto == null)
            {
                return BadRequest();
            }

            OfferApplicants offerApplicants = await _offerAplicantsRepository.Create(offerApplicantsDto);

            return CreatedAtAction("GetOfferApplicants", new { id = offerApplicants.IdOfferApplicants }, offerApplicants);

        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOfferAplicant(int idApplicant, int idOffer)
        {
            var offerApplicants = await _offerAplicantsRepository.GetById(idApplicant, idOffer);
            if (offerApplicants == null)
            {
                return NotFound();
            }

            await _offerAplicantsRepository.Delete(idApplicant, idOffer);
            return NoContent();
        }
    }
}
