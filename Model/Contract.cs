using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalService
{
    public class Contract
    {
        private string _id;
        private string _title = "VEHICLE RENTAL CONTRACT";
        private string _description;
        private Customer _customer;
        private Vehicle _vehicle;
        private DateTime _dateRented;
        private DateTime _dateReturn;
        private DateTime _contractDate;
        private double _totalPayment;
        private double _extraPayment;
        private double _insurancePayment;
        private double _damagePayment;

        public Contract(string id, string description, Customer customer, Vehicle vehicle,
            DateTime dateRented, DateTime dateReturn, DateTime contractDate, double totalPayment = 0)
        {
            _id = id;
            _description = description;
            _customer = customer;
            _vehicle = vehicle;
            _dateRented = dateRented;
            _dateReturn = dateReturn;
            _contractDate = contractDate;
            _totalPayment = totalPayment;
        }

        public string GetId()
        {
            return _id;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetDescription()
        {
            return _description;
        }

        public Customer GetCustomer()
        {
            return _customer;
        }

        public Vehicle GetVehicle()
        {
            return _vehicle;
        }

        public DateTime GetDateRented()
        {
            return _dateRented;
        }

        public DateTime GetDateReturn()
        {
            return _dateReturn;
        }

        public DateTime GetContractDate()
        {
            return _contractDate;
        }

        public double GetTotalPayment()
        {
            return _totalPayment;
        }

        public void SetTotalPayment(double amount)
        {
            _totalPayment = amount;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"======== {_title} ========");
            Console.WriteLine("Contract ID: " + _id);
            Console.WriteLine("*** Customer Information ***");
            Console.WriteLine("Customer Name: " + _customer.GetName());
            Console.WriteLine("Customer Phone: " + _customer.GetPhone());
            Console.WriteLine("Customer Address: " + _customer.GetAddress());
            Console.WriteLine("Customer Email: " + _customer.GetEmail());
            Console.WriteLine("*** Vehicle Information ***");
            _vehicle.ShowInfo();
            Console.WriteLine("Date rent: " + _dateRented.ToShortDateString());
            Console.WriteLine("Date return: " + _dateReturn.ToShortDateString());
            Console.WriteLine("Total Payment: " + _totalPayment);
            Console.WriteLine("=======================================");
        }
    }
}
