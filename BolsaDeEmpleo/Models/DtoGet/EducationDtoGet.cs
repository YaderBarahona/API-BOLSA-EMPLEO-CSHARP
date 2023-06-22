using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class EducationDtoGet
    {
        [Required]
        public int IdEducation { get; set; }

        [Required]
        public string Tittle { get; set; }

        [Required]
        public string EducationDescription { get; set; }

        [Required]
        public string DateCompletionStudies { get; set; }
    }
}
