using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class ApplicantDto
    {
        [Required]
        public int IdApplicant { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Resume { get; set; }
    }
}
