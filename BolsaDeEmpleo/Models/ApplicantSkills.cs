using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models
{
    public class ApplicantSkills
    {
        //dataanotation para indicar que la propiedad id sera la primary key de la tabla en la db
        [Key]
        //anotacion para indicar como queremos que se controle el id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdApplicantSkills { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdApplicant { get; set; }


        //[Required]
        //public string SkillDescription { get; set; }

        //relacion
        //propiedadc fk para la navegacion a la tabla relacionada 
        [ForeignKey("IdApplicant")]
        public Applicant Applicant { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdSkill { get; set; }

        //relacion
        //propiedadc fk para la navegacion a la tabla relacionada 
        [ForeignKey("IdSkill")]
        public Skill Skill { get; set; }


    }
}
