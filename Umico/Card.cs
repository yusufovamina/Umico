using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umico
{
    public class CardClass
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public float Balance { get; set; }
        public int CVV { get; set; }
        public int MM { get; set; }
        public int YY { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
