using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class ListTaxDTO
    {
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public decimal TaxRate { get; set; }
        public string TaxDescription { get; set; }
    }
}
