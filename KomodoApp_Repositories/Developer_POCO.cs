using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoApp_Repositories
{
    public class Developer_POCO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public bool HasAccessToPluralsign { get; set; }

        public Developer_POCO()
        {

        }

        public Developer_POCO(string firstName, string lastName, string idNumber, bool hasAccessToPluralsign)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            HasAccessToPluralsign = hasAccessToPluralsign;
        }

        public void WriteDeveloperInfo(Developer_POCO developer)
        {
            Console.WriteLine($"Name: {developer.FirstName} {developer.LastName}\n" +
                                  $"ID #: {developer.IdNumber}\n" +
                                  $"Has Access to Pluralsign: {developer.HasAccessToPluralsign}");
            Console.WriteLine("-----------------------------\n");
        }
    }

}
