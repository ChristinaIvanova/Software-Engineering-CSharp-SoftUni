using System;

namespace Mankind
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                var studentArgs = Console.ReadLine().Split();

                var firstNameStudent = studentArgs[0];
                var secondNameStudent = studentArgs[1];
                var facultyNmber = studentArgs[2];

                var student = new Student(firstNameStudent, secondNameStudent, facultyNmber);
               

                var workerArgs = Console.ReadLine().Split();

                var firstNameWorker = workerArgs[0];
                var secondNameWorker = workerArgs[1];
                var weekSalary = double.Parse(workerArgs[2]);
                var workingHours = double.Parse(workerArgs[3]);

                var worker = new Worker(firstNameWorker, secondNameWorker, weekSalary, workingHours);

                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(worker.ToString());
                
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }
    }
}
