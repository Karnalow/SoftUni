using P03.CommandPattern.Contracts;
using P03.CommandPattern.Models;
using System;

namespace P03.CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("IPhone", 500);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 500));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 50));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 10));

            Console.WriteLine(product);
        }

        public static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
    }
}
