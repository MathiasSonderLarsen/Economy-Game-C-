using System;
using System.Collections.Generic;
using System.Text;

namespace economy_1
{
    class Controller
    {
        Town[] towns = { new Town() };

        public Controller()
        {
            SetupTown1 setup = new SetupTown1();
            Prices prices = new Prices();

            towns[0].CreateVilliger(setup.villigers);
            towns[0].setStorageMoney(setup.money);
            towns[0].setStorageInventory(setup.vegSetup, prices.vegSetup);
            
        }
        public void turn()
        {
            towns[0].turn();
        }

        public String OutputTown()
        {
            String output = "";

            foreach(Town town in towns)
            {
                output = output.Insert(output.Length, town.GetOutput());
            }
            return output;
        }

        public String OutputLog()
        {
            String output = "";
           foreach(Town town in towns)
            {
                output = output.Insert(output.Length, town.log);
                town.log = "";
            }
            return output;
        }
    }
}
