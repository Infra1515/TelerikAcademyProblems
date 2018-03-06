namespace CitiesTemperatures
{
    public class City 
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public double Temperature { get; set; }

        public City(string name, string country, int pop, double temp)
        {
            Name = name;
            Country = country;
            Population = pop;
            Temperature = temp;
        }

        public override int GetHashCode()
        {
            return this.Name.Length;
        }

        public override bool Equals(object obj)
        {
            return this.Name == (obj as City).Name;
        }
    }
}
