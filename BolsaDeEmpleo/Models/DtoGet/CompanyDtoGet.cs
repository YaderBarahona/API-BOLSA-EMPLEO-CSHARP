using BolsaDeEmpleo.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class CompanyDtoGet
    {
        [Required]
        public int IdCompany { get; set; }

        [Required]
        public string NameCompany { get; set; }

        public List<OfferDto> offerList { get; set; }

        public CompanyDtoGet()
        {
            offerList = new List<OfferDto>();
        }
    }
}
