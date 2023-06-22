using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class EducationDto
    {
        [Required]
        public int IdEducation { get; set; }

        [Required]
        public string Tittle { get; set; }

        [Required]
        public string EducationDescription { get; set; }

        [Required]
        public string DateCompletionStudies { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdApplicant { get; set; }
    }
}
