using System;
using System.Collections.Generic;
using System.Text;

namespace economy_1
{
    class SetupTown1
    {
        //villigers
        public int villigers { get; } = 20;

        //money
        public double money { get; } = 10000;



        //goods

        //veg
        //oder: potato, carrot, greenbeans, cabage, colliflower, beets, celery, peas, squash, pumpkin
        public double[] vegSetup { get; } = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

        //basicGoods
        //oder: pottery
        public double[] basicGoodsSetup { get; } = { 10 };

        //materials
        //oder: clay
        public double [] materialsSetup { get; } = { 10 };
        



    }
}
