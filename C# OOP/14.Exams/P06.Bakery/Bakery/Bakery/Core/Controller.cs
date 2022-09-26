using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> foods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);

            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            else if (type == "Bread")
            {
                food = new Bread(name, price);
            }

            this.foods.Add(food);

            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables)
            {
                if (table.IsReserved == false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, this.totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var searchedTable = this.tables.Find(t => t.TableNumber == tableNumber);

            decimal bill = searchedTable.GetBill();
            this.totalIncome += bill;
            searchedTable.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var searchedTable = this.tables.Find(t => t.TableNumber == tableNumber);
            var searchedDrink = this.drinks.Find(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (searchedTable == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (searchedDrink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            searchedTable.OrderDrink(searchedDrink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var searchedTable = this.tables.Find(t => t.TableNumber == tableNumber);
            var searchedFood = this.foods.Find(f => f.Name == foodName);

            if (searchedTable == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (searchedFood == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            searchedTable.OrderFood(searchedFood);

            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            foreach (var table in this.tables)
            {
                if (table.Capacity >= numberOfPeople)
                {
                    if (table.IsReserved == false)
                    {
                        table.Reserve(numberOfPeople);

                        return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
                    }
                }
            }

            return $"No available table for {numberOfPeople} people";
        }
    }
}
