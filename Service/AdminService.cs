using System;

namespace CarRentalService
{
    public class AdminService
    {
        private readonly VehicleRentalManagement _vehicleRentalManagement;

        public AdminService(VehicleRentalManagement vehicleRentalManagement)
        {
            _vehicleRentalManagement = vehicleRentalManagement;
        }
        
        public void Service()
        {
            Console.WriteLine("----- Welcome to Admin Space -----");

            do
            {
                Console.WriteLine();
                Console.WriteLine("Please specify a choice: ");
                Console.WriteLine("1. View all vehicles.");
                Console.WriteLine("2. Add vehicle.");
                Console.WriteLine("3. Maintain fleet.");
                Console.WriteLine("0. Back.");

                Console.Write("* Your choice: ");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        ViewVehicles();
                        break;
                    case 2:
                        AddVehicle();
                        break;
                    case 3:
                        MaintainFleet();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("[!] Please re-enter the correct entry!");
                        break;
                }
            } while (true);
        }

        private void ViewVehicles()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Here is a list of vehicles: ");
            
            _vehicleRentalManagement.GetAllVehicles().ForEach(vehicle =>
            {
                vehicle.ShowInfo();
            });
        }

        private void AddVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("Please specify a choice: ");
            Console.WriteLine("1. Add Car.");
            Console.WriteLine("2. Add Truck.");
            Console.WriteLine("0. Back.");

            int input;
            do
            {
                Console.Write("* Your choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        AddTruck();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("[!] Please re-enter the correct entry!");
                        break;
                }
            } while (input < 0 || input > 2);
        }

        private void AddCar()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Please fill in all the required info.");
            Console.WriteLine("Field mark with (*) is required.");
            
            Console.Write("- Brand Name (*): ");
            string brandName = Console.ReadLine();
            
            Console.Write("- Model Name (*): ");
            string modelName = Console.ReadLine();

            Console.Write("- Year (*): ");
            int year = Util.ReadInt(Console.ReadLine(), -1);

            Console.Write("- Price: ");
            double price = Util.ReadInt(Console.ReadLine(), 0);
            
            Console.Write("- Color: ");
            string color = Console.ReadLine();
            
            Console.Write("- Number of Seats: ");
            int seats = Util.ReadInt(Console.ReadLine(), 2);
            
            Console.Write("- Number of Doors: ");
            int doors = Util.ReadInt(Console.ReadLine(), 4);
            
            Console.Write("- Has Air-Conditioner: ");
            bool ac = Util.ReadBool(Console.ReadLine(), false);
            
            Console.Write("- Has Gearbox: ");
            bool gb = Util.ReadBool(Console.ReadLine(), false);
            
            _vehicleRentalManagement.AddVehicle(brandName, modelName, year, price, color, seats, doors, gb, ac);
            
            Console.WriteLine();
            Console.WriteLine("[*] Successful [*]");
        }

        private void AddTruck()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Please fill in all the required info.");
            Console.WriteLine("Field mark with (*) is required.");
            
            Console.Write("- Brand Name (*): ");
            string brandName = Console.ReadLine();
            
            Console.Write("- Model Name (*): ");
            string modelName = Console.ReadLine();

            Console.Write("- Year (*): ");
            int year = Util.ReadInt(Console.ReadLine(), -1);

            Console.Write("- Price: ");
            double price = Util.ReadInt(Console.ReadLine(), 0);
            
            Console.Write("- Color: ");
            string color = Console.ReadLine();
            
            Console.Write("- Number of Seats: ");
            int seats = Util.ReadInt(Console.ReadLine(), 2);
            
            Console.Write("- Load capacity (*): ");
            double lc = Util.ReadDouble(Console.ReadLine(), 0);
            
            Console.Write("- Tow Capacity (*): ");
            double tc = Util.ReadDouble(Console.ReadLine(), 0);
            
            _vehicleRentalManagement.AddVehicle(brandName, modelName, year, price, color, seats, lc, tc);
            
            Console.WriteLine();
            Console.WriteLine("[*] Successful [*]");
        }

        private void MaintainFleet()
        {
            _vehicleRentalManagement.ServiceFleet();
            Console.WriteLine();
            Console.WriteLine("[*] All vehicles have been maintained! [*]");
        }
    }
}