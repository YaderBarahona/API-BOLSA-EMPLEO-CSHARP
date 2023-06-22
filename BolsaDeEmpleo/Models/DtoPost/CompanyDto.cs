using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.Dto
{
    public class CompanyDto
    {
        [Required]
        public int IdCompany { get; set; }

        [Required]
        public string NameCompany { get; set; }
    }
}
