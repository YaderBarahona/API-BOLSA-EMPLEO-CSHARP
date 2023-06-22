using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repositorio;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDbContext _context;

        public SkillRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<SkillDto>> GetAll()
        {
            List<Skill> skillList = await _context.Skill.ToListAsync();

            List<SkillDto> skillListDto = new List<SkillDto>();

            foreach (Skill skill in skillList)
            {
                SkillDto skillDto = new SkillDto();
                skillDto.IdSkill = skill.IdSkill;
                skillDto.SkillDescription = skill.SkillDescription;
                skillListDto.Add(skillDto);
            }

            return skillListDto;
        }

        public async Task<Skill> GetById(int idSkill)
        {
            var skill = await _context.Skill.FindAsync(idSkill);

            return skill;
        }

        public async Task<SkillDto> GetById2(int id)
        {
            var skill = await _context.Skill
           .FirstOrDefaultAsync(c => c.IdSkill == id);

            if (skill == null)
            {
                return null;
            }

            SkillDto skillDto = new SkillDto();

            skillDto.IdSkill = skill.IdSkill;
            skillDto.SkillDescription = skill.SkillDescription;

            return skillDto;

        }

        public async Task<Skill> Create(SkillDto skillDto)
        {
            Skill skill = new Skill();
            skill.IdSkill = skillDto.IdSkill;
            skill.SkillDescription = skillDto.SkillDescription;

            _context.Skill.Add(skill);
            await _context.SaveChangesAsync();

            return skill;

        }

        public async Task Update(int idSkill, SkillDto skillDto)
        {
            Skill skill = await _context.Skill.FindAsync(idSkill);
            skill.SkillDescription = skillDto.SkillDescription;

            _context.Entry(skill).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idSkill)
        {
            var skill = await _context.Skill.FindAsync(idSkill);

            _context.Skill.Remove(skill);
            await _context.SaveChangesAsync();
        }
    }
}
