using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_lab2
{
    class PostOffice
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Delivery> Deliveries { get; set; }

        public PostOffice(string location, List<Delivery>deliveries)
        {
            Id = ++_id;
            Location = location;
            Deliveries = deliveries;
        }
    }
}
