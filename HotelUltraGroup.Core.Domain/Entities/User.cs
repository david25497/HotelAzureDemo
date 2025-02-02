using HotelUltraGroup.Core.Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class User
    {
        public int id { get; private set; }
        public string userName { get; private set; }
        public Email email { get; private set; }
        public Password password { get; private set; }

        public User(string username, Email email, Password password)
        {
            this.userName = string.IsNullOrWhiteSpace(username)
                       ? throw new ArgumentException("El nombre de usuario es requerido.", "Error_Reglas") : username;
            this.email = email;
            this.password = password;
        }
    }
}
