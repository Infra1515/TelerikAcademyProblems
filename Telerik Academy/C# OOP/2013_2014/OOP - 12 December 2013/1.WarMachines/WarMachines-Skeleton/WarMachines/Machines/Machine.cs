using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {

        private string name;
        private IPilot pilot;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IList<string> targets;
        private string type;

        public Machine(string name, double attackPoints, double defensePoints, double healthPoints, string type)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
            this.Type = type;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.pilot = value;
            }
        }

        public double AttackPoints { get => attackPoints; set => attackPoints = value; }
        public double DefensePoints { get => defensePoints; set => defensePoints = value; }
        public IList<string> Targets { get => targets; set => targets = value; }
        public double HealthPoints { get => healthPoints; set => healthPoints = value; }
        public string Type { get => type; set => type = value; }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            string s = $"- {this.Name}\r\n *Type: {this.Type}\r\n *Health: {this.HealthPoints}\r\n" +
                $" *Attack: {this.AttackPoints}\r\n *Defense: {this.DefensePoints}\r\n *Targets: ";
            if(this.Targets.Count == 0)
            {
                s += $"None\r\n";
            }
            else
            {
                s += string.Join(", ", this.Targets) ;
                s += $"\r\n";
            }
            return s;
        }
    }
}
