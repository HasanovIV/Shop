using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Address { get; set; }

        public int Summ { get; set; }

        public List<OrderList> OrderLists { get; set; }
    }
}
