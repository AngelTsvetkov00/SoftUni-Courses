using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Team> teams = new List<Team>();
           
           string input= "";
           while ((input=Console.ReadLine()) != "END")
           { 
               string[] commandLine = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
               string command = commandLine[0];
               var teamName1 = commandLine[1];
                
                try
                {                  
                    if (command=="Team")
                    {
                        teams.Add(new Team(commandLine[1]));
                    }
                    else if (!teams.Any(x => x.Name == teamName1))
                    {
                        throw new ArgumentException($"Team {teamName1} does not exist.");
                    }
                    else if (command == "Add")
                    {
                        var playerName = commandLine[2];
                        var endurance = int.Parse(commandLine[3]);
                        var sprint = int.Parse(commandLine[4]);
                        var dribble = int.Parse(commandLine[5]);
                        var passing = int.Parse(commandLine[6]);
                        var shooting = int.Parse(commandLine[7])
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        var teamToAddPlayerIn = teams.FirstOrDefault(x => x.Name == teamName1);
                       
                        if ((endurance > 0 && endurance < 100) &&
                            (sprint > 0 && sprint < 100) &&
                            (dribble > 0 && dribble < 100) &&
                            (passing > 0 && passing < 100) &&
                            (shooting > 0 && shooting < 100))
                        {                          
                            teamToAddPlayerIn.AddPlayer(player);
                        }
                    }
                    else if (command == "Remove")
                    {
                        var teamToRemovePlayerFrom = teams.FirstOrDefault(x => x.Name == teamName1)
                        if (!teamToRemovePlayerFrom.Players.Any(x => x.Name == commandLine[2]))
                        {
                            throw new ArgumentException($"Player {commandLine[2]} is not in {teamName1} team.");
                        }
                        else
                        {
                            Player player = teamToRemovePlayerFrom.Players.First(x => x.Name == commandLine[2]);
                            teamToRemovePlayerFrom.RemovePlayer(player);
                        }
                    }
                    else if (command == "Rating")
                    {
                        var teamToDisplay = teams.FirstOrDefault(x => x.Name == teamName1);
                        Console.WriteLine($"{teamToDisplay.Name} - {teamToDisplay.TeamRating}");                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
           }                        
        }        
    }
}
