namespace DentalPatientsManager.Web.ViewModels.Patient
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PatientInputViewModel : IMapFrom<Patient>
    {
        [Required]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Години")]
        public int Age { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        public string Tel { get; set; }

        [Display(Name = "Професия")]
        public string Profession { get; set; }

    }
}