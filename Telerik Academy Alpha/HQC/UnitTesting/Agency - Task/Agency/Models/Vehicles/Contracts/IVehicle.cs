namespace Agency.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        int PassangerCapacity { get; }

        VehicleType Type { get; }

        decimal PricePerKilometer { get; }

    }
}