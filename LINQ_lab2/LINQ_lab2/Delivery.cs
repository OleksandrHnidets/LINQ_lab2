using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_lab2
{
    public class Delivery
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Destination { get; set; }
        public int Price { get; set; }

        public Delivery(int price, string destination)
        {
            Price = price;
            Id = ++_id;
            Destination = destination;
        }

        public override string ToString()
        {
            string result = $"id: {Id}\nPrice: {Price}\nDestination:{Destination}\n";
            return result;
        }
    }

    static class DeliveryExtension
    {
        public static void PrintDelivery(this Delivery delivery)
        {
            Console.WriteLine(delivery.ToString());
        }
    }
}
