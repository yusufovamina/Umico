using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umico
{
    public class Status
    {
        public int Id { get; set; }
        public bool OrderIsAccepted { get; set; }
        public bool OrderIsProcessed{ get; set; }
        public bool OrderIsDeliveredToPickUpPoint { get; set; }
        public bool Completed { get; set; }
        public bool OrderIsCanceled { get; set; }

    }
}
