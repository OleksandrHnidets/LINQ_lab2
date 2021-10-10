using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_lab2
{
    public class DeliveryComparer:IComparer<Delivery>
    {
        int IComparer<Delivery>.Compare(Delivery d1, Delivery d2)
        {
            if (d1.Price > d2.Price)
                return 1;
            else if (d1.Price < d2.Price)
                return -1;
            else
                return 0;
        }
    }
}
