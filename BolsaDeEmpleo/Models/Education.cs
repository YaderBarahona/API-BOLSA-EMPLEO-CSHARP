using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models
{
    public class Education
    {
        //dataanotation para indicar que la propiedad id sera la primary key de la tabla en la db
        [Key]
        //anotacion para indicar como queremos que se controle el id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEducation { get; set; }


        [Required]
        public string Tittle { get; set; }

        [Required]
        public string EducationDescription { get; set; }

        public string DateCompletionStudies { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdApplicant { get; set; }

        //relacion
        //propiedadc fk para la navegacion a la tabla relacionada 
        [ForeignKey("IdApplicant")]
        public Applicant Applicant { get; set; }
    }
}
