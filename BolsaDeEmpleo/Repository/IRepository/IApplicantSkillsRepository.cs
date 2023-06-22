using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repositorio;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface IApplicantSkillsRepository 
    {
        public Task<List<ApplicantSkillsDto>> GetAll();

        public Task<ApplicantSkills> GetById(int idApplicant, int idSkill);

        public Task<ApplicantSkills> Create(ApplicantSkillsDto applicantDto);

        public Task Update(int id, ApplicantSkillsDto applicantDto);

        public Task Delete(int idApplicant, int idSkill);



    }
}
