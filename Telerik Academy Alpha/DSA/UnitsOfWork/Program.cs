using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsOfWork
{
    public class Program
    {
        static void Main(string[] args)
        {

            var commands = string.Empty;
            var playersByType = new Dictionary<string, SortedSet<Unit>>();
            var totalUnits = new Dictionary<string, Unit>();
            var totalUnitsByPower = new SortedSet<Unit>();
            var messageResults = new StringBuilder();


            while((commands = Console.ReadLine()) != "end")
            {
                var commandParameters = commands.Split();
                var mainCommand = commandParameters[0];
                switch(mainCommand)
                {
                    case "add":
                        AddUnit(commandParameters, playersByType, totalUnitsByPower,
                            totalUnits, messageResults);
                        break;
                    case "remove":
                        RemoveUnit(commandParameters, playersByType, totalUnitsByPower,
                            totalUnits, messageResults);
                        break;
                    case "find":
                        FindUnits(commandParameters, playersByType, messageResults);
                        break;
                    case "power":
                        FindMostPowerfull(commandParameters, totalUnitsByPower, messageResults);
                        break;

                }
            }

            Console.WriteLine(messageResults.ToString().TrimEnd());
        }

        static void FindMostPowerfull(string[] commandParameters, SortedSet<Unit> unitsByPower,
            StringBuilder messageResult)
        {
            var totalNumber = int.Parse(commandParameters[1]);
            var breaker = 0;
            messageResult.Append("RESULT: ");
            if(unitsByPower.Count > 0)
            {
                foreach (var unit in unitsByPower)
                {
                    if(breaker == totalNumber)
                    {
                        break;
                    }
                    messageResult.Append(unit.ToString() + ',' + ' ');
                    breaker++;
                }
                messageResult.Remove(messageResult.Length - 2, 2);
            }
            messageResult.AppendLine();
        }

        static void FindUnits(string[] commandParameters, Dictionary<string,  SortedSet<Unit>> playersByType,
            StringBuilder messageResult)
        {
            var unitType = commandParameters[1];
            messageResult.Append("RESULT: ");
            var breaker = 0;
            if (playersByType.ContainsKey(unitType))
            {
                if (playersByType[unitType].Count > 0)
                {
                    foreach (var player in playersByType[unitType])
                    {
                        if (breaker == 10)
                        {
                            break;
                        }
                        messageResult.Append(player.ToString() + ',' + ' ');
                        breaker++;
                    }
                    messageResult.Remove(messageResult.Length - 2, 2);
                }
            }
            messageResult.AppendLine();
        }

        static void RemoveUnit(string[] commandParameters, Dictionary<string, SortedSet<Unit>> playersByType,
            SortedSet<Unit> totalUnitsByPower, Dictionary<string, Unit> totalUnits, StringBuilder messageResult)
        {
            var unitName = commandParameters[1];
            if (totalUnits.ContainsKey(unitName))
            {
                var unitToRemove = totalUnits[unitName];
                totalUnits.Remove(unitName);
                totalUnitsByPower.Remove(unitToRemove);
                playersByType[unitToRemove.Type].Remove(unitToRemove);

                messageResult.AppendLine($"SUCCESS: {unitToRemove.Name} removed!");
                //Console.WriteLine($"SUCCESS: {unitToRemove.Name} removed!");
            }
            else
            {
                messageResult.AppendLine($"FAIL: {unitName} could not be found!");
                //Console.WriteLine($"FAIL: {unitName} could not be found!");
            }
        }

        public static void AddUnitSolution(Unit unit, Dictionary<string, SortedSet<Unit>> unitsByType,
                        Dictionary<string, Unit> unitsByName, SortedSet<Unit> unitsOrderedByAttack,
                        StringBuilder resultBuilder)
        {
            if (unitsByName.ContainsKey(unit.Name))
            {
                resultBuilder.AppendLine(string.Format("FAIL: {0} already exists!", unit.Name));
            }
            else
            {
                unitsByName.Add(unit.Name, unit);
                unitsOrderedByAttack.Add(unit);
                if (!unitsByType.ContainsKey(unit.Type))
                {
                    unitsByType.Add(unit.Type, new SortedSet<Unit>());
                }

                unitsByType[unit.Type].Add(unit);

                resultBuilder.AppendLine(string.Format("SUCCESS: {0} added!", unit.Name));
            }
        }

        static void AddUnit(string[] commandParameters, Dictionary<string, SortedSet<Unit>> unitsByType,
            SortedSet<Unit> totalUnitsByPower, Dictionary<string, Unit> totalUnits, StringBuilder messageResult)
        {
            var name = commandParameters[1];
            var type = commandParameters[2];
            var attack = int.Parse(commandParameters[3]);

            var unitToAdd = new Unit(name, type, attack);

            //if (totalUnits.ContainsKey(name))
            //{
            //    messageResult.AppendLine($"FAIL: {unitToAdd.Name} already exists!");

            //}
            //else
            //{
            //    totalUnits.Add(name, unitToAdd);
            //    totalUnitsByPower.Add(unitToAdd);
            //    if (!unitsByType.ContainsKey(unitToAdd.Type))
            //    {
            //        unitsByType.Add(unitToAdd.Type, new SortedSet<Unit>());
            //    }
            //    unitsByType[unitToAdd.Type].Add(unitToAdd);
            //    messageResult.AppendLine($"SUCCESS: {unitToAdd.Name} added!");
            //}
            if (unitsByType.ContainsKey(type))
            {
                if (!unitsByType[type].Contains(unitToAdd))
                {
                    // the codeblock below is wrong - it will enter the if and skip the else
                    // resulting in the player not being added to unitByType
                    // and thus on the next iteration having a duplicate user and the program
                    // will crash
                    //if (playersByType[type].Count == 10)
                    //{
                    //    var lastUnit = playersByType[type].ElementAt(9);
                    //    // need to check if CompareTo methods works or returns wrong !
                    //    if (unitToAdd.CompareTo(lastUnit) == 1)
                    //    {
                    //        playersByType[type].Remove(lastUnit);
                    //        playersByType[type].Add(unitToAdd);
                    //    }
                    //}
                    //else
                    //{
                    //    playersByType[type].Add(unitToAdd);
                    //}

                    //Console.WriteLine($"SUCCESS: {unitToAdd.Name} added!");
                    unitsByType[type].Add(unitToAdd);
                    messageResult.AppendLine($"SUCCESS: {unitToAdd.Name} added!");
                    totalUnitsByPower.Add(unitToAdd);
                    totalUnits.Add(unitToAdd.Name, unitToAdd);
                }
                else
                {
                    messageResult.AppendLine($"FAIL: {unitToAdd.Name} already exists!");
                    //Console.WriteLine($"FAIL: {unitToAdd.Name} already exists!");
                }
            }
            else
            {
                unitsByType.Add(type, new SortedSet<Unit>());
                unitsByType[type].Add(unitToAdd);
                totalUnitsByPower.Add(unitToAdd);
                totalUnits.Add(unitToAdd.Name, unitToAdd);
                messageResult.AppendLine($"SUCCESS: {unitToAdd.Name} added!");
            }

        }
    }


    }

    public class Unit : IComparable<Unit>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public int CompareTo(Unit other)
        {

            //int result = other.Attack.CompareTo(this.Attack);
            // why * -1?
            int result = this.Attack.CompareTo(other.Attack) * -1;
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{this.Name}[{this.Type}]({this.Attack})";
        }
    }
//}
