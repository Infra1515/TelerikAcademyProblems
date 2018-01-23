using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Program
    {
        public class Player : IComparable<Player>
        {
            private string name;
            private string type;
            private int age;

            public Player(string name, string type, int age)
            {
                this.Name = name;
                this.Type = type;
                this.Age = age;
            }

            public string Name { get => name; set => name = value; }
            public string Type { get => type; set => type = value; }
            public int Age { get => age; set => age = value; }

            public int CompareTo(Player other)
            {
                int result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    result = this.Age.CompareTo(other.Age) * -1;
                }

                return result;
            }

            public override string ToString()
            {
                return $"{this.Name}({this.Age}); ";
            }

        }

        static void Main(string[] args)
        {
            var players = new Dictionary<string, OrderedSet<Player>>();
            var ranking = new BigList<Player>();
            ranking.Add(null);
            var sb = new StringBuilder();
            var input = string.Empty;
           

            while(input != "end")
            {
                input = Console.ReadLine();
                var inputArray = input.Split().ToArray();

                switch (inputArray[0])
                {
                    case "add":
                        AddPlayer(inputArray[1], inputArray[2], int.Parse(inputArray[3]), 
                            int.Parse(inputArray[4]), players, ranking, sb);
                        break;
                    case "ranklist":
                        PrintRanklist(int.Parse(inputArray[1]), int.Parse(inputArray[2]), ranking, sb);
                        break;
                    case "find":
                        FindPlayerByType(inputArray[1], players, sb);
                        break; 
                }

            }

            Console.WriteLine(sb.ToString().Trim());
        }
        
        static void FindPlayerByType(string type, Dictionary<string, OrderedSet<Player>> players,
            StringBuilder sb)
        {
            if (players.ContainsKey(type))
            {
                var playerByTypeList = players[type];
                if (playerByTypeList.Count > 0)
                {
                    sb.Append($"Type {type}: ");
                    foreach (var player in playerByTypeList)
                    {
                        sb.Append(player.ToString());
                    }
                    sb.Remove(sb.Length - 2, 2);
                }
            }
            else
            {
                sb.Append($"Type {type}: ");
            }

            sb.AppendLine();

        }
        static void PrintRanklist(int start, int elementsCount, BigList<Player> ranking, StringBuilder sb)
        {
            for(int i = start; i <= elementsCount; i++)
            {
                sb.Append(($"{i.ToString()}. {ranking[i].ToString()}"));
            }
            sb.Remove(sb.Length - 2, 2);
            sb.AppendLine();
        }


        static void AddPlayer(string name, string type, int age, int position,
            Dictionary<string, OrderedSet<Player>> players, BigList<Player> ranking, StringBuilder sb)
        {
            var player = new Player(name, type, age);

            if (players.ContainsKey(type))
            {
                if (players[type].Count == 5)
                {
                    Player lastPlayer = players[type][4];
                    if(lastPlayer.CompareTo(player) > 0)
                    {
                        players[type].Remove(lastPlayer);
                        players[type].Add(player);
                    }
                }
                else
                {
                    players[type].Add(player);
                }
            }
            else
            {
                players.Add(type, new OrderedSet<Player>());
                players[type].Add(player);
            }
         

            ranking.Insert(position , player);
            sb.AppendLine($"Added player {name} to position {position}");
        }
    }
}
