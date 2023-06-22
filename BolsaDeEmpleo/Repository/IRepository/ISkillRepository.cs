using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;

namespace BolsaDeEmpleo.Repository.IRepository
{

    public interface ISkillRepository 
    {
        public Task<List<SkillDto>> GetAll();

        //public Task<List<EducationDtoGet>> GetById(int id);

        public Task<Skill> GetById(int idSkill);

        public Task<SkillDto> GetById2(int id);

        public Task<Skill> Create(SkillDto skillDto);

        public Task Update(int idSkill, SkillDto skillDto);

        public Task Delete(int idSkill);
    }
}
