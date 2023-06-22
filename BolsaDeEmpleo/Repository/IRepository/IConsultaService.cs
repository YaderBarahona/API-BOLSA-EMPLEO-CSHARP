using BolsaDeEmpleo.Models.DtoGet;

namespace BolsaDeEmpleo.Repository.IRepository
{
    public interface IConsultaService 
    {
        public Task<List<ApplicantDtoGet>> Ver_potenciales_candidatos(int id);

        public Task<List<OfferDtoGet>> Ver_potenciales_ofertas(int id);
    }
}
