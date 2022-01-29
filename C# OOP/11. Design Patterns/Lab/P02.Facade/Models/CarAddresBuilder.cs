using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Facade.Models
{
    public class CarAddresBuilder : CarBuilderFacade
    {
        public CarAddresBuilder(Car car)
        {
            Car = car;
        }

        public CarAddresBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddresBuilder InAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
