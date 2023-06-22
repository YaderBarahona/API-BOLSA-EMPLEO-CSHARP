using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repositorio;
using System.Threading.Tasks;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface IOfferSkillsRepository 
    {
        public Task<List<OfferSkillsDto>> GetAll();

        public Task<OfferSkills> GetById(int idOffer, int idSkill);

        public Task<OfferSkills> Create(OfferSkillsDto offerSkillsDto);

        public Task Update(int id, OfferSkillsDto offerSkillsDto);

        public Task Delete(int idOffer, int idSkill);

 
    }
}
