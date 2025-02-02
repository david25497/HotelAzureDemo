using System;
using System.Collections.Generic;
using System.Text;

namespace HotelUltraGroup.Core.Application.Common.Interfaces
{
    public interface IEmailServices
    {
        bool EnviarEmailDePedidoConfirmado(string usuario, string emailDestino, string mensaje);
        string obtenerconfig();
    }
}
