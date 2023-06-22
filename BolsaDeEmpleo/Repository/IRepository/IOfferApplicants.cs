using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface IOfferApplicants 
    {
        public Task<List<OfferApplicantsDto>> GetAll();

        public Task<OfferApplicants> GetById(int idApplicant, int idOffer);

        public Task<OfferApplicants> Create(OfferApplicantsDto applicantDto);

        public Task Update(int id, OfferApplicantsDto applicantDto);

        public Task Delete(int idApplicant, int idOffer);
    }
}
