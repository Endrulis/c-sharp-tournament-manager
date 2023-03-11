using System;

namespace TournamentManagement
{
    class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Team { get; set; }
        public string Position { get; set; }
        public string Champion { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        private int[] PointsInTotal;
        public Player(int[] pointsInTotal)
        {
            PointsInTotal = pointsInTotal;
        }
        public Player(string name, string surname, string team, string position, string champion, int k, int a)
        {
            Name = name;
            Surname = surname;
            Team = team;
            Position = position;
            Champion = champion;
            Kills = k;
            Assists = a;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return String.Format("| {0, -10} | {1, -14} | {2, -10} | {3, -10} | {4, -10} | {5, 12} | {6, 25} |",
                    Name, Surname, Team, Position, Champion, Kills, Assists);
        }
        public int CompareTo(Player other)
        {
            if (String.Compare(Team, other.Team) > 0 || String.Compare(Team, other.Team) == 0 && String.Compare(Surname, other.Surname) > 0
                || String.Compare(Team, other.Team) == 0 && String.Compare(Surname, other.Surname) == 0 && String.Compare(Name, other.Name) > 0)
            {
                return 1;
            }
            else if (String.Compare(Team, other.Team) == 0 && String.Compare(Surname, other.Surname) == 0 && String.Compare(Name, other.Name) == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public static bool operator >(Player lhs, Player rhs)
        {
            if (lhs.CompareTo(rhs) > 0)
            {
                return lhs.CompareTo(rhs) > 0;
            }
            return false;
        }
        public static bool operator <(Player lhs, Player rhs)
        {
            if (lhs.CompareTo(rhs) < 0)
            {
                return lhs.CompareTo(rhs) < 0;
            }
            return false;
        }
        public static bool operator ==(Player lhs, Player rhs)
        {
            if (lhs.CompareTo(rhs) == 0)
            {
                return lhs.CompareTo(rhs) == 0;
            }
            return false;
        }
        public static bool operator !=(Player lhs, Player rhs)
        {
            if (lhs.CompareTo(rhs) != 0)
            {
                return lhs.CompareTo(rhs) != 0;
            }
            return false;
        }
    }
}
