using BolsaDeEmpleo.Data;
using BolsaDeEmpleo.Models;
using BolsaDeEmpleo.Models.Dto;
using BolsaDeEmpleo.Models.DtoGet;
using BolsaDeEmpleo.Repositorio;
using BolsaDeEmpleo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BolsaDeEmpleo.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<List<CompanyDtoGet>> GetAll()
        {
            List<Company> companyList = await _context.Companies
           .Include(o => o.OfferList)
           .ToListAsync();

            List<CompanyDtoGet> companyListDtoGet = new List<CompanyDtoGet>();

            foreach (Company company in companyList)
            {
                CompanyDtoGet companyDtoGet = new CompanyDtoGet();

                companyDtoGet.IdCompany = company.IdCompany;
                companyDtoGet.NameCompany = company.NameCompany;

                foreach (Offer oferta in company.OfferList)
                {
                    OfferDto offerDto = new OfferDto();
                    offerDto.IdOffer = oferta.IdOffer;
                    offerDto.OfferTittle = oferta.OfferTittle;
                    offerDto.OfferDescription = oferta.OfferDescription;
                    offerDto.IdCompany = companyDtoGet.IdCompany;

                    companyDtoGet.offerList.Add(offerDto);

                }

                companyListDtoGet.Add(companyDtoGet);
            }

            return companyListDtoGet;



            //List<Company> CompanyList = await _context.Companies
            //.Include(company => company.OfferList)
            //.Select(company => new Company
            //{
            //    IdCompany = company.IdCompany,
            //    NameCompany = company.NameCompany,
            //    EmailCompany = company.EmailCompany,
            //    PhoneNumberCompany = company.PhoneNumberCompany,
            //    DescriptionCompany = company.DescriptionCompany,
            //    WebCompany = company.WebCompany,
            //    OfferList = company.OfferList.Select(company => new Offer
            //    {
            //        DescriptionOffer = company.DescriptionOffer,
            //        OfferSkillsList = company.OfferSkillsList,
            //        OfferApplicantsList = company.OfferApplicantsList

            //    }).ToList(),
            //}).ToListAsync();

            //return CompanyList;
        }

        public async Task<CompanyDtoGet> GetById(int idCompany)
        {

            var company = await _context.Companies
            .Include(c => c.OfferList)
            .FirstOrDefaultAsync(c => c.IdCompany == idCompany);

            if (company == null)
            {
                return null;
            }

            CompanyDtoGet companyDto = new CompanyDtoGet();

            companyDto.IdCompany = company.IdCompany;
            companyDto.NameCompany = company.NameCompany;

            foreach (Offer offer in company.OfferList)
            {
                OfferDto offerDto = new OfferDto();
                offerDto.IdOffer = offer.IdOffer;
                offerDto.OfferTittle = offer.OfferTittle;
                offerDto.OfferDescription = offer.OfferDescription;
                offerDto.IdCompany = companyDto.IdCompany;

                companyDto.offerList.Add(offerDto);

            }

            return companyDto;

            // var company = await _context.Companies
            //.Include(company => company.OfferList)
            //.FirstOrDefaultAsync(company => company.IdCompany == idCompany);

            // return company;
        }

        public async Task<Company> Create(CompanyDto companyDto)
        {
            Company company = new Company();
            company.IdCompany = companyDto.IdCompany; 
            company.NameCompany = companyDto.NameCompany;

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;

        }

        public async Task Update(int idCompany, CompanyDto companyDto)
        {
            Company companyUpdate = await _context.Companies.FindAsync(idCompany);

            companyUpdate.NameCompany = companyDto.NameCompany;

            _context.Entry(companyUpdate).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int idCompany)
        {
            var company = await _context.Companies.FindAsync(idCompany);

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}
