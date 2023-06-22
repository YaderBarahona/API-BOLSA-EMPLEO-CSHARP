using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;
using BolsaDeEmpleo.Repositorio;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.Repository
{
    public class ApplicantSkillsRepository : IApplicantSkillsRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicantSkillsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicantSkillsDto>> GetAll()
        {
            List<ApplicantSkills> applicantSkillsList = await _context.ApplicantsSkills.ToListAsync();

            List<ApplicantSkillsDto> applicantSkillsListDto = new List<ApplicantSkillsDto>();

            foreach (ApplicantSkills applicantSkills in applicantSkillsList)
            {
                ApplicantSkillsDto newapplicantSkillsListDto = new ApplicantSkillsDto();
                newapplicantSkillsListDto.IdApplicantSkills = applicantSkills.IdApplicantSkills;
                newapplicantSkillsListDto.IdSkill = applicantSkills.IdSkill;
                newapplicantSkillsListDto.IdApplicant = applicantSkills.IdApplicant;
                //newapplicantSkillsListDto.SkillDescription = applicantSkills.d;
                applicantSkillsListDto.Add(newapplicantSkillsListDto);
            }

            return applicantSkillsListDto;
        }

        public async Task<ApplicantSkills> GetById(int idApplicant, int idSkill)
        {
            ApplicantSkills applicantSkills = new ApplicantSkills();
            applicantSkills = _context.ApplicantsSkills.SingleOrDefault(applicantSkill => applicantSkill.IdApplicant == idApplicant && applicantSkill.IdSkill == idSkill);

            return applicantSkills;
        }

        public async Task<List<SkillDto>> GetById2(int idApplicant)
        {

            var applicant1 = await _context.Applicants
           .Include(e => e.ApplicantSkillsList).FirstOrDefaultAsync(a => a.IdApplicant == idApplicant);

            List<SkillDto> skillListoDto = new List<SkillDto>();

            if (applicant1 == null)
            {
                return null;
            }

            foreach (ApplicantSkills skill in applicant1.ApplicantSkillsList)
            {
                SkillDto skillDto = new SkillDto();
                skillDto.IdSkill = skill.IdSkill;

                skillListoDto.Add(skillDto);

            }

            return skillListoDto;

            //var education = await _context.Education.FindAsync(idEducation);

            //return education;

        }
        public async Task<ApplicantSkills> Create(ApplicantSkillsDto applicantSkillsDto)
        {
            ApplicantSkills applicantSkills = new ApplicantSkills();
            applicantSkills.IdApplicantSkills = applicantSkillsDto.IdApplicantSkills;
            applicantSkills.IdApplicant = applicantSkillsDto.IdApplicant;
            applicantSkills.IdSkill = applicantSkillsDto.IdSkill;

            _context.ApplicantsSkills.Add(applicantSkills);
            await _context.SaveChangesAsync();

            return applicantSkills;
        }

        public async Task Update(int idApplicantSkillsDto, ApplicantSkillsDto applicantSkillsDto)
        {
            ApplicantSkills applicantSkills = await _context.ApplicantsSkills.FindAsync(idApplicantSkillsDto);
            applicantSkills.IdApplicant = applicantSkillsDto.IdApplicant;
            applicantSkills.IdSkill = applicantSkillsDto.IdSkill;

            _context.Entry(applicantSkills).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idApplicant, int idSkill)
        {

            ApplicantSkills applicantSkills = new ApplicantSkills();
            applicantSkills = _context.ApplicantsSkills.SingleOrDefault(applicantSkills => applicantSkills.IdApplicant == idApplicant && applicantSkills.IdSkill == idSkill);

            _context.ApplicantsSkills.Remove(applicantSkills);

            await _context.SaveChangesAsync();

        }
    }
}
