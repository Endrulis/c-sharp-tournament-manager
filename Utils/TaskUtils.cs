using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManagement
{
    class TaskUtils
    {
        public static bool CheckIfContainsName(string selectedTeam, TeamContainer AllTeams)
        {
            bool contains = false;
            for(int i = 0; i < AllTeams.Count; i++)
                if (AllTeams.Get(i).Name.Equals(selectedTeam))
                {
                    contains = true;
                    break;
                }
            return contains;
        }
        public static int FindBestTeamPoints(TeamContainer AllTeams)
        {
            int score = AllTeams.Get(0).Score;
            for(int i = 0; i < AllTeams.Count; i++)
            {
                if (AllTeams.Get(i).Score > score)
                {
                    score = AllTeams.Get(i).Score;
                }
            }
            return score;
        }
        public static void FindBestTeams(TeamContainer AllTeams, TeamContainer BestTeams)
        {

            int score = FindBestTeamPoints(AllTeams);
            for(int i = 0; i < AllTeams.Count; i++)
            {
                if (AllTeams.Get(i).Score == score)
                {
                    BestTeams.Add(AllTeams.Get(i));
                }
            }
        }
    }
}
