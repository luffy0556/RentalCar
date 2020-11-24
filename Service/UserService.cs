using System;

namespace CarRentalService
{
    public class UserService
    {
        private readonly IBookAndRent _iBookAndRent;
        private readonly IContract _iContract;

        public UserService(IBookAndRent iBookAndRent, IContract iContract)
        {
            _iBookAndRent = iBookAndRent;
            _iContract = iContract;
        }

        public void Service()
        {
            Console.WriteLine("----- Welcome to User Space -----");

            do
            {
                Console.WriteLine();
                Console.WriteLine("Please specify a choice: ");
                Console.WriteLine("1. Rent a vehicle.");
                Console.WriteLine("0. Back.");

                Console.Write("* Your choice: ");
                
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Rent();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("[!] Please re-enter the correct entry!");
                        break;
                }
            } while (true);
        }

        private void Rent()
        {
            int input;

            do
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Please specify a choice:");
                Console.WriteLine("1. All.");
                Console.WriteLine("2. Car (Available Soon).");
                Console.WriteLine("3. Truck (Available Soon).");
                Console.WriteLine("0. Back.");
                
                Console.Write("* Your choice: ");
                
                input = Convert.ToInt32(Console.ReadLine());
                
                switch (input)
                {
                    case 1:
                    case 2:
                    case 3:
                        Vehicle vehicle = _iBookAndRent.ChooseVehicle();
                        Customer customer = _iBookAndRent.CreateCustomer();
                        Book book = _iBookAndRent.CreateBook(customer, vehicle);

                        _iContract.CreateContract(book);
                        
                        Console.WriteLine();
                        Console.WriteLine("[*] Thank you for using our service! [*]");

                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("[!] Please re-enter the correct entry!");
                        break;
                }
            } while (input < 0 || input > 2);
        }
    }
}