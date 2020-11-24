using System;

namespace CarRentalService
{
    public abstract class Vehicle
    {
        private string _id;
        private string _brandName;
        private string _modelName;
        private int _year;
        private double _price;
        private string _color;
        private int _numberOfSeats;
        protected double travelledDistance;
        protected ServiceHistories _serviceHistories;

        public Vehicle(string id, string brandName, string modelName, int year, double price, string color, int numberOfSeats)
        {
            _id = id;
            _brandName = brandName;
            _modelName = modelName;
            _year = year;
            _price = price;
            _color = color;
            _numberOfSeats = numberOfSeats;
            _serviceHistories = new ServiceHistories();
        }

        public abstract void ServiceEngine();

        public abstract void ServiceTransmission();

        public abstract void ServiceTires();

        public virtual void ShowInfo()
        {
            Console.WriteLine("ID: " + _id);
            Console.WriteLine("Brand Name: " + _brandName);
            Console.WriteLine("Model Name: " + _modelName);
            Console.WriteLine("Year: " + _year);
            Console.WriteLine("Number of Seats: " + _numberOfSeats);
        }

        public string GetId()
        {
            return _id;
        }

        public void SetId(string id)
        {
            _id = id;
        }

        public string GetBrandName()
        {
            return _brandName;
        }

        public string GetModelName()
        {
            return _modelName;
        }

        public int GetYear()
        {
            return _year;
        }

        public double GetPrice()
        {
            return _price;
        }

        public string GetColor()
        {
            return _color;
        }

        public int GetNumberOfSeats()
        {
            return _numberOfSeats;
        }

        public double GetTravelledDistance()
        {
            return travelledDistance;
        }

        public void SetTravelledDistance(double travelledDistance)
        {
            this.travelledDistance = travelledDistance;
        }
    }
}
