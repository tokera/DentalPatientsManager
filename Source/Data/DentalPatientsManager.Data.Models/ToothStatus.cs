namespace DentalPatientsManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class ToothStatus : BaseModel<int>
    {
        public int ToothNumber { get; set; }

        [MaxLength(1)]
        public string Status { get; set; }

        [MaxLength(50)]
        public string Diagnose { get; set; }

        [MaxLength(50)]
        public string TreatmentPlan { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
