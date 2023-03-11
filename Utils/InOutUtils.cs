using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TournamentManagement
{
    class InOutUtils
    {
        public static PlayerRegister ReadData(string fileName)
        {
            PlayerRegister Register = new PlayerRegister();

            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            Register.Cycle = int.Parse(Lines[0]);
            Register.CycleDate = DateTime.Parse(Lines[1]);
            for (int i = 2; i < Lines.Length; i++)
            {
                string[] Values = Lines[i].Split(';');
                string name = Values[0];
                string surname = Values[1];
                string team = Values[2];
                string position = Values[3];
                string champion = Values[4];
                int K = int.Parse(Values[5]);
                int A = int.Parse(Values[6]);
                Player user = new Player(name, surname, team, position, champion, K, A);
                Register.Add(user);
            }
            return Register;

        }
        public static void OutputDataToTxt(PlayerRegister register, string fileName)
        {
            string[] lines = new string[register.Count() + 6];
            lines[0] = String.Format("{0} ratas:", register.Cycle.ToString());
            lines[1] = String.Format("{0}", register.CycleDate.ToString("yyyy-dd-MM"));
            lines[2] = new string('-', 113);
            lines[3] = String.Format("| {0, -10} | {1, -14} | {2, -10} | {3, -10} | {4, -10} | {5, -10} | {6, -10} |",
                         "Name", "Surname", "Team", "Position", "Champion", "Destructions", "Participating in destructions");
            lines[4] = new string('-', 113);
            for (int i = 0; i < register.Count(); i++)
            {
                lines[i + 5] = register.Get(i).ToString();
            }
            lines[register.Count() + 5] = new string('-', 113);
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
        public static void OutputBestJunglers(PlayerContainer bestJunglerPlayers)
        {
            Console.WriteLine("Best junglers:");
            for(int i = 0; i < bestJunglerPlayers.Count; i++)
            {
                Console.WriteLine(bestJunglerPlayers.Get(i).Name);
            }

        }
        public static void OutputBestTeams(PlayerRegister register, TeamContainer BestTeams)
        {

            Console.WriteLine("Cycle {0}", register.Cycle);
            Console.WriteLine("Best teams:");
            for(int i = 0; i < BestTeams.Count; i++)
            {
                Console.WriteLine(BestTeams.Get(i).Name);
            }
        }
        public static void OutputChangesToCSV(string changesFile, PlayerContainer Players, string title)
        {
            string[] lines = new string[Players.Count+2];
            lines[0] = String.Format("{0, 10}", title);
            lines[1] = String.Format("{0, -10};{1, -14};{2, -10};{3, -10};{4, -10};{5, -10};{6, -10}",
                         "Name", "Surname", "Team", "Position", "Champion", "Destructions", "Participating in destructions");
            for (int i = 0; i < Players.Count;i++)
            {
                lines[i+2] = String.Format("{0, -10};{1, -14};{2, -10};{3, -10};{4, -10};{5, 12};{6, 25}",
                    Players.Get(i).Name, Players.Get(i).Surname, Players.Get(i).Team,
                     Players.Get(i).Position, Players.Get(i).Champion, Players.Get(i).Kills, Players.Get(i).Assists);
            }
            File.AppendAllLines(changesFile, lines, Encoding.UTF8);
        }
        public static void OutputChampionsToCSV(string championsFile, List<string> Champions)
        {

            string[] lines = new string[Champions.Count + 1];
            lines[0] = "Champions who participated:";
            for (int i = 0; i < Champions.Count; i++)
            {
                lines[i + 1] = Champions[i];
            }
            File.WriteAllLines(championsFile, lines, Encoding.UTF8);
        }
    }
}
