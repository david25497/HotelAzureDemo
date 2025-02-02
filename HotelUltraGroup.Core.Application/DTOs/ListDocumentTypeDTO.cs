using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.DTOs
{
    public class ListDocumentTypeDTO
    {
        public int idDocumentType { get; set; }
        public string documentTypeName { get; set; }
        public string description { get; set; }
    }
}
