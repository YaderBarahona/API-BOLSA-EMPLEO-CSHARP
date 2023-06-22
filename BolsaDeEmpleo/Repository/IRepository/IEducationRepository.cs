using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface IEducationRepository 
    {
        public Task<List<EducationDto>> GetAll();

        public Task<List<EducationDtoGet>> GetById(int id);

        public Task<EducationDto> GetById2(int id);

        public Task<Education> GetById3(int id);

        public Task<Education> Create(EducationDto educationDto);

        public Task Update(int id, EducationDto educationDto);

        public Task Delete(int id);
    }
}
