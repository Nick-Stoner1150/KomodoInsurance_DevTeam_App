using KomodoApp_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoApp_Console
{
    class ProgramUI
    {
        private Developer_Repository _developerRepo = new Developer_Repository();
        private DevTeam_Repository _devTeamRepo = new DevTeam_Repository();

        // Method that runs/starts the application
        public void Run()
        {
            SeedDeveloperList();
            SeedTeamList();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                // Dispay Options To The User
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create a new developer:\n" +
                    "2. Create a new team\n" +
                    "3. Assign a developer to a team\n" +
                    "4. View all developers\n" +
                    "5. View all teams\n" +
                    "6. Remove a developer from a team\n" +
                    "7. Show Developers without Pluralsign License\n" +
                    "8. Exit");

                // Get User Input
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Create new developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        // Create a new team
                        CreateNewTeam();
                        break;
                    case "3":
                        // Assign developer to a team
                        AssignDeveloperToTeam();
                        break;
                    case "4":
                        ShowDevelopers();
                        break;
                    case "5":
                        ShowListOfTeams();
                        break;
                    case "6":
                        RemoveADeveloperFromATeam();
                        break;
                    case "7":
                        ShowDevelopersWithOutLicense();
                        break;
                    case "8":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number!");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        // Create new developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Developer first name:");
            var developerFirstName = Console.ReadLine();

            Console.WriteLine("Developer last name:");
            var developerLastName = Console.ReadLine();

            Console.WriteLine("Developer ID#:");
            var developerID = Console.ReadLine();

            Console.WriteLine("Has access to Pluralsign? (y/n):");
            string pluralsignString = Console.ReadLine().ToLower();
            bool hasAccessToPluralsign; 

            if(pluralsignString == "y")
            {
                 hasAccessToPluralsign = true;
            }
            else
            {
                 hasAccessToPluralsign = false;
            }

            Developer_POCO newDeveloper = new Developer_POCO(developerFirstName, developerLastName, developerID, hasAccessToPluralsign);
            _developerRepo.AddDeveloperToList(newDeveloper);

        }
        private void CreateNewTeam()
        {
            Console.Clear();

            Console.WriteLine("Team Name:");
            var teamName = Console.ReadLine();

            Console.WriteLine("Please enter Team ID:");
            var teamID = Console.ReadLine();

            DevTeam_POCO newTeam = new DevTeam_POCO(teamName, teamID);
            _devTeamRepo.AddTeamToList(newTeam);
        }
        private void AssignDeveloperToTeam()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ShowDevelopers();
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Enter a developer ID# to place them on a team:");
                string idNumber = Console.ReadLine();
                Developer_POCO developer = _developerRepo.GetDeveloperByID(idNumber);

                if (developer != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("You Chose:\n" +
                                       "-----------");
                    developer.WriteDeveloperInfo(developer);
                    Console.WriteLine("-----------------------\n");

                    Console.WriteLine("Choose a team...");
                    ShowListOfTeams();
                    Console.WriteLine("Enter the team ID you would like to assign them to:");
                    string teamID = Console.ReadLine();
                    Console.WriteLine();
                    DevTeam_POCO devTeam = _devTeamRepo.GetTeamByTeamID(teamID);

                    if (devTeam != null)
                    {
                        devTeam.TeamMembers.Add(developer);

                        Console.WriteLine($"{developer.FirstName} {developer.LastName} was successfully added to {devTeam.TeamName}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("There is no team with that team ID... ");
                        isRunning = true;
                    }
                }
                else
                {
                    Console.WriteLine("No developer by that ID...");
                    isRunning = true;
                }
                Console.WriteLine("To assign a developer presse 'A', to exit press anything else...");
                string userInput = Console.ReadLine().ToLower();
                if (userInput == "a")
                {
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                }
            }
        }
        private void RemoveADeveloperFromATeam()
        {
            ShowDevelopers();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Enter a developer ID# to place them on a team:");
            // Display that person only 
            string idNumber = Console.ReadLine();
            Developer_POCO developer = _developerRepo.GetDeveloperByID(idNumber);

            if (developer != null)
            {
                developer.WriteDeveloperInfo(developer);

                Console.WriteLine("-----------------------");

                Console.WriteLine("Enter the team ID you would like to remove them from:");
                string teamID = Console.ReadLine();
                DevTeam_POCO devTeam = _devTeamRepo.GetTeamByTeamID(teamID);

                if (devTeam != null)
                {
                    devTeam.TeamMembers.Remove(developer);

                    Console.WriteLine($"{developer.FirstName} {developer.LastName} was successfully removed to {devTeam.TeamName}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("There is no team with that team ID... ");
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("No developer by that ID...");
            }
        }

        private void ShowDevelopers()

        {
            Console.Clear();
            List<Developer_POCO> listOfDevelopers = _developerRepo.ShowDeveloperList();

            foreach (Developer_POCO content in listOfDevelopers)
            {
                content.WriteDeveloperInfo(content);
            }
            Console.WriteLine("--------------------------------");
        }

        private void ShowListOfTeams()
        {
            List<DevTeam_POCO> listOfDevTeams = _devTeamRepo.ShowDevTeams();
           

            foreach (DevTeam_POCO content in listOfDevTeams)
            {
                content.WriteTeams(content);

                foreach (var contents in content.TeamMembers)
                {
                    contents.WriteDeveloperInfo(contents);
                }
            }
        }

        private void ShowDevelopersWithOutLicense()
        {
            Console.Clear();
            Console.WriteLine("List of Developers Without Pluralsign Access");
            List<Developer_POCO> listOfDevelopers = _developerRepo.ShowDeveloperList();

            foreach (var developer in listOfDevelopers)
            {
                if (developer.HasAccessToPluralsign == false)
                {
                    developer.WriteDeveloperInfo(developer);
                }
            }
        }

        private void SeedDeveloperList()
        {
            Developer_POCO employeeSeed = new Developer_POCO("Nick", "Stoner", "15", false);
            Developer_POCO employeeSeed2 = new Developer_POCO("John", "Smith", "465", false);
            Developer_POCO employeeSeed3 = new Developer_POCO("John", "Doe", "199", true);
            Developer_POCO employeeSeed4 = new Developer_POCO("Jane", "Smith", "13", false);
            Developer_POCO employeeSeed5 = new Developer_POCO("Jane", "Doe", "93", true);

            _developerRepo.AddDeveloperToList(employeeSeed);
            _developerRepo.AddDeveloperToList(employeeSeed2);
            _developerRepo.AddDeveloperToList(employeeSeed3);
            _developerRepo.AddDeveloperToList(employeeSeed4);
            _developerRepo.AddDeveloperToList(employeeSeed5);

        }

        private void SeedTeamList()
        {
            var teamSeed1 = new DevTeam_POCO("Gryffendoor", "1");
            var teamSeed2 = new DevTeam_POCO("Hufflepuff", "2");
            var teamSeed3 = new DevTeam_POCO("Slytherin", "3");

            _devTeamRepo.AddTeamToList(teamSeed1);
            _devTeamRepo.AddTeamToList(teamSeed2);
            _devTeamRepo.AddTeamToList(teamSeed3);
        }
    }
}
