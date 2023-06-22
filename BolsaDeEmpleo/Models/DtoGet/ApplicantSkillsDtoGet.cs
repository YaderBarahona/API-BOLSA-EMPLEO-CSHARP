using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class ApplicantSkillsDtoGet
    {

        [Required]
        public int IdApplicantSkills { get; set; }

        [Required]
        public string SkillDescription { get; set;}
    }
}
