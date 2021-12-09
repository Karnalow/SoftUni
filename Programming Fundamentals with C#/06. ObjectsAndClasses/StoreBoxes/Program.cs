using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box> output = new List<Box>();

            string[] data = Console.ReadLine().Split();

            while (data[0] != "end")
            {
                string serialNumber = data[0];
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                decimal itemPrice = decimal.Parse(data[3]);

                decimal priceForBox = itemQuantity * itemPrice;

                Box box = new Box();

                box.Name = itemName;
                box.Price = itemPrice;
                box.SerialNumber = serialNumber;
                box.Quantity = itemQuantity;
                box.PriceForBox = priceForBox;

                output.Add(box);
                
                data = Console.ReadLine().Split();
            }

            foreach (Box box in output.OrderByDescending(x => x.PriceForBox))
            {
                Console.WriteLine($"{box.SerialNumber}\n-- {box.Name} - ${box.Price:f2}: {box.Quantity}\n-- ${box.PriceForBox:f2}");
            }
        }
    }

    public class Box
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
        public decimal PriceForBox { get; set; }
    }
}
