using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderList
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ChairId { get; set; }
        public virtual Chair Chair { get; set; }

        public int Count { get; set; }
        public int Price { get; set; }

    }
}
