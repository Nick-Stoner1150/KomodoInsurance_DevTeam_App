using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoApp_Repositories
{
    public class Developer_Repository
    {
        private List<Developer_POCO> _listOfDevelopers = new List<Developer_POCO>();
        // Create

        public void AddDeveloperToList(Developer_POCO developer)
        {
            _listOfDevelopers.Add(developer);
        }


        // Read
        public List<Developer_POCO> ShowDeveloperList()
        {
            return _listOfDevelopers;
        }

        // Update

        // Delete



        // Helper Method 
        public Developer_POCO GetDeveloperByID(string idNumber)
        {
            foreach (var content in _listOfDevelopers)
            {
                if (content.IdNumber == idNumber)
                {
                    return content;
                }
            }

            return null;
        }

    }



}
