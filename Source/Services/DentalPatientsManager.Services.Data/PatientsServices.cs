namespace DentalPatientsManager.Services.Data
{
    using System;
    using System.Linq;
    using DentalPatientsManager.Data.Common;
    using DentalPatientsManager.Data.Models;

    public class PatientsServices : IPatientsServices
    {
        private readonly IDbRepository<Patient> patients;

        public PatientsServices(IDbRepository<Patient> patients)
        {
            this.patients = patients;
        }

        public void Create(Patient patient)
        {
            this.patients.Add(patient);
            this.patients.Save();
        }

        public IQueryable<Patient> GetAll()
        {
            return this.patients.All().OrderByDescending(p => p.CreatedOn);
        }
    }
}
