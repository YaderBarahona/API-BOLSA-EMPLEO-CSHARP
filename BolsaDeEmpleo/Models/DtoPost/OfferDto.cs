using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class OfferDto
    {
        [Required]
        public int IdOffer { get; set; }
        [Required]
        public string OfferTittle { get; set; }

        [Required]
        public string OfferDescription { get; set; }

        //propiedad IdCompany para la relacion con Offer
        [Required]
        public int IdCompany { get; set; }

    }
}
