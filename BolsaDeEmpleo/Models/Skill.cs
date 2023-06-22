using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeEmpleo.Models
{
    public class Skill
    {  
        //dataanotation para indicar que la propiedad id sera la primary key de la tabla en la db
        [Key]
        //anotacion para indicar como queremos que se controle el id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSkill { get; set; }

        [Required]
        public string SkillDescription { get; set; }

        public List<ApplicantSkills> ApplicantSkillsList { get; set; }

        public List<OfferSkills> OfferSkillsList { get; set; }
    }
}
