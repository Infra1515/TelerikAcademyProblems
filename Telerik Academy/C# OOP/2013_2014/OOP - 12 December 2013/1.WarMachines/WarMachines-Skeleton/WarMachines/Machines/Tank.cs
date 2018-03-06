using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        private int defenseModeCount = 0;
        private bool defenseMode;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, 100, "Tank")
        {
            this.DefensePoints += 30;
            this.AttackPoints -= 40;
            this.DefenseMode = true;
        }

        public bool DefenseMode { get => defenseMode; set => defenseMode = value; }

        public void ToggleDefenseMode()
        {
            if(DefenseMode == true)
            {
                DefenseMode = false;
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else
            {
                DefenseMode = true;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }
        public override string ToString()
        {
            string state;
            if(DefenseMode == true)
            {
                state = "ON";
            }
            else
            {
                state = "OFF";
            }
            return base.ToString() + $" *Defense: {state}";
        }
    }
}
