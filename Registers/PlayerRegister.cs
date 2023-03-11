using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManagement
{
    class PlayerRegister
    {
        public int Cycle { get; set; }
        public DateTime CycleDate { get; set; }
        private PlayerContainer allUsers;
        public PlayerRegister()
        {
            allUsers = new PlayerContainer();
        }
        public PlayerRegister(PlayerContainer users) : this()
        {
            for (int i = 0; i < users.Count; i++)
            {
                allUsers.Add(users.Get(i));
            }
        }
        public void Add(Player user)
        {
            allUsers.Add(user);
        }
        public int Count()
        {
            return allUsers.Count;
        }
        public Player Get(int i)
        {
            return allUsers.Get(i);
        }
        public int FindBestJunglerResult(string position, PlayerRegister register2)
        {
            int result = 0;
            for(int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers.Get(i).Position == position)
                {
                    if (allUsers.Get(i).Kills + allUsers.Get(i).Assists + register2.Get(i).Kills + register2.Get(i).Assists > result)
                    {
                        result = allUsers.Get(i).Kills + allUsers.Get(i).Assists + register2.Get(i).Kills + register2.Get(i).Assists;
                    }
                }
            }
            return result;
        }
        public PlayerContainer FindBestJunglerPlayers(string position, PlayerRegister register2)
        {
            int bestJunglerResult = FindBestJunglerResult(position, register2);
            PlayerContainer BestJunglers = new PlayerContainer();
            for(int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers.Get(i).Position == position && allUsers.Get(i).Kills + allUsers.Get(i).Assists + register2.Get(i).Kills + register2.Get(i).Assists == bestJunglerResult)
                {
                    BestJunglers.Add(allUsers.Get(i));
                }
            }
            return BestJunglers;
        }
        public void FindTeamNames(TeamContainer AllTeams)
        {
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (TaskUtils.CheckIfContainsName(allUsers.Get(i).Team, AllTeams) == false)
                {
                    Team team = new Team(allUsers.Get(i).Team, 0);
                    AllTeams.Add(team);
                }
            }
        }
        public void CountTeamPoints(TeamContainer AllTeams)
        {
            for (int j = 0; j < AllTeams.Count; j++)
            {
                for (int i = 0; i < allUsers.Count; i++)
                {
                    if (allUsers.Get(i).Team == AllTeams.Get(j).Name)
                    {
                        AllTeams.Get(j).Score += allUsers.Get(i).Assists;
                    }
                }
            }
        }
        public void FindChampions(List<string> Champions)
        {
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (allUsers.Get(i).Assists != 0 && !Champions.Contains(allUsers.Get(i).Champion))
                {
                    Champions.Add(allUsers.Get(i).Champion);
                }
            }
        }
        public bool CheckIfContainsPlayer(string selectedPlayerName, string selectedPlayerSurname, PlayerRegister register)
        {
            bool contains = false;
            for (int i = 0; i < register.Count(); i++)
            {
                if (register.Get(i).Name.Equals(selectedPlayerName) && register.Get(i).Surname.Equals(selectedPlayerSurname))
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
        public void FindRemovedPlayers(PlayerContainer removedPlayers, PlayerRegister register2)
        {
            for(int i = 0; i < allUsers.Count; i++)
            {
                if(CheckIfContainsPlayer(allUsers.Get(i).Name, allUsers.Get(i).Surname, register2) == false)
                {
                    removedPlayers.Add(allUsers.Get(i));
                }
            }
        }
        public void FindAddedPlayers(PlayerContainer addedPlayers, PlayerRegister register1)
        {
            for(int i = 0; i < allUsers.Count; i++)
            {
                if(CheckIfContainsPlayer(allUsers.Get(i).Name, allUsers.Get(i).Surname, register1) == false)
                {
                    addedPlayers.Add(allUsers.Get(i));
                }
            }
        }
        public void Sort()
        {
            allUsers.Sort();
        }
    }
}
