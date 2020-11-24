using System;
using System.Collections.Generic;

namespace CarRentalService
{
    public class ServiceHistories
    {
        private readonly List<ServiceHistory> _serviceHistoriesList = new List<ServiceHistory>();

        public List<ServiceHistory> GetServiceHistoriesList()
        {
            return _serviceHistoriesList;
        }

        public ServiceHistory GetNearestMaintenanceOf(MaintenanceType maintenanceType)
        {
            return _serviceHistoriesList.FindLast(hist => hist.GetMaintenanceType() == maintenanceType);
        }

        public void AddServiceHistory(Vehicle vehicle, DateTime date, MaintenanceType maintenanceType)
        {
            ServiceHistory sh = new ServiceHistory(vehicle.GetId(), vehicle.GetTravelledDistance(), date, maintenanceType);
            _serviceHistoriesList.Add(sh);
        }

        public void AddServiceHistory(Vehicle vehicle, MaintenanceType maintenanceType)
        {
            AddServiceHistory(vehicle, DateTime.Now, maintenanceType);
        }
    }
}