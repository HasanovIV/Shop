using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class CartList
    {
        public int Id { get; set; }
        
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        
        public int ChairId { get; set; }
        public virtual Chair Chair { get; set; }

        public int Count { get; set; }
        public int Price { get; set; }

    }
}
