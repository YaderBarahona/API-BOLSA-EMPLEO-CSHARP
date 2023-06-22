using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.Repositorio
{
    public class OfferSkillsRepository : IOfferSkillsRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferSkillsRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<OfferSkillsDto>> GetAll()
        {
            List<OfferSkills> offerSkillList = await _context.OfferSkills.ToListAsync();

            List<OfferSkillsDto> offerSkillListDto = new List<OfferSkillsDto>();

            foreach (OfferSkills offerSkill in offerSkillList)
            {
                OfferSkillsDto OfferSkillListDto = new OfferSkillsDto();
                OfferSkillListDto.IdOfferSkills = offerSkill.IdOfferSkills;
                OfferSkillListDto.IdOffer = offerSkill.IdOffer;
                OfferSkillListDto.IdSkill = offerSkill.IdSkill;
                offerSkillListDto.Add(OfferSkillListDto);
            }

            return offerSkillListDto;
        }

        public async Task<OfferSkills> GetById(int idOffer, int idSkill)
    {
            OfferSkills offerSkills = new OfferSkills();
            offerSkills = _context.OfferSkills.SingleOrDefault(offerSkill => offerSkill.IdOffer == idOffer && offerSkill.IdSkill == idSkill);

            return offerSkills;
        }

        public async Task<OfferSkills> Create(OfferSkillsDto offerSkillsDto)
        {
            OfferSkills offerSkills = new OfferSkills();
            offerSkills.IdOfferSkills = offerSkillsDto.IdOfferSkills;
            offerSkills.IdOffer = offerSkillsDto.IdOffer;
            offerSkills.IdSkill = offerSkillsDto.IdSkill;

            _context.OfferSkills.Add(offerSkills);
            await _context.SaveChangesAsync();

            return offerSkills;

        }

        public async Task Update(int idOfferSkills, OfferSkillsDto offerSkillsDto)
        {
            OfferSkills offerSkillsUpdate = await _context.OfferSkills.FindAsync(idOfferSkills);
            
            offerSkillsUpdate.IdOffer = offerSkillsDto.IdOffer;
            offerSkillsUpdate.IdSkill = offerSkillsDto.IdSkill;

            _context.Entry(offerSkillsUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idOffer, int idSkill)
        {
            OfferSkills offerSkills = new OfferSkills();
            offerSkills = _context.OfferSkills.SingleOrDefault(offerSkill => offerSkill.IdOffer == idOffer && offerSkill.IdSkill == idSkill);

            _context.OfferSkills.Remove(offerSkills);
            await _context.SaveChangesAsync();
        }
    }
}
