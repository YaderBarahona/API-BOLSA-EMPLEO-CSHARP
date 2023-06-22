using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface IOfferRepository 
    {

        public Task<List<OfferDtoGet>> GetAll();

        //public Task<OfferDtoGet> GetById(int id);

        public Task<OfferDtoGetA> GetById(int id);

        public Task<Offer> Create(OfferDto applicantDto);

        public Task Update(int id, OfferDto applicantDto);

        public Task Delete(int id);

    }
}
