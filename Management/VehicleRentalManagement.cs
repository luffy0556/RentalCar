using System;
using System.Collections.Generic;

namespace CarRentalService
{
    public class VehicleRentalManagement : IVehicleMaintenance, IBookAndRent
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public VehicleRentalManagement()
        {
            TestAddDummyVehicles();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            Console.WriteLine("[Debug][VehicleRentalManagement] Invoking method AddVehicle(Vehicle vehicle).");
            vehicle.SetId(GetNextId());
            _vehicles.Add(vehicle);
            
            Console.WriteLine();
            Console.WriteLine("Added Vehicle: ");
            vehicle.ShowInfo();
        }

        // For Method Overloading Testing Only. This should not be used.
        public void AddVehicle(string brandName, string modelName, int year, double price, string color, 
            int numberOfSeats, int numberOfDoors, bool hasGearbox, bool hasAirConditioner) 
        {
            Console.WriteLine();
            Console.WriteLine("[Debug][VehicleRentalManagement] Invoking method AddVehicle(string brandName, string modelName, int year, double price, string color, int numberOfSeats, int numberOfDoors, bool hasGearbox, bool hasAirConditioner).");
            Car car = new Car(GetNextId(), brandName, modelName, year, price, color, numberOfSeats, numberOfDoors, hasGearbox, hasAirConditioner);
            _vehicles.Add(car);
            
            Console.WriteLine();
            Console.WriteLine("Added Vehicle: ");
            car.ShowInfo();
        }

        // For Method Overloading Testing Only. This should not be used.
        public void AddVehicle(string brandName, string modelName, int year, double price, string color, 
            int numberOfSeats, double loadCapacity, double towCapacity) 
        {
            Console.WriteLine();
            Console.WriteLine("[Debug][VehicleRentalManagement] Invoking method AddVehicle(string brandName, string modelName, int year, double price, string color, int numberOfSeats, double loadCapacity, double towCapacity).");
            Truck truck = new Truck(GetNextId(), brandName, modelName, year, price, color, numberOfSeats, loadCapacity, towCapacity);
            _vehicles.Add(truck);
            
            Console.WriteLine();
            Console.WriteLine("Added Vehicle: ");
            truck.ShowInfo();
        }

        public void ServiceFleet()
        {
            _vehicles.ForEach(vehicle =>
            {
                vehicle.ServiceEngine();
                vehicle.ServiceTransmission();
                vehicle.ServiceTires();
            });
        }

        public void ServiceFleetEngine()
        {
            _vehicles.ForEach(vehicle => vehicle.ServiceEngine());
        }

        public void ServiceFleetTransmission()
        {
            _vehicles.ForEach(vehicle => vehicle.ServiceTransmission());
        }

        public void ServiceFleetTires()
        {
            _vehicles.ForEach(vehicle => vehicle.ServiceTires());
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public Vehicle GetVehicleById(string id)
        {
            return _vehicles.Find(vehicle => vehicle.GetId() == id);
        }
        
        public Vehicle ChooseVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Here is a list of available vehicles: ");
            
            GetAllVehicles().ForEach(vehicle =>
            {
                vehicle.ShowInfo();
            });

            Vehicle chosenVehicle;

            do
            {
                Console.Write("Please choose a vehicle of your favor by entering its id (or enter 0 to cancel): ");

                string id = Console.ReadLine();

                if (id == "0")
                {
                    return null;
                }

                chosenVehicle = GetVehicleById(id);

                if (chosenVehicle == null)
                {
                    Console.WriteLine("No vehicle with id \"" + id + "\" is found.");
                }
            } while (chosenVehicle == null);

            return chosenVehicle;
        }

        public Customer CreateCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Please fill in all the required info.");
            Console.WriteLine("Field mark with (*) is required.");
            
            Console.Write("- Your name (*): ");
            string name = Console.ReadLine();
            
            Console.Write("- Your phone number (*): ");
            string phone = Console.ReadLine();
            
            Console.Write("- Your address (*): ");
            string address = Console.ReadLine();
            
            Console.Write("- Your email address: ");
            string email = Console.ReadLine();
            
            Customer customer = new Customer(name, phone, email, address);

            return customer;
        }

        public Book CreateBook(Customer customer, Vehicle vehicle)
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Please fill in all the required info.");
            Console.WriteLine("Field mark with (*) is required.");
            
            Console.Write("- The date your you will be renting (Enter the amount of days after today) (*): ");
            int i1 = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("- How many days you will be renting (*): ");
            int i2 = Convert.ToInt32(Console.ReadLine());
            
            DateTime start = DateTime.Today.AddDays(i1);
            DateTime end = start.AddDays(i2);
            
            Book book = new Book(customer, vehicle, "No description", "", start, end);
            
            return book;
        }

        private string GetNextId()
        {
            int nextId = 0;
            
            foreach (var vehicle in _vehicles)
            {
                int current = Int32.Parse(vehicle.GetId());
                if (current > nextId)
                {
                    nextId = current;
                }
            }

            return (nextId + 1).ToString();
        }

        private void TestAddDummyVehicles()
        {
            AddVehicle("Brand 1", "Model 1", 2010, 100000, "Red", 4, 4, true, true);
            AddVehicle("Brand 2", "Model 2", 2014, 300000, "Black", 4, 4, true, true);
            AddVehicle("Brand 3", "Model 3", 2009, 250000, "White", 4, 100, 100);
            AddVehicle("Brand 4", "Model 4", 2019, 100000, "White", 4, 4, false, true);
            AddVehicle("Brand 5", "Model 5", 2009, 250000, "White", 4, 200, 250);
        }

        public void TestSimulateTravelledDistance()
        {
            Random random = new Random();
            
            foreach (var vehicle in _vehicles)
            {
                vehicle.SetTravelledDistance(random.NextDouble() * 50000);
            }
        }
    }
}