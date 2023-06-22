using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class OfferSkillsDto
    {
        [Required]
        public int IdOfferSkills { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdOffer { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdSkill { get; set; }
    }
}
