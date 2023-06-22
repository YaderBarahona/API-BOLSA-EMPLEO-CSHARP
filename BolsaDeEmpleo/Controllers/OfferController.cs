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
    public class OfferController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            List<OfferDtoGet> offerList = await _offerRepository.GetAll();

            if (offerList == null)
            {
                return NotFound();
            }

            return Ok(offerList);
        }


        [HttpGet("{id}", Name = "GetOffer")]
        //documentamos el tipo de codigo de respuesta mediante ProducesResponseType
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Applicant>> GetOffer(int id)
        {
            var education = await _offerRepository.GetById(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Offer>> PostOffers(OfferDto offerDto)
        {

            if (offerDto == null)
            {
                return BadRequest();
            }

            Offer offer = await _offerRepository.Create(offerDto);
            return CreatedAtAction("GetOffer", new { id = offer.IdOffer }, offer);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutOffer(int id, OfferDto offerDto)
        {
            if (offerDto == null)
            {
                return BadRequest();
            }

            var offer = await _offerRepository.GetById(id);

            if (offer == null)
            {
                return NotFound();
            }

            await _offerRepository.Update(id, offerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _offerRepository.GetById(id);
            if (offer == null)
            {
                return NotFound();
            }

            await _offerRepository.Delete(id);
            return NoContent();
        }

    }
}
