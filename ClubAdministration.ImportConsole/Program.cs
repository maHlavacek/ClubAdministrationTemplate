using ClubAdministration.Persistence;
using System;
using System.Linq;

namespace ClubAdministration.ImportConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Import der Sections und Members in die Datenbank");

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Console.WriteLine("Datenbank löschen");
                unitOfWork.DeleteDatabase();
                Console.WriteLine("Datenbank migrieren");
                unitOfWork.MigrateDatabase();
                Console.WriteLine("Members werden von members.csv eingelesen");
                var memberSections = ImportController.ReadFromCsv();
                if (memberSections.Length == 0)
                {
                    Console.WriteLine("!!! Es wurden keine Members eingelesen");
                    return;
                }

                Console.WriteLine($"  Es wurden {memberSections.GroupBy(ms => ms.Member).Count()} Members eingelesen");
                Console.WriteLine($"  Es wurden {memberSections.GroupBy(ms => ms.Section).Count()} Sections eingelesen");
                Console.WriteLine($"  Es wurden {memberSections.Count()} Mitgliedschaften eingelesen. Speichern in Datenbank ...");
                unitOfWork.MemberSectionRepository.AddRange(memberSections);
                int savedRows = unitOfWork.SaveChanges();
                Console.WriteLine($"{savedRows} Datensätze wurden in Datenbank gespeichert!");
                Console.WriteLine();
                Console.Write("Beenden mit Eingabetaste ...");
                Console.ReadLine();
            }
        }
    }
}
