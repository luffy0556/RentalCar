using System;

namespace CarRentalService
{
    public class ServiceHistory
    {
        private string _vehicleId;
        private double _travelledDistanceAtMaintenance;
        private DateTime _date;
        private MaintenanceType _maintenanceType;

        public ServiceHistory(string vehicleId, double travelledDistance, DateTime date,
            MaintenanceType maintenanceType)
        {
            _vehicleId = vehicleId;
            _travelledDistanceAtMaintenance = travelledDistance;
            _date = date;
            _maintenanceType = maintenanceType;
        }

        public string GetVehicleId()
        {
            return _vehicleId;
        }

        public double GetTravelledDistance()
        {
            return _travelledDistanceAtMaintenance;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public MaintenanceType GetMaintenanceType()
        {
            return _maintenanceType;
        }
    }

    public enum MaintenanceType
    {
        EngineOilChange,
        EngineMinor,
        EngineMajor,
        
        TransmissionFluidChange,
        TransmissionMinor,
        TransmissionOverhaul,
        
        TiresAdjustment,
        TiresReplacement,
    }
}