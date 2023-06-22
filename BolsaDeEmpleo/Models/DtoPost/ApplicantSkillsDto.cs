using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class ApplicantSkillsDto
    {
        [Required]
        public int IdApplicantSkills { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdApplicant { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdSkill { get; set; }

    }
}
