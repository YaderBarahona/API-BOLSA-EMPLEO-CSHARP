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
    public class EducationRepository :  IEducationRepository
    {
        private readonly ApplicationDbContext _context;

        public EducationRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<List<EducationDto>> GetAll()
        {
            List<Education> educationList = await _context.Education.ToListAsync();

            List<EducationDto> educationDtoList = new List<EducationDto>();

            foreach (Education education in educationList)
            {
                EducationDto educationDto = new EducationDto();
                educationDto.IdEducation = education.IdEducation;
                educationDto.Tittle = education.Tittle;
                educationDto.EducationDescription = education.EducationDescription;
                educationDto.DateCompletionStudies = education.DateCompletionStudies;
                educationDto.IdApplicant = education.IdApplicant;

                educationDtoList.Add(educationDto);
            }

            return educationDtoList;

            //List<Education> educationList = await _context.Education
            //.Include(applicant => applicant.Applicant)
            //.Select(educationApplicant => new Education
            //{
            //    IdEducation = educationApplicant.IdEducation,
            //    Tittle = educationApplicant.Tittle,
            //    EducationDescription = educationApplicant.EducationDescription,
            //    DateCompletionStudies = educationApplicant.DateCompletionStudies,

            //    IdApplicant = educationApplicant.IdApplicant
            //}
            //).ToListAsync();

            //return educationList;
        }

        public async Task<List<EducationDtoGet>> GetById(int idApplicant)
        {

            var applicant1 = await _context.Applicants
           .Include(e => e.EducationList).FirstOrDefaultAsync(a => a.IdApplicant == idApplicant);

            List<EducationDtoGet> applicantListDtoGet = new List<EducationDtoGet>();

            if (applicant1 == null)
            {
                return null;
            }

            //foreach (Applicant applicant in applicantList)
            //{

            //    ApplicantDtoGet applicantDtoGet = new ApplicantDtoGet();

            //    foreach (Education education in applicant.EducationList)
            //    {
            //        EducationDtoGet educationDtoGet = new EducationDtoGet();
            //        educationDtoGet.IdEducation = education.IdEducation;
            //        educationDtoGet.Tittle = education.Tittle;
            //        educationDtoGet.EducationDescription = education.EducationDescription;
            //        educationDtoGet.DateCompletionStudies = education.DateCompletionStudies;

            //        applicantDtoGet.EducationList.Add(educationDtoGet);

            //    }

            //    applicantListDtoGet.Add(applicantDtoGet);
            //}

            //return applicantListDtoGet;

            foreach (Education education in applicant1.EducationList)
            {
                EducationDtoGet educationDtoGet = new EducationDtoGet();
                educationDtoGet.IdEducation = education.IdEducation;
                educationDtoGet.Tittle = education.Tittle;
                educationDtoGet.EducationDescription = education.EducationDescription;
                educationDtoGet.DateCompletionStudies = education.DateCompletionStudies;

                applicantListDtoGet.Add(educationDtoGet);

            }

            return applicantListDtoGet;

            //var education = await _context.Education.FindAsync(idEducation);

            //return education;

        }

        public async Task<EducationDto> GetById2(int id)
        {
            var education = await _context.Education
           .FirstOrDefaultAsync(c => c.IdApplicant == id);

            if (education == null)
            {
                return null;
            }

            EducationDto educationDto = new EducationDto();

            educationDto.IdEducation = education.IdEducation;
            educationDto.Tittle = education.Tittle;
            educationDto.EducationDescription = education.EducationDescription;
            educationDto.DateCompletionStudies = education.DateCompletionStudies;
            educationDto.IdApplicant = education.IdApplicant;

            return educationDto;

        }

        public async Task<Education> GetById3(int id)
        {
            var education = await _context.Education.FindAsync(id);

            return education;
        }

        public async Task<Education> Create(EducationDto educationDto)
        {
            Education education = new Education();
            education.IdEducation = educationDto.IdEducation;
            education.IdApplicant = educationDto.IdApplicant;
            education.Tittle = educationDto.Tittle;
            education.EducationDescription = educationDto.EducationDescription;
            education.DateCompletionStudies = educationDto.DateCompletionStudies;


            _context.Education.Add(education);
            await _context.SaveChangesAsync();

            return education;

        }

        public async Task Update(int idEducation, EducationDto educationDto)
        {
            Education education = await _context.Education.FindAsync(idEducation);
            education.Tittle = educationDto.Tittle;
            education.EducationDescription = educationDto.EducationDescription;
            education.DateCompletionStudies = educationDto.DateCompletionStudies;

            _context.Entry(education).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idEducation)
        {
            var education = await _context.Education.FindAsync(idEducation);

            _context.Education.Remove(education);
            await _context.SaveChangesAsync();
        }
    }
}
