using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class OfferApplicantsDto
    {
        [Required]
        public int IdOfferApplicants { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdOffer { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdApplicant { get; set; }
    }
}
