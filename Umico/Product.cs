using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umico
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }

        public virtual List<int> CustomerId { get; set; }

        public virtual List<Customer?> CustomerObj { get; set; }
    }
}
