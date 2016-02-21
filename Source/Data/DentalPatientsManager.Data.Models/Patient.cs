namespace DentalPatientsManager.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Patient : BaseModel<int>
    {
        private ICollection<ToothStatus> toothStatus;

        public Patient()
        {
            this.toothStatus = new HashSet<ToothStatus>();
        }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Tel { get; set; }

        [MaxLength(50)]
        public string Profession { get; set; }

        public string DoctorId { get; set; }

        public virtual ApplicationUser Doctor { get; set; }

        public virtual ICollection<ToothStatus> ToothStatus { get; set; }

    }
}
