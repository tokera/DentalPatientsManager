namespace DentalPatientsManager.Web.ViewModels.ToothStatus
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ToothStatusViewModel : IMapFrom<ToothStatus>, IHaveCustomMappings
    {
        public int ToothNumber { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Диагноза")]
        public string Diagnose { get; set; }

        [Display(Name = "Лечебен план")]
        public string TreatmentPlan { get; set; }

        [Display(Name = "Име на пациента")]
        public string PatientName { get; set; }

        [Display(Name = "Започване на лечение")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ToothStatus, ToothStatusViewModel>()
                .ForMember(x => x.PatientName, opt => opt.MapFrom(x => x.Patient.FirstName));
        }
    }
}