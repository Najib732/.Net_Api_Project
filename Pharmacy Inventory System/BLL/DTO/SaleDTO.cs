using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SaleDTO
    {
       
            public int? ProductID { get; set; }
            public int? Quantity { get; set; }
            public DateTime? SaleDate { get; set; }
            public int? VoucharNo { get; set; }
            public int? Status { get; set; }
            public int? CustomerID { get; set; }
            public Nullable<decimal> price { get; set; }


    }

}
