using System;

namespace CarRentalService
{
    public class Book
    {
        private Customer _customer;
        private Vehicle _vehicle;
        private string _description;
        private string _note;
        private DateTime _dateRent;
        private DateTime _dateReturn;

        public Book(Customer customer, Vehicle vehicle, string description, string note, DateTime dateRent,
            DateTime dateReturn)
        {
            _customer = customer;
            _vehicle = vehicle;
            _description = description;
            _note = note;
            _dateRent = dateRent;
            _dateReturn = dateReturn;
        }

        public Customer GetCustomer()
        {
            return _customer;
        }

        public Vehicle GetVehicle()
        {
            return _vehicle;
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetNote()
        {
            return _note;
        }

        public DateTime GetDateRent()
        {
            return _dateRent;
        }

        public DateTime GetDateReturn()
        {
            return _dateReturn;
        }
    }
}