using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalService
{
    public class Customer
    {
        private string _name;
        private string _phone;
        private string _email;
        private string _address;

        public Customer(string name, string phone, string email, string address)
        {
            _name = name;
            _phone = phone;
            _email = email;
            _address = address;
        }

        public Customer(string name, string phone, string address)
        {
            _name = name;
            _phone = phone;
            _address = address;
            _email = null;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetPhone()
        {
            return _phone;
        }

        public string GetEmail()
        {
            return _email;
        }

        public string GetAddress()
        {
            return _address;
        }
    }
}
