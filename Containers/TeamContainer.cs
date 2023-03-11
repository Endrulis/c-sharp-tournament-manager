using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManagement
{
    class TeamContainer
    {
        private Team[] teams;
        public int Count { get; private set; }
        private int Capacity;
        public TeamContainer(int capacity = 16)
        {
            Capacity = capacity;
            teams = new Team[Capacity];
        }
        public TeamContainer(TeamContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Team[] temp = new Team[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.teams[i];
                }
                this.Capacity = minimumCapacity;
                this.teams = temp;
            }
        }
        public void Put(int index, Team team)
        {
            if (index >= 0 && index < Count)
            {
                teams[index] = team;
            }
        }
        public void Add(Team team)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            teams[Count++] = team;
        }
        public Team Get(int index)
        {
            return this.teams[index];
        }
        public bool Contains(Player student)
        {
            for (int i = 0; i < Count; i++)
            {
                if (teams[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }
        public void Insert(Team team, int index)
        {
            if (index >= 0 && index < Count)
            {
                if (Count == Capacity)
                    EnsureCapacity(Capacity * 2);
                Count++;
                for (int i = Count; i > index; i--)
                {
                    teams[i] = teams[i - 1];
                }
                teams[index] = team;
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
        public void Remove(Team team)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (teams[i] == team)
                {
                    index = i;
                    break;
                }
            }
            if (index >= 0 && index < Count)
            {
                RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    teams[i] = teams[i + 1];
                }
                this.Count--;
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    
    }
}
