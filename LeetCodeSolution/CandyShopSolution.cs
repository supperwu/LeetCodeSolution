using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    //William is the owner of a candy shop.
    //He uses a machine which takes few minutes to make one box of candies ready for delivery.
    //He receives an order for some boxes of candy which he needs to deliver as soon as possible.
    //He has a fixed amount of money to spend in order to make and deliver these boxes.
    //To complete the order, he can either purchase candy boxes from one of the shops or
    //he can purchase a new efficient machine or he can try to employ both the options together.
    //If he purchases a new machine, will no longer have access to the old machine.

    //Write an algorithm to find the minimum time in which William can deliver the order.

    //Input
    //The first line of the input consists of an integer numOfBox, representing the number of boxes that William has to deliver.
    //The second line consists of an integer prepare Time, representing the time required to prepare one box of candy using the machine.
    //The third line consists of an integer money, representing the money that he can spend.
    //The fourth line consists of two space-separated integers numMachines and numele, representing the number of machines available for purchase (M) and the number of characteristics associated to each machine (numele is always equal to 2), respectively.
    //The next M lines consist of E space-separated integers mTime and inCost, representing the time required by the machine to create a box and the cost of the machine, respectively.
    //The next line consists of two space-separated integers numShops and shopele, representing the number of shops available and the number of characteristics associated to each shop(shopele is always equal to 2), respectively.
    //The last 5 lines consist of C space-separated Integers-sNumand scost representing the number of boxes available in the shop and the cost to buy them, respectively.

    //Output
    //Print an integer representing the minimum time in which William can deliver the order.


    public class CandyShopSolution
    {
        public int GetMinTime()
        {
            int numOfBox = 20; //int.Parse(Console.ReadLine());
            int prepareTime = 10;
            int money = 90;

            string[] machineInfo = Console.ReadLine().Split();
            int numMachines = 3;

            //var machines = new (int mTime, int inCost)[numMachines];
            //for (int i = 0; i < numMachines; i++)
            //{
            //    var machineDetails = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //    machines[i] = (machineDetails[0], machineDetails[1]);
            //}

            Machine[] machines = new Machine[numMachines];
            machines[0] = new Machine { Time = 2, Cost = 30 };
            machines[1] = new Machine { Time = 3, Cost = 25 };
            machines[2] = new Machine { Time = 4, Cost = 10 };

            int numShops = 2;
            Shop[] shops = new Shop[numShops];
            shops[0] = new Shop { Nums = 5, Cost = 10 };
            shops[1] = new Shop { Nums = 15, Cost = 80 };
           // shops[2] = new Shop { Nums = 2, Cost = 20 };

            //output = 60

            int minTime = prepareTime * numOfBox;
            int time = ShopFirst(shops,machines,money,numOfBox,prepareTime);
            int time2 = MachineFirst(shops, machines, money, numOfBox, prepareTime);

            return Math.Min(time,time2);
        }

        public int ShopFirst(Shop[] shops, Machine[] machines, int money, int numOfBox, int prepareTime)
        {
            //int remainMoeny = money;
            int remainBox = numOfBox;
            var shop = shops.OrderByDescending(e => e.Efficient).FirstOrDefault(e=>e.Cost <= money);
            if (shop != null)
            {
                money = money - shop.Cost;
                remainBox = numOfBox - shop.Nums;
            }

            var machine = machines.OrderByDescending(e=>e.Efficient).FirstOrDefault(e=>e.Cost <= money);
            if (machine != null)
            {
                money = money - machine.Cost;
                prepareTime = machine.Time;
            }

            return remainBox * prepareTime;
        }

        public int MachineFirst(Shop[] shops, Machine[] machines, int money, int numOfBox, int prepareTime)
        {
            var machine = machines.OrderByDescending(e => e.Efficient).FirstOrDefault(e => e.Cost <= money);
            if (machine != null)
            {
                money = money - machine.Cost;
                prepareTime = machine.Time;
            }

            int remainBox = numOfBox;
            var shop = shops.OrderByDescending(e => e.Efficient).FirstOrDefault(e => e.Cost <= money);
            if (shop != null)
            {
                money = money - shop.Cost;
                remainBox = numOfBox - shop.Nums;
            }

            return remainBox * prepareTime;
        }

        public void Run()
        {
            GetMinTime();
        }
    }
}

public class Machine
{
    public int Time { get; set; }
    public int Cost { get; set; }

    public double Efficient
    {
        get { return Cost / Time; }
    }
}

public class Shop
{
    public int Nums { get; set; }
    public int Cost { get; set; }

    public double Efficient
    {
        get { return  Cost / Nums; }
    }
}
