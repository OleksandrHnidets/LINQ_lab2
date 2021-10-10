using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_lab2
{
    static class MockObjects
    {
        public static Client Client1 = new Client("Zelenskiy Dmytro", "Khmelnitsky");
        public static Client Client2 = new Client("Prokopiv Roman", "Lviv");
        public static Client Client3 = new Client("Kostiv Volodumyr", "Lviv");
        public static Client Client4 = new Client("Hnidets Oleksandr", "Kyiv");
        public static Client Client5 = new Client("Marko Yaciv", "Kyiv");

        public static Delivery Delivery1 = new Delivery(500, "Khmelnitsky");
        public static Delivery Delivery2 = new Delivery(250, "Kyiv");
        public static Delivery Delivery3 = new Delivery(1500, "Lviv");
        public static Delivery Delivery4 = new Delivery(100, "Lviv");

        public static List<Delivery> ListOfDeliveries1 = new List<Delivery>
        {
            Delivery1, Delivery2
        };
        public static List<Delivery> ListOfDeliveries2 = new List<Delivery>
        {
            Delivery3, Delivery4
        };

        public static PostOffice PostOffice1 = new PostOffice("Kyiv",ListOfDeliveries1);
        public static PostOffice PostOffice2 = new PostOffice("Lviv", ListOfDeliveries2);
        public static PostOffice PostOffice3 = new PostOffice("Khmelnitsky", ListOfDeliveries2);
    }
}
