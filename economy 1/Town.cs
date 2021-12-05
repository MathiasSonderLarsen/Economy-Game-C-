using System;
using System.Collections.Generic;
using System.Text;

namespace economy_1
{
    public class Town
    {

        Storage storage = new Storage();
        List<Villiger> villigers = new List<Villiger>();
        Factory[] factories = { new Factory("Potato") };
        public String log { get; set; } = "";

        public Town()
        { 
        }

        public void CreateVilliger(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                villigers.Add(new Villiger());
            }
        }

        public void setStorageMoney(double money)
        {
            storage.money = money;
        }

        public void setStorageInventory(double[] amount, double[] price)
        {
            storage.setupVeg(amount, price);
        }

        private void VilligersBuy()
        {
            
            Random r = new Random();
            int rInt1;
            String name;
            double vegNeed;
            bool noMach = false;
            List<String> wholeList = new List<String>() { "Potato", "Carrot", "GreenBeans", "Cabage", "Collifolower", "Beets", "celery", "Peas", "Squash", "Pumpkin" };
            List<String> vegArray = new List<String>() { "Potato", "Carrot", "GreenBeans", "Cabage", "Collifolower", "Beets", "celery", "Peas", "Squash", "Pumpkin" };
            for (int i = 0; i < villigers.Count; i++) 
            {
                vegNeed = villigers[i].GetVegNeed();
                rInt1 = r.Next(0, vegArray.Count);
                name = vegArray[rInt1];
                
                while (storage.GetGoods(name).quantity < vegNeed / 2)
                {
                    vegArray.RemoveAt(rInt1);
                    if(vegArray.Count > 0)
                    {
                        rInt1 = r.Next(0, vegArray.Count);
                        name = vegArray[rInt1];
                    }
                    else
                    {
                        log = log.Insert(log.Length, "\n Not enough food!");
                        return;
                    }
                }

              
                
                storage.ChangeQuantity(name, -vegNeed / 2);
                villigers[i].ChangeMoney(storage.GetPriceOf(name, villigers.Count) * -vegNeed / 2);
                storage.ChangeMoney(storage.GetPriceOf(name, villigers.Count) * vegNeed / 2);
                villigers[i].ChangeVegNeed(vegNeed / 2);
                vegArray.RemoveAt(rInt1);
                log = log.Insert(log.Length, "Villiger " + i + " bought " + name + " - " + villigers[i].GetOutput() + "\n");
                
                

                if(vegArray.Count > 0)
                {
                    rInt1 = r.Next(0, vegArray.Count);
                    name = vegArray[rInt1];
                }

                while (storage.GetGoods(name).quantity < vegNeed / 2)
                {
                    vegArray.RemoveAt(rInt1);
                    if (vegArray.Count > 0)
                    {
                        rInt1 = r.Next(0, vegArray.Count);
                        name = vegArray[rInt1];
                    }
                    else
                    {
                        noMach = true;
                        break;
                    }
                }

                if (!noMach)
                {
                    storage.ChangeQuantity(name, -vegNeed / 2);
                    villigers[i].ChangeMoney(storage.GetPriceOf(name, villigers.Count) * -vegNeed / 2);
                    storage.ChangeMoney(storage.GetPriceOf(name, villigers.Count) * vegNeed / 2);
                    villigers[i].ChangeVegNeed(vegNeed / 2);
                    vegArray.RemoveAt(rInt1);
                    log = log.Insert(log.Length, "Villiger " + i + " bought " + name + " - " + villigers[i].GetOutput() + "\n");
                }
                else
                {
                    log = log.Insert(log.Length, "\n Not enough food!");
                }

                
                
                

                vegArray.Clear();
                vegArray.AddRange(wholeList);
            }
        }

        private void VilligersWork()
        {
            foreach(Villiger villiger in villigers)
            {
                if(villiger.hasJob)
                {
                    villiger.ChangeMoney(villiger.job.PaySalery());
                }
                else
                {
                    foreach(Factory factory in factories)
                    {
                        if (factory.Hire())
                        {
                            villiger.job = factory;
                            villiger.hasJob = true;
                        }
                    }
                }
            }
        }

        public void VilligersConsume()
        {
            foreach(Villiger villiger in villigers)
            {
                villiger.Consume();
            }
        }        

        private void Factoriesproduce()
        {
            foreach(Factory factory in factories)
            {
                factory.Produce();
            }
        }

        public void changeGoods(String name, double amount)
        {
            storage.ChangeQuantity(name, amount);
        }

        private void FacotriesSellAll()
        {
            
            foreach(Factory factory in factories)
            {
                foreach(Goods good in storage.GetInventory())
                {
                    if (factory.type.Equals(good.name))
                    {
                        double amountOfGoods = factory.SellAll(storage.GetPriceOf(good.name, villigers.Count));
                        double amountOfMoney = amountOfGoods * storage.GetPriceOf(good.name, villigers.Count);
                        storage.ChangeMoney(-amountOfMoney);
                        factory.ChangeMoney(amountOfMoney);
                        good.ChangeQuantity(amountOfGoods);
                    }
                }
                log = log.Insert(log.Length, factory.GetOutput());
            }

        }

       public double getFood()
        {
            return storage.getFood();
        }

        public String GetOutput()
        {
            String output = storage.GetOutput();
            return output;
        }

        public void turn()
        {
            Factoriesproduce();
            FacotriesSellAll(); //run after FactoriesProduce()
            VilligersWork(); //run after FactoriesProduce()
            VilligersBuy(); //run after VilligersWork()
            VilligersConsume(); //run after VilligersBuy()
            
        }
    }
}
