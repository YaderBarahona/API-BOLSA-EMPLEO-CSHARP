using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;
using BolsaDeEmpleo.Repositorio;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantDtoGet>> GetAll()
        {
            List<Applicant> applicantList = await _context.Applicants
            .Include(o => o.EducationList)
            .Include(o => o.ApplicantSkillsList)
            .Include(o => o.OfferApplicantList).ToListAsync();

            List<ApplicantDtoGet> applicantListDtoGet = new List<ApplicantDtoGet>();

            foreach (Applicant applicant in applicantList)
            {

            ApplicantDtoGet applicantDtoGet = new ApplicantDtoGet();
            applicantDtoGet.IdApplicant = applicant.IdApplicant;
            applicantDtoGet.Name = applicant.Name;
            applicantDtoGet.Email = applicant.Email;
            applicantDtoGet.Resume = applicant.Resume;

            foreach (Education education in applicant.EducationList)
            {
                EducationDtoGet educationDtoGet = new EducationDtoGet();
                educationDtoGet.IdEducation = education.IdEducation;
                educationDtoGet.Tittle = education.Tittle;
                educationDtoGet.EducationDescription = education.EducationDescription;
                educationDtoGet.DateCompletionStudies = education.DateCompletionStudies;

                applicantDtoGet.EducationList.Add(educationDtoGet);

            }

            //recorriendo la lista de habilidades del aplicante
            foreach (ApplicantSkills applicantSkill in applicant.ApplicantSkillsList)
            {
                ApplicantSkillsDtoGet applicantSkillsDtoGet = new ApplicantSkillsDtoGet();

                Skill skill = await _context.Skill
                .FirstOrDefaultAsync(s => s.IdSkill == applicantSkill.IdSkill);

                applicantSkillsDtoGet.IdApplicantSkills = skill.IdSkill;
                applicantSkillsDtoGet.SkillDescription = skill.SkillDescription;

                applicantDtoGet.ApplicantSkillsList.Add(applicantSkillsDtoGet);

            }

            //recorriendo la lista de ofertas del aplicante
            foreach (OfferApplicants offerApplicants in applicant.OfferApplicantList)
            {
                OfferApplicantsDtoGet offerApplicantsDtoGet = new OfferApplicantsDtoGet();
                offerApplicantsDtoGet.IdOffer = offerApplicants.IdOffer;

                Offer offer = await _context.Offers
                .FirstOrDefaultAsync(o => o.IdOffer == offerApplicants.IdOffer);

                offerApplicantsDtoGet.IdOffer = offer.IdOffer;
                offerApplicantsDtoGet.IdCompany = offer.IdCompany;
                offerApplicantsDtoGet.OfferDescription = offer.OfferDescription;

                applicantDtoGet.OfferApplicantList.Add(offerApplicantsDtoGet);

            }

            applicantListDtoGet.Add(applicantDtoGet);
        }

            return applicantListDtoGet;


            //List<Applicant> ApplicantList = await _context.Applicants
            //.Include(applicant => applicant.EducationList)
            //.Select(applicant => new Applicant
            //{
            //    IdApplicant = applicant.IdApplicant,
            //    Name = applicant.Name,
            //    Email = applicant.Email,
            //    Resume = applicant.Resume,

            //    ApplicantSkillsList = applicant.ApplicantSkillsList,

            //    OfferApplicantList = applicant.OfferApplicantList,

            //    EducationList = applicant.EducationList.Select(education => new Education
            //    {
            //        Tittle = education.Tittle,
            //        EducationDescription = education.EducationDescription,
            //        DateCompletionStudies = education.DateCompletionStudies }).ToList(),
            //}).ToListAsync();

            //return ApplicantList;
        }

        public async Task<ApplicantDtoGet> GetById(int idApplicant)
        {

            var applicant = await _context.Applicants
            .Include(e => e.EducationList).
            Include(a => a.ApplicantSkillsList).
            Include(o => o.OfferApplicantList).FirstOrDefaultAsync(a => a.IdApplicant == idApplicant);

            if (applicant == null)
            {
                return null;
            }

            ApplicantDtoGet applicantDtoGet = new ApplicantDtoGet();
            applicantDtoGet.IdApplicant = applicant.IdApplicant;
            applicantDtoGet.Name = applicant.Name;
            applicantDtoGet.Email = applicant.Email;
            applicantDtoGet.Resume = applicant.Resume;


            foreach (Education education in applicant.EducationList)
            {
                EducationDtoGet educationDtoGet = new EducationDtoGet();
                educationDtoGet.IdEducation = education.IdEducation;
                educationDtoGet.Tittle = education.Tittle;
                educationDtoGet.EducationDescription = education.EducationDescription;
                educationDtoGet.DateCompletionStudies = education.DateCompletionStudies;

                applicantDtoGet.EducationList.Add(educationDtoGet);

            }

            foreach (ApplicantSkills applicantSkills in applicant.ApplicantSkillsList)
            {
                ApplicantSkillsDtoGet applicantSkillsDtoGet = new ApplicantSkillsDtoGet();

                Skill skill = await _context.Skill
                .FirstOrDefaultAsync(c => c.IdSkill == applicantSkills.IdSkill);

                applicantSkillsDtoGet.IdApplicantSkills = skill.IdSkill;
                applicantSkillsDtoGet.SkillDescription = skill.SkillDescription;

                applicantDtoGet.ApplicantSkillsList.Add(applicantSkillsDtoGet);

            }

            foreach (OfferApplicants offerApplicants in applicant.OfferApplicantList)
            {
                OfferApplicantsDtoGet offerApplicantsDtoGet = new OfferApplicantsDtoGet();
                offerApplicantsDtoGet.IdOffer = offerApplicants.IdOffer;

                Offer offer = await _context.Offers
                .FirstOrDefaultAsync(c => c.IdOffer == offerApplicants.IdOffer);

                offerApplicantsDtoGet.IdOffer = offer.IdOffer;
                offerApplicantsDtoGet.IdCompany = offer.IdCompany;
                offerApplicantsDtoGet.OfferDescription = offer.OfferDescription;

                applicantDtoGet.OfferApplicantList.Add(offerApplicantsDtoGet);

            }


            return applicantDtoGet;

            // var applicant = await _context.Applicants
            //.Include(applicant => applicant.EducationList).
            //Include(applicant => applicant.ApplicantSkillsList).
            //Include(applicant => applicant.OfferApplicantList)
            //.FirstOrDefaultAsync(applicant => applicant.IdApplicant == idApplicant);

            // return applicant;
        }

        public async Task<Applicant> Create(ApplicantDto applicantDto)
        {
            Applicant applicant = new Applicant();
            applicant.IdApplicant = applicantDto.IdApplicant;
            applicant.Name = applicantDto.Name;
            applicant.Email = applicantDto.Email;
            applicant.Resume = applicantDto.Resume;

            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();

            return applicant;

        }

        public async Task Update(int idApplicant, ApplicantDto applicantDto)
        {
            Applicant applicantUpdate = await _context.Applicants.FindAsync(idApplicant);
            applicantUpdate.Name = applicantDto.Name;
            applicantUpdate.Email = applicantDto.Email;
            applicantUpdate.Resume = applicantDto.Resume;

            _context.Entry(applicantUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idApplicant)
        {
            var applicant = await _context.Applicants.FindAsync(idApplicant);

            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();
        }

    }
}
