using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }

        [Column(TypeName = "DATETIME2")]
        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
