using System;

namespace CarRentalService
{
    public class Truck : Vehicle
    {
        private double _loadCapacity;
        private double _towCapacity;

        public Truck(string id, string brandName, string modelName, int year, double price, string color, int numberOfSeats, 
            double loadCapacity, double towCapacity) 
            : base(id, brandName, modelName, year, price, color, numberOfSeats)
        {
            _loadCapacity = loadCapacity;
            _towCapacity = towCapacity;
        }

        public double GetLoadCapacity()
        {
            return _loadCapacity;
        }

        public double GetTowCapacity()
        {
            return _towCapacity;
        }
        
        public override void ServiceEngine()
        {
            Console.WriteLine();
            string prefix = $"[Debug][Truck Id {GetId()}]";
            Console.WriteLine(prefix + " Start Service Engine");
            
            if (travelledDistance > 1000 && 
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.EngineOilChange).GetDate() - 
                DateTime.Now > new TimeSpan(180, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Engine Oil Change");
                _serviceHistories.AddServiceHistory(this, DateTime.Now, MaintenanceType.EngineOilChange);
            }

            if (travelledDistance > 1500 && 
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.EngineMinor).GetDate() - 
                DateTime.Now > new TimeSpan(240, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Engine Minor");
                _serviceHistories.AddServiceHistory(this, DateTime.Now, MaintenanceType.EngineMinor);
            }

            if (travelledDistance > 3000 && 
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.EngineMajor).GetDate() - 
                DateTime.Now > new TimeSpan(360, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Engine Major");
                _serviceHistories.AddServiceHistory(this, DateTime.Now, MaintenanceType.EngineMajor);
            }
        }

        public override void ServiceTransmission()
        {
            string prefix = $"[Debug][Truck Id {GetId()}]";
            Console.WriteLine(prefix + " Start Service Transmission");
            
            // Check for Transmission Fluid Change.
            if (travelledDistance > 800 && 
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.TransmissionFluidChange).GetDate() - 
                DateTime.Now > new TimeSpan(90, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Transmission Fluid Change");
                _serviceHistories.AddServiceHistory(this, DateTime.Today, MaintenanceType.TransmissionFluidChange);
            }

            // Check for Transmission Minor Change.
            if (travelledDistance > 2000 &&
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.TransmissionMinor).GetDate() -
                DateTime.Today > new TimeSpan(120, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Transmission Minor");
                _serviceHistories.AddServiceHistory(this, DateTime.Today, MaintenanceType.TransmissionMinor);
            }

            // Check for Transmission Overhaul.
            if (travelledDistance > 4000 &&
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.TransmissionMinor).GetDate() -
                DateTime.Today > new TimeSpan(240, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Transmission Major");
                _serviceHistories.AddServiceHistory(this, DateTime.Now, MaintenanceType.TransmissionOverhaul);
            }
        }

        public override void ServiceTires()
        {
            string prefix = $"[Debug][Truck Id {GetId()}]";
            Console.WriteLine(prefix + " Start Service Tires");
            
            // Check for Tires Adjustment.
            if (travelledDistance > 1000 && 
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.TiresAdjustment).GetDate() - 
                DateTime.Now > new TimeSpan(60, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Tires Adjustment");
                _serviceHistories.AddServiceHistory(this, DateTime.Today, MaintenanceType.TiresAdjustment);
            }

            // Check for Tires Replacement.
            if (travelledDistance > 3000 &&
                _serviceHistories.GetNearestMaintenanceOf(MaintenanceType.TiresReplacement).GetDate() -
                DateTime.Today > new TimeSpan(180, 0, 0, 0))
            {
                Console.WriteLine(prefix + " Performing Tires Replacement");
                _serviceHistories.AddServiceHistory(this, DateTime.Today, MaintenanceType.TiresReplacement);
            }
        }
        
        public override void ShowInfo()
        {
            Console.WriteLine("++++++++ TRUCK ++++++++");
            base.ShowInfo();
            Console.WriteLine($"Load Capacity: {_loadCapacity}");
            Console.WriteLine($"Tow Capacity: {_towCapacity}");
            Console.WriteLine("+++++++++++++++++++++++");
        }
    }
}
