using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<Item1, Item2, Item3>
    {
        public Threeuple(Item1 leftItem, Item2 middleItem, Item3 rightItem)
        {
            LeftItem = leftItem;
            MiddleItem = middleItem;
            RightItem = rightItem;
        }

        public Item1 LeftItem { get; set; }
        public Item2 MiddleItem { get; set; }
        public Item3 RightItem { get; set; }

        public string GetItems()
        {
            return $"{this.LeftItem} -> {this.MiddleItem} -> {this.RightItem}";
        }
    }
}
