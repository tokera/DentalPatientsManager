namespace DentalPatientsManager.Services.Data
{
    using System;
    using System.Linq;
    using DentalPatientsManager.Data.Common;
    using DentalPatientsManager.Data.Models;

    public class ToothStatusServices : IToothStatusServices
    {
        private readonly IDbRepository<ToothStatus> toothStatus;

        public ToothStatusServices(IDbRepository<ToothStatus> toothStatus)
        {
            this.toothStatus = toothStatus;
        }

        public void Add(ToothStatus toothStatus)
        {
            this.toothStatus.Add(toothStatus);
            this.toothStatus.Save();
        }

        public int ExistsToothStatus(int number, int patientId)
        {
            var toothStatus = this.toothStatus.All().Where(x => x.ToothNumber == number && x.PatientId == patientId).FirstOrDefault();

            if (toothStatus == null)
            {
                return 0;
            }

            return toothStatus.Id;
        }

        public IQueryable<ToothStatus> GetAllByPatientId(int patientId)
        {
            return this.toothStatus.All().Where(x => x.PatientId == patientId);
        }

        public ToothStatus GetById(int id)
        {
            return this.toothStatus.GetById(id);
        }
    }
}
