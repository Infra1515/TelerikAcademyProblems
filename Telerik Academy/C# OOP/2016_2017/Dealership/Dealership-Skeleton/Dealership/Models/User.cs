using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using System.Text.RegularExpressions;

namespace Dealership.Models
{
    class User : IUser
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
            this.Vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get { return this.username; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else if(value.Length < 2 || value.Length > 20)
                {
                    throw new Exception("Username must be between 2 and 20 characters long!");
                }
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
            get { return this.firstName; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else if(value.Length < 2 || value.Length > 20)
                {
                    throw new Exception("Firstname must be between 2 and 20 characters long!");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 2 || value.Length > 20)
                {
                    throw new Exception("Lastname must be between 2 and 20 characters long!");
                }
                this.lastName = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else if(value.Length < 5 || value.Length > 30)
                {
                    throw new Exception("Password must be between 5 and 30 characters long!");
                }
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
            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            this.Vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            string s;
            int count = 1;
            s = $"--USER {this.Username}--\r\n";
            for(int i = 0; i < this.Vehicles.Count; i++)
            {
                // no need to check for class type - the compilator 
                // knows which ToString() method to call
                s += $"{count.ToString()}. {vehicles.ToString()}";
                if (this.Vehicles[i].Comments.Count == 0)
                {
                    s += $"    --NO COMMENTS--\r\n";
                }
                else
                {
                    s += $"    --COMMENTS--\r\n";

                    for (int j = 0; j < this.Vehicles[i].Comments.Count; j++)
                    {
                        s += $"    ----------\r\n";
                        s += this.Vehicles[i].Comments[j].ToString();
                        s += $"    ----------\r\n";

                    }
                    s += $"    --COMMENTS--\r\n";
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
            return $"Username: { this.Username}, FullName: {this.FirstName} {this.LastName}," +
                $" Role: {this.Role}";

        }
    }
}
