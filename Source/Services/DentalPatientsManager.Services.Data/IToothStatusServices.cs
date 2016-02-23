namespace DentalPatientsManager.Services.Data
{
    using System.Linq;
    using DentalPatientsManager.Data.Models;

    public interface IToothStatusServices
    {
        void Add(ToothStatus toothStatus);

        int ExistsToothStatus(int number, int patientId);

        ToothStatus GetById(int id);

        IQueryable<ToothStatus> GetAllByPatientId(int patientId);
    }
}
