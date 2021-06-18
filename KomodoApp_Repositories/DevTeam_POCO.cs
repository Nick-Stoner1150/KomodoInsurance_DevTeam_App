using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoApp_Repositories
{
    public class DevTeam_POCO
    {
        public string TeamName { get; set; }
        public string TeamID { get; set; }
        public List<Developer_POCO> TeamMembers { get; set; } = new List<Developer_POCO>();

        public DevTeam_POCO()
        {
            
        }

        public DevTeam_POCO(string teamName, string teamID, List<Developer_POCO> teamMembers)
        {
            TeamName = teamName;
            TeamID = teamID;
            TeamMembers = teamMembers;
        }

        public DevTeam_POCO(string teamName, string teamID)
        {
            TeamName = teamName;
            TeamID = teamID;
        }

        // Helper Method 

        public void WriteTeams(DevTeam_POCO teams)
        {
            
             Console.WriteLine($"Team Name: {teams.TeamName}\n" +
                               $"Team ID: {teams.TeamID}\n");
             Console.WriteLine("Team Members:");
            
        }
    }   


}
