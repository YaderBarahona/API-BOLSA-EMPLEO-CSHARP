using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class SkillDto
    {
        [Required]
        public int IdSkill { get; set; }

        [Required]
        public string SkillDescription { get; set; }
    }
}
