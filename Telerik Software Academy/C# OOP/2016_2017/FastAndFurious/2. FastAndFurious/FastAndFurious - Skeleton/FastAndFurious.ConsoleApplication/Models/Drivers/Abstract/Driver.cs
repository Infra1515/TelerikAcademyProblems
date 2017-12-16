using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;
using System.Collections.ObjectModel;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : IDriver
    {
        private readonly int id;
        private string name;
        private IMotorVehicle activeVehicle;
        private GenderType gender;
        private IEnumerable<IMotorVehicle> vehicles;

        public Driver(string name, GenderType gender)
        {
            this.id = DataGenerator.GenerateId();
            this.Name = name;
            this.Gender = gender;
            this.Vehicles = new List<IMotorVehicle>();
            
        }

        public string Name { get => name; set => name = value; }
        public GenderType Gender { get => gender; set => gender = value; }
        public IEnumerable<IMotorVehicle> Vehicles { get => vehicles; set => vehicles = value; }
        public IMotorVehicle ActiveVehicle { get => activeVehicle; set => activeVehicle = value; }
        public int Id => id;

        public void AddVehicle(IMotorVehicle vehicle)
        {
            Vehicles.ToList().Add(vehicle);
        }
        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            return this.Vehicles.ToList().Remove(vehicle);
        }
        public void SetActiveVehicle(IMotorVehicle vehicle)
        {
            this.ActiveVehicle = vehicle;
        }
    }
}
