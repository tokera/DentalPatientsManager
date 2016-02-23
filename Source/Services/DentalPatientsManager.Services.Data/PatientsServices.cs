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

        public IQueryable<Patient> GetAll(string sortBy, string search, string userId)
        {
            switch (sortBy)
            {
                case "date": return this.patients.All()
                        .Where(p => p.DoctorId == userId)
                        .Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search))
                        .OrderByDescending(p => p.CreatedOn);
                    break;

                case "name":
                    return this.patients.All()
                        .Where(p => p.DoctorId == userId)
                        .Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search))
                        .OrderBy(p => p.FirstName).ThenBy(p => p.LastName);
                    break;

                default: return this.patients.All();
                    break;
            }
        }

        public Patient GetById(int id)
        {
            return this.patients.GetById(id);
        }
    }
}
