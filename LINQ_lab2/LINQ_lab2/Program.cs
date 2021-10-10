using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_lab2
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Client> allClients = new List<Client>()
            {
                MockObjects.Client1,
                MockObjects.Client2,
                MockObjects.Client3
            };
            List<Delivery> allDeliveries = new List<Delivery>()
            {
                MockObjects.Delivery1,
                MockObjects.Delivery2,
                MockObjects.Delivery3,
                MockObjects.Delivery4
            };
            List<PostOffice> allPostOffices = new List<PostOffice>()
            {
                MockObjects.PostOffice1,
                MockObjects.PostOffice2,
                MockObjects.PostOffice3
            };

            // 1) LINQ - OrderBy
            IEnumerable<Client> sortedByNames = allClients
                .OrderBy(c => c.Name);
            Console.WriteLine("Clients sorted by names");
            Console.WriteLine("---------------");
            foreach (var client in sortedByNames)
            {
                Console.WriteLine(String.Format("id:{0}\nName: {1}", client.Id, client.Name));
            }

            // 2) LINQ - Where
            IEnumerable<Client> clientsFromLviv = allClients
                .Where(c => c.Location.Equals("Lviv"));
            Console.WriteLine("Clients who live in Lviv");
            Console.WriteLine("---------------");
            foreach (var client in clientsFromLviv)
            {
                //Console.WriteLine($"id: {client.Id}\nName: {client.Name}");
                Console.WriteLine(String.Format("id: {0}\nName: {1}", client.Id, client.Name));
            }

            // 3) LINQ - Count
            int delCount = allDeliveries
                .Count(d => d.Price < 1000);
            Console.WriteLine("---------------");
            Console.WriteLine(String.Format("Count of deliveries with price less than 1000 UAH: {0}", delCount));
            Console.WriteLine("---------------");
            // 4) LINQ - Where + Join + Anonymous type
            var joinResult = allClients
                .Where(c => c.Name.Length > 12)
                .Join(allPostOffices,
                    c => c.Location,
                    p => p.Location,
                    (c, p) =>
                        new
                        {
                            Receiver = c.Name, ReceiverLocation = c.Location, PostOfficeID = p.Id,
                            PostOfficeLocation = p.Location
                        });
            Console.WriteLine("Clients and PostOffices in the same location");
            Console.WriteLine("---------------");
            foreach (var obj in joinResult)
            {
                Console.WriteLine(String.Format("Client: {0}, Client location: {1}" +
                                                "\nPost office: {2}, Post office location: {3}\n "
                    , obj.Receiver, obj.ReceiverLocation, obj.PostOfficeID, obj.PostOfficeLocation));
            }

            // 5) LINQ - Select
            IEnumerable<int> deliveryPrices = allDeliveries.Select(d => d.Price);
            Console.WriteLine("Delivery prices");
            Console.WriteLine("---------------");
            foreach (var price in deliveryPrices)
            {
                Console.WriteLine(String.Format("{0}\n", price));
            }
            
            // 6) LINQ- ToArray
            Delivery[] copyOfDeliveryList = allDeliveries.ToArray();
            // IComparer interface usage
            Array.Sort(copyOfDeliveryList, new DeliveryComparer());
            Console.WriteLine("Using IComparer to compare delivery prices");
            Console.WriteLine("---------------");
            // My extension method
            foreach (var delivery in copyOfDeliveryList)
            {
                delivery.PrintDelivery();
            }

            // 7) LINQ - All
            bool IsAllDelInLviv = allDeliveries
                .All(d => d.Destination.Equals("Lviv")); 
            Console.WriteLine("---------------");
            Console.WriteLine(String.Format("Are all deliveries going to Lviv: {0}",IsAllDelInLviv));
            Console.WriteLine("---------------");

            // 8) LINQ - Union
            IEnumerable<Delivery> unionOfListsDeliveries = MockObjects.ListOfDeliveries1
                .Union(MockObjects.ListOfDeliveries2);
            Console.WriteLine("Union of 'ListOfDeliveries1' and 'ListOfDeliveries2'");
            Console.WriteLine("---------------");
            foreach (var delivery in unionOfListsDeliveries)
            {
                delivery.PrintDelivery();
            }

            Console.WriteLine("Done!");
        }
    }
}
