using System;
using System.Collections.Generic;
using System.Text;

namespace economy_1
{
    public class Goods
    {
        public String name { get; set; }
        public double quantity { get; set; } = 0;
        public String type{ get; set; } 
        public double basePrice { get; set; }

        public Goods(String name, String type) 
        {
            this.name = name;
            this.type = type;
        }

        public void ChangeQuantity(double amount)
        {
            this.quantity = this.quantity + amount;
        }


        
    }
}
