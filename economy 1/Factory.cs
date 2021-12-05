using System;
using System.Collections.Generic;
using System.Text;

namespace economy_1
{
    public class Factory
    {
        public String type { get; set; }
        public double maxOutput { get; set; }
        public String owner { get; set; }
        public double sellPrice { get; set; }
        double goodsBaseSellPrice { get; set; }
        double goodsSellPrice { get; set; }
        public int workers { get; set; }
        int maxWorkers { get; set; }
        public double salery { get; set; }
        public double inventory { get; set; }
        double money { get; set; } = 0;


        public Factory(String type)
        {
            this.type = type;

            if (this.type.Equals("Potato"))
            {
                this.maxOutput = 80;
                this.goodsBaseSellPrice = 10;
                this.maxWorkers = 10;
                this.workers = 0;
                this.salery = maxOutput * goodsBaseSellPrice / (2 * maxWorkers);
            }
        }

        public void Produce()
        {
            double output = maxOutput * workers / maxWorkers;
            inventory = inventory + output;
        }

        public double SellAll(double marketPrice)
        {
            double sold = inventory;
            inventory = 0;
            return sold;
        }

        public void ChangeMoney(double amount)
        {
            money = money + amount;
        }
        public double PaySalery()
        {
            money = money - salery;
            return salery;
        }

        public bool Hire()
        {
            if(maxWorkers == workers)
            {
                return false;
            }
            else
            {
                workers++;
                return true;
            }
        }

        public String GetOutput()
        {
            return "type = " + type + " workers = " + workers + "/" + maxWorkers + " money = " + money + " salery = " + salery + "/" + salery*workers + " production = " + maxOutput * workers / maxWorkers + "\n";
        }



    }
}
