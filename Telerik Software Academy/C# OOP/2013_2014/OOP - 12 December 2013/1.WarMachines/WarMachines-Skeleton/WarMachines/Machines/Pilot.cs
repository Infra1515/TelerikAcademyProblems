using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        // pilotMachines to be a constant?
        private IList<IMachine> pilotMachines;
        public Pilot(string name)
        {
            this.Name = name;
            this.pilotMachines = new List<IMachine>();

        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public IList<IMachine> PilotMachines { get => pilotMachines; set => pilotMachines = value; }

        public void AddMachine(IMachine machine)
        {
            this.PilotMachines.Add(machine);
            machine.Pilot = this;
        }

        public string Report()
        {
            string numberOfMachines;
            if(this.PilotMachines.Count == 0)
            {
                numberOfMachines = "no machines";
            }
            else if(this.PilotMachines.Count == 1)
            {
                numberOfMachines = "1 machine";
            }
            else
            {
                numberOfMachines = $"{this.PilotMachines.Count} machines";
            }

            StringBuilder result = new StringBuilder();
            result.Append($"{this.Name} - {numberOfMachines}\r\n");
            foreach (var item in this.pilotMachines)
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString().TrimEnd();

        }
    }
}
