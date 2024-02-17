using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umico
{
    public class Order
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public Product ProductItem { get; set; } 
        public Status Status { get; set; } = new Status();
         public PickUpPoint PickUpPoint { get; set; }= new PickUpPoint();
        public Customer Customer { get; set; } = new Customer();
    }
}
