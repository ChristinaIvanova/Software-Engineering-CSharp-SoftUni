using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Bed
    {
        public Bed(Patient patient, Doctor doctor)
        {
            this.Patient = patient;
            this.Doctor = doctor;
        }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }
    }
}
