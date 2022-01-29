using P02.Composite.Models;
using System;

namespace P02.Composite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SingleGift phone = new SingleGift("IPhone", 1000);

            phone.CalculateTotalPrice();
            Console.WriteLine();

            CompositeGift rootBox = new CompositeGift("RootBox", 0);
            SingleGift truckToy = new SingleGift("Truck", 15);
            SingleGift planeToy = new SingleGift("Plane", 5);

            rootBox.Add(truckToy);
            rootBox.Add(planeToy);

            CompositeGift childBox = new CompositeGift("ChildBox", 0);
            SingleGift soldierToy = new SingleGift("Soldier", 6);
            childBox.Add(soldierToy);
            childBox.Add(rootBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
        }
    }
}
