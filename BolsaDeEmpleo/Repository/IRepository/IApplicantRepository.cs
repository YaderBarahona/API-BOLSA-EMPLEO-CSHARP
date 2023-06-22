using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface IApplicantRepository 
    {
        public Task<List<ApplicantDtoGet>> GetAll();

        public Task<ApplicantDtoGet> GetById(int id);

        public Task<Applicant> Create(ApplicantDto applicantDto);

        public Task Update(int id, ApplicantDto applicantDto);

        public Task Delete(int id);

    }
}
