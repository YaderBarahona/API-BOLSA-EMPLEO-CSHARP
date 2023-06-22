using BolsaDeEmpleo.Models.Dto;
using System.ComponentModel.DataAnnotations;

namespace BolsaDeEmpleo.Models.DtoGet
{
    public class ApplicantDtoGet
    {
        [Required]
        public int IdApplicant { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Resume { get; set; }

        public List<EducationDtoGet> EducationList { get; set; }
        public List<ApplicantSkillsDtoGet> ApplicantSkillsList { get; set; }
        public List<OfferApplicantsDtoGet> OfferApplicantList { get; set; }

        public ApplicantDtoGet()
        {
            EducationList = new List<EducationDtoGet>();
            ApplicantSkillsList = new List<ApplicantSkillsDtoGet>();
            OfferApplicantList = new List<OfferApplicantsDtoGet>();
        }
    }

}
