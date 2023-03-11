using System;
namespace TournamentManagement
{
    class Team
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Team(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
        public static bool operator >(Team team1, Team team2)
        {
            return team1.Score > team2.Score;
        }
        public static bool operator <(Team team1, Team team2)
        {
            return team1.Score < team2.Score;
        }
    }
}
