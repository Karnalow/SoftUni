using P03.CommandPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.CommandPattern.Models
{
    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceActiot;
        private readonly int _amount;

        public ProductCommand(Product product, PriceAction priceActiot, int amount)
        {
            _product = product;
            _priceActiot = priceActiot;
            _amount = amount;
        }

        public void ExecuteAction()
        {
            if (_priceActiot == PriceAction.Increase)
            {
                _product.IncreasePrice(_amount);
            }
            else
            {
                _product.DecreasePrice(_amount);
            }
        }
    }
}
