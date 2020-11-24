namespace CarRentalService
{
    public interface IVehicleMaintenance
    {
        void ServiceFleet();
        void ServiceFleetEngine();
        void ServiceFleetTransmission();
        void ServiceFleetTires();
    }
}