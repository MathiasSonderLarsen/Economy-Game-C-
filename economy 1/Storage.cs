using System;
using System.Collections.Generic;
using System.Text;

namespace economy_1
{
    public class Storage
    {
        public double money { set; get; }
        List<Goods> inventory = new List<Goods>();

        public Storage()
        {

            String veg = "vegetable";
            inventory.Add(new Goods("Potato", veg));
            inventory.Add(new Goods("Carrot", veg ));
            inventory.Add(new Goods("GreenBeans", veg));
            inventory.Add(new Goods("Cabage", veg ));
            inventory.Add(new Goods("Collifolower", veg ));
            inventory.Add(new Goods("Beets", veg));
            inventory.Add(new Goods("celery", veg));
            inventory.Add(new Goods("Peas", veg));
            inventory.Add(new Goods("Squash", veg));
            inventory.Add(new Goods("Pumpkin", veg));

            String basic = "BasicGood";
            inventory.Add(new Goods("Pottery", basic));
            //pottery, utensils, fur, firewood, cheepCloths, furniture 


            String matr = "Matrerials";
            inventory.Add(new Goods("Clay", matr));
            //materials needed clay, metal, animals, wood, wool, fabric, tools 

        }

        public void setupVeg(double[] amount, double[] price)
        {
            for(int i = 0; i < amount.Length; i++)
            {
                inventory[i].quantity = amount[i];
                inventory[i].basePrice = price[i];
            }
        }

        public List<Goods> GetInventory()
        {
            return inventory;
        }
        
        public Goods GetGoods(String name)
        {
            Goods good = inventory.Find(Goods => Goods.name == name);
            return good;
        }

        public void ChangeMoney(double amount)
        {
            this.money = this.money + amount;
        }

        public void ChangeQuantity(String name, double amount)
        {
            Goods good = GetGoods(name);
            good.quantity = good.quantity + amount;
        }

        public double getFood()
        {
            double tempFood = 0;
            foreach(Goods i in inventory)
            {
                if (i.type.Equals("vegetable"))
                {
                    tempFood = tempFood + i.quantity;
                }
            }

            return tempFood;
        }

        public double GetPriceOf(String name, int noOfVilligers)
        {
            double price = 0;
            Goods good = GetGoods(name);
            double modifier;
            if (good.type == "vegetable")
            {
                modifier = noOfVilligers / good.quantity;
                if (modifier < 0.5)
                {
                    modifier = 0.5;
                }else if(modifier > 1.5)
                {
                    modifier = 1.5;
                }
                price = good.basePrice * (modifier);
            }

            return price;
        }

        public String GetOutput()
        {
            String output = "Total food =" + getFood() + "\n Potato = " + inventory[0].quantity.ToString() +
                "\n Carrot = " + inventory[1].quantity.ToString() + "\n Green beans = " + inventory[2].quantity.ToString() +
                "\n Cabage = " + inventory[3].quantity.ToString() + "\n Colliflower = " + inventory[4].quantity.ToString() +
                "\n Beets = " + inventory[5].quantity.ToString() + "\n Celery = " + inventory[6].quantity.ToString() +
                "\n Peas = " + inventory[7].quantity.ToString() + "\n Squash = " + inventory[8].quantity.ToString() +
                "\n Pumpkin = " + inventory[9].quantity.ToString() + "\n Money in storage = " + 
                money.ToString() + "\n\n\n";
            return output;
        }
    }
}

