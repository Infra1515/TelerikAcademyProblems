using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Bytes2you.Validation;
using System.Text.RegularExpressions;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password,
            Role role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.vehicles = new List<IVehicle>();
        }
        
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                Guard.WhenArgument(value, "username").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "username len")
                    .IsLessThan(2)
                    .IsGreaterThan(20)
                    .Throw();
                string usernamePattern = "^[A-Za-z0-9]+$";
                Regex regex = new Regex(usernamePattern);
                if (!regex.IsMatch(value))
                {
                    throw new Exception("Username contains invalid symbols!");
                }

                this.username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Guard.WhenArgument(value, "firstName").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "first name len")
                   .IsLessThan(2)
                   .IsGreaterThan(20)
                   .Throw();
                this.firstName = value;

            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                Guard.WhenArgument(value, "lastName").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "last name len")
                   .IsLessThan(2)
                   .IsGreaterThan(20)
                   .Throw();
                this.lastName = value;

            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                Guard.WhenArgument(value, "password").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "pwd len")
                    .IsLessThan(5)
                    .IsGreaterThan(20)
                    .Throw();
                string passwordPattern = "^[A-Za-z0-9@*_-]+$";
                Regex regex = new Regex(passwordPattern);
                if (!regex.IsMatch(value))
                {
                    throw new Exception("Password contains invalid symbols!");
                }
                this.password = value;
            }
        }

        public Role Role { get => role; set => role = value; }
        public IList<IVehicle> Vehicles { get => vehicles; set => vehicles = value; }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            commentToAdd.Author = this.Username;    
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            int count = 1;
            string s = $"--USER {this.Username}--\r\n";
            foreach (Vehicle vh in this.Vehicles)
            {
 
                s += $"{count.ToString()}. ";
                if (vh is Motorcycle motor)
                {
                    s += motor.ToString();
                }
                else if (vh is Car car)
                {
                    s += car.ToString();
                }
                else if (vh is Truck tr)
                {
                    s += tr.ToString();

                }
                if (vh.Comments.Count() == 0)
                {
                    s += "   --NO COMMENTS--\r\n";
                }
                else
                {
                    s += $"      --COMMENTS--\r\n  " +
                        $"    ----------\r\n   ";
                    foreach (Comment c in vh.Comments)
                    {
                
                        s += c.ToString();
                    }
                    s += "  --COMMENTS--\r\n";
                }
                count++;                           
            }
            return s;

        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Vehicles.Remove(vehicle);
        }
        
        public override string ToString()
        {
            return $"Username: {this.Username}, FullName: {this.FirstName} {this.LastName} " +
                $"Role: {this.Role}";
        }
    }
}
