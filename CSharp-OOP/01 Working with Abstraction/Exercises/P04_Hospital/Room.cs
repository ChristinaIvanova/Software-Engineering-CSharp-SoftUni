using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        private const int capacity = 3;

        public Room()
        {
            this.Beds = new List<Bed>();
        }

        public List<Bed> Beds { get; set; }

        public bool isFull => this.Beds.Count >= capacity;

        public void AddBedToRoom(Bed bed)
        {
            if (this.Beds.Count < capacity)
            {
                this.Beds.Add(bed);
            }
        }

        public List<string> GetPatientsOfRoom()
        {
            return this.Beds.Select(p => p.Patient.Name).ToList();
        }
    }
}
