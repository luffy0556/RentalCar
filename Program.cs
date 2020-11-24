using System;

namespace CarRentalService
{
    static class Program
    {
        static void Main(string[] args)
        {
            VehicleRentalManagement vehicleRentalManagement = new VehicleRentalManagement();
            RentManagement rentManagement = new RentManagement();

            UserService userService = new UserService(vehicleRentalManagement, rentManagement);
            AdminService adminService = new AdminService(vehicleRentalManagement);
            
            do
            {
                Console.WriteLine("----- Welcome to Vehicle Rental Service -----");
                Console.WriteLine();
                Console.WriteLine("Please specify your role");
                Console.WriteLine("1. User. (Rent vehicle,...)");
                Console.WriteLine("2. Admin. (View Vehicles, Add vehicles, Maintain vehicles,...)");
                Console.WriteLine("0. Exit.");
                Console.Write("* Your choice: ");
                
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        userService.Service();
                        break;
                    case 2:
                        adminService.Service();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("[!] Please re-enter the correct entry!");
                        break;
                }
            } while (true);
        }
    }
}