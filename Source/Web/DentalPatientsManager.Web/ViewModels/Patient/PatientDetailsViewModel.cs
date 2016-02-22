namespace DentalPatientsManager.Web.ViewModels.Patient
{
    using System;
    using AutoMapper;
    using DentalPatientsManager.Data.Models;
    using DentalPatientsManager.Web.Infrastructure.Mapping;

    public class PatientDetailsViewModel : IMapFrom<Patient>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

    }
}