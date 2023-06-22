using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class OfferSkillsDtoGet
    {
        [Required]
        public int IdOfferSkills { get; set; }

        [Required]
        public string SkillDescription { get; set; }
    }
}
