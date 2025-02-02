using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Stored_Procedure
{
    public class sp_GetHotelTaxes
    {
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public decimal TaxRate { get; set; }
        public string TaxDescription { get; set; }
    }
}
