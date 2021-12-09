using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {


        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private int engineIndex;
        private int tiresIndex;

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumptionint, int engineIndex, int tiresIndex)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            EngineIndex = engineIndex;
            TiresIndex = tiresIndex;
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }


        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public int EngineIndex
        {
            get { return engineIndex; }
            set { engineIndex = value; }
        }


        public int TiresIndex
        {
            get { return tiresIndex; }
            set { tiresIndex = value; }
        }

    }
}
