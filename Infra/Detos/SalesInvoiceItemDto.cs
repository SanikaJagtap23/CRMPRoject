using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Detos
{
    public class SalesInvoiceItemDto
    {
        public Int64 ItemID { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public bool IsFreeOrSample { get; set; }
    }
}
