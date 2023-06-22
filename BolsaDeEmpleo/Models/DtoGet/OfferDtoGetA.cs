using BolsaDeEmpleo.Models.Dto;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class OfferDtoGetA
    {
        [Required]
        public int IdOffer { get; set; }
        [Required]
        public string OfferTittle { get; set; }

        [Required]
        public string OfferDescription { get; set; }

        [Required]
        public string Company { get; set; }

        public List<OfferSkillsDtoGet> OfferSkillList { get; set; }
        public List<ApplicantDto> ApplicantList { get; set; }

        public OfferDtoGetA()
        {
            OfferSkillList = new List<OfferSkillsDtoGet>();
            ApplicantList = new List<ApplicantDto>();
        }
    }
}
