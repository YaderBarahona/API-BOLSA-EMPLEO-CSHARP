using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repository;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BolsaDeEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;

        public SkillController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkills()
        {
            List<SkillDto> skillList = await _skillRepository.GetAll();

            if (skillList == null)
            {
                return NotFound();
            }

            return Ok(skillList);
        }

        [HttpGet("{id}", Name = "GetSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var skill = await _skillRepository.GetById2(id);
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Skill>> PostSkill(SkillDto skillDto)
        {
            if (skillDto == null)
            {
                return BadRequest();
            }

            Skill skill = await _skillRepository.Create(skillDto);

            return CreatedAtAction("GetSkill", new { id = skill.IdSkill }, skill);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, SkillDto skillDto)
        {
            if (skillDto == null)
            {
                return BadRequest();
            }

            var skill = await _skillRepository.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            await _skillRepository.Update(id, skillDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _skillRepository.GetById(id);
            if (skill == null)
            {
                return NotFound();
            }

            await _skillRepository.Delete(id);
            return NoContent();
        }
    }
}
