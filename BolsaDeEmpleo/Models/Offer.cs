using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeEmpleo.Models
{
    public class Offer
    {
        //dataanotation para indicar que la propiedad id sera la primary key de la tabla en la db
        [Key]
        //anotacion para indicar como queremos que se controle el id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOffer { get; set; }

        [Required]
        public string OfferTittle { get; set; }

        [Required]
        public string OfferDescription { get; set; }

        //propiedad IdCompany para la relacion con Offer
        [Required]
        public int IdCompany { get; set; }
        
        //propiedadc fk para la navegacion a la tabla relacionada 
        [ForeignKey("IdCompany")]
        public Company Company { get; set; }

        //listas / relaciones
        public List<OfferSkills> OfferSkillsList { get; set; }
        public List<OfferApplicants> OfferApplicantsList { get; set; }

        public Offer()
        {
            OfferSkillsList = new List<OfferSkills>();

        }

    }
}
