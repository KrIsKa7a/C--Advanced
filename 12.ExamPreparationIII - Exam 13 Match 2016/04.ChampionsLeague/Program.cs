using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.ChampionsLeague
{
    class Team
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public HashSet<string> Opponents { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var allTeams = new List<Team>();

            var command = Console.ReadLine();

            while (command != "stop")
            {
                var cmdArgs = command
                    .Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                var team1 = cmdArgs[0];
                var team2 = cmdArgs[1];
                var score1 = cmdArgs[2]
                    .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var score2 = cmdArgs[3]
                    .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var team1Goals = score1[0] + score2[1];
                var team2Goals = score1[1] + score2[0];

                if (allTeams.Where(t => t.Name == team1).Count() == 0)
                {
                    var team1AsClass = new Team()
                    {
                        Name = team1,
                        Wins = 0,
                        Opponents = new HashSet<string>()
                    };
                    allTeams.Add(team1AsClass);
                }

                if (allTeams.Where(t => t.Name == team2).Count() == 0)
                {
                    var team2AsClass = new Team()
                    {
                        Name = team2,
                        Wins = 0,
                        Opponents = new HashSet<string>()
                    };
                    allTeams.Add(team2AsClass);
                }

                if (team1Goals > team2Goals)
                {
                    var t1 = allTeams.FirstOrDefault(t => t.Name == team1);
                    var t2 = allTeams.FirstOrDefault(t => t.Name == team2);
                    allTeams.Remove(t1);
                    allTeams.Remove(t2);

                    t1.Wins++;
                    t1.Opponents.Add(t2.Name);
                    t2.Opponents.Add(t1.Name);
                    allTeams.Add(t1);
                    allTeams.Add(t2);
                }
                else if (team1Goals < team2Goals)
                {
                    var t1 = allTeams.FirstOrDefault(t => t.Name == team1);
                    var t2 = allTeams.FirstOrDefault(t => t.Name == team2);
                    allTeams.Remove(t1);
                    allTeams.Remove(t2);

                    t2.Wins++;
                    t2.Opponents.Add(t1.Name);
                    t1.Opponents.Add(t2.Name);
                    allTeams.Add(t2);
                    allTeams.Add(t1);
                }
                else
                {
                    var firstTeamAwayGoals = score2[1];
                    var secondTeamAwayGoals = score1[1];

                    var t1 = allTeams.FirstOrDefault(t => t.Name == team1);
                    var t2 = allTeams.FirstOrDefault(t => t.Name == team2);
                    allTeams.Remove(t1);
                    allTeams.Remove(t2);

                    if (firstTeamAwayGoals > secondTeamAwayGoals)
                    {
                        t1.Wins++;
                        t1.Opponents.Add(t2.Name);
                        t2.Opponents.Add(t1.Name);
                    }
                    else
                    {
                        t2.Wins++;
                        t2.Opponents.Add(t1.Name);
                        t1.Opponents.Add(t2.Name);
                    }

                    allTeams.Add(t1);
                    allTeams.Add(t2);
                }

                command = Console.ReadLine();
            }

            allTeams = allTeams
                .OrderByDescending(t => t.Wins)
                .ThenBy(t => t.Name)
                .ToList();

            foreach (var team in allTeams)
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- Wins: {team.Wins}");
                var opp = String.Join(", ", team.Opponents
                    .OrderBy(t => t)
                    .ToList());
                Console.WriteLine($"- Opponents: {opp}");
            }
        }
    }
}
