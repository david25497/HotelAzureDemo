using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Domain.Stored_Procedure
{
    public class sp_GetDocumentTypeList
    {
        public int idDocumentType { get; set; }
        public string documentTypeName { get; set; }
        public string description { get; set; }
    }

}
