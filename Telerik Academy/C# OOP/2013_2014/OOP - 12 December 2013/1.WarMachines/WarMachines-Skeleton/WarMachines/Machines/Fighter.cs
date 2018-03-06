using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        private bool stealthMode;
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode) 
            : base(name, attackPoints, defensePoints, 200, "Fighter")
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get => stealthMode; set => stealthMode = value; }

        public void ToggleStealthMode()
        {
            if (StealthMode == false)
            {
                StealthMode = true;
            }
            else
            {
                StealthMode = false;
            }
        }
        public override string ToString()
        {
            string state;
            if (StealthMode == true)
            {
                state = "ON";
            }
            else
            {
                state = "OFF";
            }
            return base.ToString() + $" *Stealth: {state}";
        }
    }
}
