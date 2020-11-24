using System;
using System.Collections.Generic;

namespace CarRentalService
{
    public class RentManagement : IContract
    {
        private readonly List<Contract> _contracts = new List<Contract>();

        public Contract AddContract(Vehicle vehicle, Customer customer, DateTime dateRent, DateTime dateReturn)
        {
            Contract contract = new Contract(GetNextId(), "No description", customer, vehicle, dateRent, dateReturn, DateTime.Now);
            _contracts.Add(contract);
            return contract;
        }

        public Contract AddContract(Contract contract)
        {
            Contract ctr = new Contract(GetNextId(), "No description", contract.GetCustomer(), contract.GetVehicle(), contract.GetDateRented(), contract.GetDateReturn(), contract.GetContractDate(), contract.GetTotalPayment());
            _contracts.Add(ctr);
            return ctr;
        }

        public Contract CreateContract(Book book)
        {
            Console.WriteLine();
            Console.WriteLine("This is the final CONTRACT. Please read carefully.");

            Contract contract = new Contract(GetNextId(), "", book.GetCustomer(), book.GetVehicle(), 
                book.GetDateRent(), book.GetDateReturn(), DateTime.Today);
            
            contract.PrintInfo();

            int input;
            do
            {
                Console.WriteLine("1. Accept.");
                Console.WriteLine("2. Decline.");
                
                Console.Write("* Your choice: ");
                input = Convert.ToInt32(Console.ReadLine());
                
                if (input == 1)
                {
                    _contracts.Add(contract);
                }
            } while (input < 1 || input > 2);

            if (input == 2)
            {
                return null;
            }

            return contract;
        }
        
        private string GetNextId()
        {
            int nextId = 0;
            
            foreach (var contract in _contracts)
            {
                int current = Int32.Parse(contract.GetId());
                if (current > nextId)
                {
                    nextId = current;
                }
            }

            return (nextId + 1).ToString();
        }
    }
}