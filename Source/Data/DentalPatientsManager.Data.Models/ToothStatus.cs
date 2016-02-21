namespace DentalPatientsManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class ToothStatus : BaseModel<int>
    {
        [Required]
        public int ToothNumber { get; set; }

        public string Diagnose { get; set; }

        public string TreatmentPlan { get; set; }

        public int PacientId { get; set; }

        public virtual Patient Pacient { get; set; }
    }
}
