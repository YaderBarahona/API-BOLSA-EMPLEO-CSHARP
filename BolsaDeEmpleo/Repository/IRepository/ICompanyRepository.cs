using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface ICompanyRepository 
    {
        public Task<List<CompanyDtoGet>> GetAll();

        public Task<CompanyDtoGet> GetById(int id);

        public Task<Company> Create(CompanyDto applicantDto);

        public Task Update(int id, CompanyDto applicantDto);

        public Task Delete(int id);
    }
}
