using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Chair
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public  string LongDesc { get; set; }
        public string Desc { get; set; }

        public string Img { get; set; }
        public ushort Price { get; set; }
        public bool IsFavourite { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
