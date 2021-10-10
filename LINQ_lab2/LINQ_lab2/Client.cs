using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_lab2
{
    public class Client
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Client(string name, string location)
        {
            Id = ++_id;
            Name = name;
            Location = location;
        }

        public override string ToString()
        {
            string result = $"Id:{Id}\nName:{Name}\nLocation:{Location}";
            return result;
        }
    }

    public static class ClientExtension
    {
        public static void PrintStudent(this Client client) =>
            Console.WriteLine(client.ToString());
    }
}
