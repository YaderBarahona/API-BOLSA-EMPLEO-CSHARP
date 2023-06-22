using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeEmpleo.Models
{
    public class Applicant
    {
        //dataanotation para indicar que la propiedad id sera la primary key de la tabla en la db
        [Key]
        //anotacion para indicar como queremos que se controle el id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdApplicant { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Resume { get; set; }

        //lISTAS / RELACIONES
        public List<Education> EducationList { get; set; }
        public List<ApplicantSkills> ApplicantSkillsList { get; set; }
        public List<OfferApplicants> OfferApplicantList { get; set; }

    }
}
