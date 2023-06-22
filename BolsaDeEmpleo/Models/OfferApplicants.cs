using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolsaDeEmpleo.Models
{
    public class OfferApplicants
    {
        //dataanotation para indicar que la propiedad id sera la primary key de la tabla en la db
        [Key]
        //anotacion para indicar como queremos que se controle el id 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOfferApplicants { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdOffer { get; set; }

        //relacion
        //propiedadc fk para la navegacion a la tabla relacionada 
        [ForeignKey("IdOffer")]
        public Offer Offer { get; set; }

        //propiedad IdApplicant para la relacion con applicant
        [Required]
        public int IdApplicant { get; set; }

        //relacion
        //propiedadc fk para la navegacion a la tabla relacionada 
        [ForeignKey("IdApplicant")]
        public Applicant Applicant { get; set; }


    }
}
