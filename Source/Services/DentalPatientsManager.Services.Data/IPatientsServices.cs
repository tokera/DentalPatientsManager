namespace DentalPatientsManager.Services.Data
{
    using System.Linq;
    using DentalPatientsManager.Data.Models;

    public interface IPatientsServices
    {
        void Create(Patient patient);

        IQueryable<Patient> GetAll(string sortBy, string search, string userId);

        Patient GetById(int id);
    }
}
