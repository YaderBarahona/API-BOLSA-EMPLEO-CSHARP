using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Repositorio;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BolsaDeEmpleo.Repository
{
    public class OfferApplicantsRepository : IOfferApplicants
    {
        private readonly ApplicationDbContext _context;

        public OfferApplicantsRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<OfferApplicantsDto>> GetAll()
        {
            List<OfferApplicants> offerApplicantsList = await _context.OfferApplicants.ToListAsync();

            List<OfferApplicantsDto> offerApplicantsListDto = new List<OfferApplicantsDto>();

            foreach (OfferApplicants offerApplicants in offerApplicantsList)
            {
                OfferApplicantsDto OfferApplicantsListDto = new OfferApplicantsDto();
                OfferApplicantsListDto.IdOfferApplicants = offerApplicants.IdOfferApplicants;
                OfferApplicantsListDto.IdApplicant = offerApplicants.IdApplicant;
                OfferApplicantsListDto.IdOffer = offerApplicants.IdOffer;
                offerApplicantsListDto.Add(OfferApplicantsListDto);
            }

            return offerApplicantsListDto;
        }

        public async Task<OfferApplicants> GetById(int idApplicant, int idOffer)
        {
            OfferApplicants offerApplicants = new OfferApplicants();
            offerApplicants = _context.OfferApplicants.SingleOrDefault(offerAplicant => offerAplicant.IdApplicant == idApplicant && offerAplicant.IdOffer == idOffer);

            return offerApplicants;
        }

        public async Task<OfferApplicants> Create(OfferApplicantsDto offerApplicantsDto)
        {
            OfferApplicants offerApplicants = new OfferApplicants();
            offerApplicants.IdOfferApplicants = offerApplicantsDto.IdOfferApplicants; 
            offerApplicants.IdApplicant = offerApplicantsDto.IdApplicant;
            offerApplicants.IdOffer = offerApplicantsDto.IdOffer;

            _context.OfferApplicants.Add(offerApplicants);
            await _context.SaveChangesAsync();

            return offerApplicants;

        }

        public async Task Update(int idOfferApplicant, OfferApplicantsDto offerApplicantsDto)
        {
            OfferApplicants offerApplicants = await _context.OfferApplicants.FindAsync(idOfferApplicant);

            offerApplicants.IdApplicant = offerApplicantsDto.IdApplicant;
            offerApplicants.IdOffer = offerApplicantsDto.IdOffer;

            _context.Entry(offerApplicants).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idApplicant, int idOffer)
        {
            OfferApplicants offerApplicants = new OfferApplicants();
            offerApplicants = _context.OfferApplicants.SingleOrDefault(offerAplicant => offerAplicant.IdApplicant == idApplicant && offerAplicant.IdOffer == idOffer);

            _context.OfferApplicants.Remove(offerApplicants);
            await _context.SaveChangesAsync();
        }
    }
}
