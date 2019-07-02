using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Hospital
    {
        private List<Department> departments;

        public Hospital()
        {
            this.departments = new List<Department>();
        }

        public void AddDepartment(Department department, Patient patient, Doctor doctor)
        {
            Bed bed = new Bed(patient, doctor);

            Department existing = this.departments.FirstOrDefault(x => x.Name == department.Name);
            
            if (existing == null)
            {
                department.AddBedToRoom(bed);
                this.departments.Add(department);
            }
            else
            {
                existing.AddBedToRoom(bed);
            }
        }

        public List<string> GetPatientsOfDepartment(string departmentName)
        {
            Department department = this.departments.FirstOrDefault(d => d.Name == departmentName);

            return department.Rooms.SelectMany(r => r.GetPatientsOfRoom()).ToList();
        }

        public List<string> GetPatientsInRoom(string departmentName, int index)
        {
            Department department = this.departments.FirstOrDefault(d => d.Name == departmentName);
            List<Room> roomsInDepartment = department.Rooms;

            return roomsInDepartment[index].GetPatientsOfRoom();
        }

        public List<string> GetPatientsByDoctor(string doctorName)
        {
            List<Room> allRooms = this.departments.SelectMany(r => r.Rooms).ToList();
            
            List<Bed> allBeds = allRooms.SelectMany(b => b.Beds.Where(d => d.Doctor.Name == doctorName)).ToList();

            return allBeds.Select(p => p.Patient.Name).ToList();
        }
    }
}
