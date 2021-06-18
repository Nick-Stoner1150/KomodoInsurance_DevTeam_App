using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoApp_Repositories
{
    public class DevTeam_Repository
    {
        private List<DevTeam_POCO> _listOfDevTeams = new List<DevTeam_POCO>();

        //Create 
        public void AddTeamToList(DevTeam_POCO devteams)
        {
            _listOfDevTeams.Add(devteams);
        }


        // Read 
        public List<DevTeam_POCO> ShowDevTeams()
        {
            return _listOfDevTeams;

        }

        public DevTeam_POCO GetTeamByTeamID(string teamID)
        {
            foreach (var content in _listOfDevTeams)
            {
                if (content.TeamID == teamID)
                {
                    return content;
                }
            }

            return null;
        }

        public void PrintTeamMembers(string memberList, string members)
        {
            Developer_POCO developer = new Developer_POCO();
            DevTeam_POCO devTeam = new DevTeam_POCO();

            foreach (var content in devTeam.TeamMembers)
            {
                Console.WriteLine($"{developer.FirstName} {developer.LastName}\n" +
                                     $"{developer.IdNumber}\n" +
                                     $"{developer.HasAccessToPluralsign}");
            }
        }
    }
}
