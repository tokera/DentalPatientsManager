namespace DentalPatientsManager.Web.ViewModels.Patient
{
    using System;
    using AutoMapper;
    using DentalPatientsManager.Data.Models;
    using DentalPatientsManager.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    public class PatientDetailsViewModel : IMapFrom<Patient>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string Tel { get; set; }

        public string Profession { get; set; }

        public ICollection<ToothStatus> ToothStatus { get; set; }
    }
}