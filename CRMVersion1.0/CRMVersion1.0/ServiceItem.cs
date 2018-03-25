using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMVersion1._0
{
   public class ServiceItem
    {
        public int Id { get; set; }
        public string  ServiceName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Total { get; set; }
        public int LineNumber { get; set; }
    }
}
