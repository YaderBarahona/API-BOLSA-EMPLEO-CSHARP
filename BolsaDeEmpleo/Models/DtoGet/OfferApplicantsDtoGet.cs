using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class OfferApplicantsDtoGet
    {
        [Required]
        public int IdOfferApplicants { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdOffer { get; set; }

        [Required]
        public int IdCompany { get; set; }

        [Required]
        public string OfferDescription { get; set; }

    }
}
