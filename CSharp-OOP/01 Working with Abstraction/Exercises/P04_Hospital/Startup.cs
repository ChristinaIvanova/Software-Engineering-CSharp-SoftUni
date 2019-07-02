using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Hospital hospital = new Hospital();

            var command = Console.ReadLine();

            while (command != "Output")
            {
                var patientArgs = command.Split(" ");

                var departamentName = patientArgs[0];
                var doctorName = patientArgs[1] + patientArgs[2];
                var patientName = patientArgs[3];

                Doctor doctor = new Doctor(doctorName);
                Patient patient = new Patient(patientName);
                Department department = new Department(departamentName);

                hospital.AddDepartment(department, patient, doctor);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var commandArgs = command.Split();

                PrintPatients(hospital, commandArgs);

                command = Console.ReadLine();
            }
        }

        private static void PrintPatients(Hospital hospital, string[] commandArgs)
        {
            var patientsResult = new List<string>();

            if (commandArgs.Length == 1)
            {
                var currentDepartment = commandArgs[0];

                patientsResult = hospital.GetPatientsOfDepartment(currentDepartment);
            }
            else if (commandArgs.Length == 2 && int.TryParse(commandArgs[1], out int room))
            {
                var currentDepartment = commandArgs[0];

                patientsResult = hospital.GetPatientsInRoom(currentDepartment, room - 1)
                    .OrderBy(p => p)
                    .ToList();
            }
            else
            {
                var currentDoctor = commandArgs[0] + commandArgs[1];

                patientsResult = hospital.GetPatientsByDoctor(currentDoctor)
                    .OrderBy(p => p)
                    .ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, patientsResult));
        }
    }
}
