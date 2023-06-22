using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class OfferDtoGet
    {
        [Required]
        public int IdOffer { get; set; }
        [Required]
        public string OfferTittle { get; set; }

        [Required]
        public string OfferDescription { get; set; }

        [Required]
        public string Company { get; set; }

        public List<OfferSkillsDtoGet> offerSkillList { get; set; }

        public OfferDtoGet()
        {
            offerSkillList = new List<OfferSkillsDtoGet>();
        }
    }
}
