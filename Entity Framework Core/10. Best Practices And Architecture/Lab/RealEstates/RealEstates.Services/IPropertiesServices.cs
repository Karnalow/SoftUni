using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services
{
    public interface IPropertiesServices
    {
        void Add(string district, int floor, int maxFloor, int size, int yardSize, int year, string propertyType, string buildingType, int price);
    }
}
