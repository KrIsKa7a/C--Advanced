using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var doctorPatients = new Dictionary<string, List<string>>();
            var departmentPatients = new Dictionary<string, List<string>>();

            FillDictionaryWithInfoAboutHospital(doctorPatients, departmentPatients);

            var input = Console.ReadLine();

            while (input != "End")
            {
                var inputArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 1)
                {
                    var department = inputArgs[0];
                    PrintPatientsInWantedDepartment(department, departmentPatients);
                }
                else if(inputArgs.Length == 2)
                {
                    var secondWord = inputArgs[1];

                    int room;
                    bool hasParsed = int.TryParse(secondWord, out room);

                    if (hasParsed)
                    {
                        var department = inputArgs[0];
                        PrintPatientsInWantedRoom(department, room, departmentPatients);
                    }
                    else
                    {
                        PrintPatientsOfADoctor(doctorPatients, inputArgs);
                    }
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintPatientsOfADoctor(Dictionary<string, List<string>> dict, string[] inputArgs)
        {
            var doctorFirstName = inputArgs[0];
            var doctorSurname = inputArgs[1];
            var doctorName = doctorFirstName + " " + doctorSurname;
            var doctorPatients = dict[doctorName];

            doctorPatients = doctorPatients
                .OrderBy(p => p)
                .ToList();

            foreach (var patient in doctorPatients)
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPatientsInWantedRoom(string department, int room, Dictionary<string, List<string>> departmentPatients)
        {
            var patientsInWantedDepartment = departmentPatients[department];
            var patientsInWantedRoom = patientsInWantedDepartment
                .Skip((room - 1) * 3)
                .Take(3)
                .OrderBy(p => p)
                .ToList();

            foreach (var patient in patientsInWantedRoom)
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintPatientsInWantedDepartment(string department, Dictionary<string, List<string>> departmentPatients)
        {
            var wantedPatients = departmentPatients[department];

            foreach (var patient in wantedPatients)
            {
                Console.WriteLine(patient);
            }
        }

        private static void FillDictionaryWithInfoAboutHospital(
            Dictionary<string, List<string>> doctorPatients,
            Dictionary<string, List<string>> departmentWithPatients)
        {
            var input = Console.ReadLine();

            while (input != "Output")
            {
                var inputArgs = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var department = inputArgs[0];
                var doctorName = inputArgs[1] + " " + inputArgs[2];
                var patient = inputArgs[3];

                if (!doctorPatients.ContainsKey(doctorName))
                {
                    doctorPatients[doctorName] = new List<string>();
                }

                if (!departmentWithPatients.ContainsKey(department))
                {
                    departmentWithPatients[department] = new List<string>();
                }

                departmentWithPatients[department].Add(patient);
                doctorPatients[doctorName].Add(patient);

                input = Console.ReadLine();
            }

        }
    }
}
