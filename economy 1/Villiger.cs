using System;
using System.Collections.Generic;
using System.Text;

namespace economy_1
{
    public class Villiger
    {
        double money { get; set; } = 1000;
        double consumeFood { get; set; } = -2.0;
        public Factory job { get; set; }
        //needs
        double vegetablesNeed { get; set; } = 4;
        double vegetablesCurrent { get; set; } = 0.5;
        public bool hasJob { get; set; } = false;

        public Villiger() 
        {
           
        }

        public void ChangeMoney(double amount)
        {
            this.money = this.money + amount;
        }

        public double GetVegNeed()
        {
            return vegetablesNeed - vegetablesCurrent;
        }

        public void ChangeVegNeed(double amount)
        {
            this.vegetablesCurrent = this.vegetablesCurrent + amount;
        }

        public void Consume()
        {
            ChangeVegNeed(consumeFood);
        }

        public String GetOutput()
        {
            return "money = " + money + " - veg need = " + vegetablesCurrent;

        }
    }
}
