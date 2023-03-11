using System;
namespace TournamentManagement
{
    class PlayerContainer
    {
        private Player[] players;
        public int Count { get; private set; }
        private int Capacity;
        public PlayerContainer(int capacity = 16)
        {
            Capacity = capacity;
            players = new Player[Capacity];
        }
        public PlayerContainer(PlayerContainer container) : this()
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
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }
        public void Put(int index, Player student)
        {
            if (index >= 0 && index < Count)
            {
                players[index] = student;
            }
            
        }
        public void Add(Player student)
        {
            if (Count == Capacity)
            {
                EnsureCapacity(Capacity * 2);
            }
            players[Count++] = student;
        }
        public Player Get(int index)
        {
            return this.players[index];
        }
        public bool Contains(Player student)
        {
            for (int i = 0; i < Count; i++)
            {
                if (players[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }
        public void Insert(Player user, int index)
        {
            if (index >= 0 && index < Count)
            {
                if (Count == Capacity)
                    EnsureCapacity(Capacity * 2);
                Count++;
                for (int i = Count; i > index; i--)
                {
                    players[i] = players[i - 1];
                }
                players[index] = user;
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
        public void Remove(Player user)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (players[i] == user)
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
                Console.WriteLine("Element not found");
            }
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    players[i] = players[i + 1];
                }
                this.Count--;
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
        public void Sort()
        {
            for (int firstIndex = 0, lastIndex = Count - 1; firstIndex < lastIndex; firstIndex++, lastIndex--){
                int minIndex = firstIndex;
                int maxIndex = lastIndex;
                for(int i = firstIndex; i < lastIndex; i++)
                {
                    if (players[i] < players[minIndex])
                    {
                        minIndex = i;
                    }
                    else if (players[i] > players[maxIndex])
                    {
                        maxIndex = i;
                    }
                    Player temp = players[firstIndex]; 
                    players[firstIndex] = players[minIndex]; 
                    players[minIndex] = temp;
                    if(maxIndex == firstIndex)
                    {
                        maxIndex = minIndex;
                    }
                    temp = players[lastIndex]; 
                    players[lastIndex] = players[maxIndex]; 
                    players[maxIndex] = temp;
                }
            }
        }
        int GetIndex(PlayerContainer Users, Player user, int n)
        {
            for(int i = 0; i < Count; i++)
            {
                if (Users.Get(i) == user)
                {
                    return i;
                }
            }
            return -1;
        }
        public PlayerContainer Intersect(PlayerContainer other)
        {
            PlayerContainer result = new PlayerContainer();
            for(int i = 0;  i < Count; i++)
            {
                Player current = players[i];
                if (GetIndex(other, current, Count) < 0)
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
