using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;
using BolsaDeEmpleo.Repositorio;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BolsaDeEmpleo.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;

        public OfferRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<OfferDtoGet>> GetAll()
        {

            List<Offer> offerList = await _context.Offers
           .Include(o => o.OfferSkillsList)
           .ToListAsync();

            List<OfferDtoGet> offerListDtoGet = new List<OfferDtoGet>();

            foreach (Offer offer in offerList)
            {
                OfferDtoGet offerDtoGet = new OfferDtoGet();
                offerDtoGet.IdOffer = offer.IdOffer;
                offerDtoGet.OfferTittle = offer.OfferTittle;
                offerDtoGet.OfferDescription = offer.OfferDescription;

                Company company = await _context.Companies
               .FirstOrDefaultAsync(c => c.IdCompany == offer.IdCompany);

                offerDtoGet.Company = company.NameCompany;

                foreach (OfferSkills offerSkill in offer.OfferSkillsList)
                {
                    OfferSkillsDtoGet offerSkillsDtoGet = new OfferSkillsDtoGet();

                    Skill habilidad = await _context.Skill
                    .FirstOrDefaultAsync(c => c.IdSkill == offerSkill.IdSkill);

                    offerSkillsDtoGet.IdOfferSkills = habilidad.IdSkill;
                    offerSkillsDtoGet.SkillDescription = habilidad.SkillDescription;
                    
                    offerDtoGet.offerSkillList.Add(offerSkillsDtoGet);

                }

                offerListDtoGet.Add(offerDtoGet);
            }

            return offerListDtoGet;

            //List<Offer> OfferList = await _context.Offers
            //.Include(company => company.Company)
            //.Select(offerCompany => new Offer
            //{
            //    IdOffer = offerCompany.IdOffer,
            //    OfferDescription = offerCompany.OfferDescription,
            //    IdCompany = offerCompany.IdCompany,
            //    OfferSkillsList = offerCompany.OfferSkillsList,
            //    OfferApplicantsList = offerCompany.OfferApplicantsList
            //}).ToListAsync();

            //return OfferList;
        }

        public async Task<OfferDtoGetA> GetById(int idOffer)
        {
            var offer = await _context.Offers
            .Include(c => c.OfferApplicantsList).Include(c => c.OfferSkillsList)
            .FirstOrDefaultAsync(c => c.IdOffer == idOffer);

            if (offer == null)
            {
                return null;
            }

            OfferDtoGetA offerDtoGetA = new OfferDtoGetA();
            offerDtoGetA.IdOffer = offer.IdOffer;
            offerDtoGetA.OfferTittle = offer.OfferTittle;
            offerDtoGetA.OfferDescription = offer.OfferDescription;

            Company company = await _context.Companies
           .FirstOrDefaultAsync(c => c.IdCompany == offer.IdCompany);

            offerDtoGetA.Company = company.NameCompany;

            foreach (OfferSkills offerSkills in offer.OfferSkillsList)
            {
                OfferSkillsDtoGet offerSkillsDtoGet = new OfferSkillsDtoGet();

                Skill skill = await _context.Skill
                .FirstOrDefaultAsync(c => c.IdSkill == offerSkills.IdSkill);

                offerSkillsDtoGet.SkillDescription = skill.SkillDescription;

                offerDtoGetA.OfferSkillList.Add(offerSkillsDtoGet);

            }

            foreach (OfferApplicants offerApplicants in offer.OfferApplicantsList)
            {
                ApplicantDto applicantDto = new ApplicantDto();

                Applicant applicant = await _context.Applicants
                .FirstOrDefaultAsync(c => c.IdApplicant == offerApplicants.IdApplicant);

                applicantDto.IdApplicant = applicant.IdApplicant;
                applicantDto.Name = applicant.Name;
                applicantDto.Email = applicant.Email;
                applicantDto.Resume = applicant.Resume;

                offerDtoGetA.ApplicantList.Add(applicantDto);

            }

            return offerDtoGetA;


            //var offer = await _context.Offers.FindAsync(idOffer);

            //return offer;
        }

        public async Task<Offer> Create(OfferDto offerDto)
        {
            Offer offer = new Offer();
            offer.IdOffer = offerDto.IdOffer;
            offer.IdCompany = offerDto.IdCompany;
            offer.OfferTittle = offerDto.OfferTittle;
            offer.OfferDescription = offerDto.OfferDescription;

            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            return offer;

        }

        public async Task Update(int idOffer, OfferDto offerDto)
        {
            Offer offer = await _context.Offers.FindAsync(idOffer);
            offer.OfferTittle = offerDto.OfferTittle;
            offer.OfferDescription = offerDto.OfferDescription;

            _context.Entry(offer).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idOffer)
        {
            var offer = await _context.Offers.FindAsync(idOffer);

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();
        }
    }
}
