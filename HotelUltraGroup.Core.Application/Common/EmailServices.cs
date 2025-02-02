using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using System.Net.Mail;
using System.Runtime;
using HotelUltraGroup.Core.Domain.ValueObjets;
using System.Net;
using Microsoft.Extensions.Options;

namespace HotelUltraGroup.Core.Application.Common
{
    public class EmailServices : IEmailServices
    {
        private readonly EmailSettings _settings;

        public EmailServices(IOptions<EmailSettings> options) => (_settings) = (options.Value);

        public bool EnviarEmailDePedidoConfirmado(string usuario, string emailDestino, string mensaje)
        {

            try
            {
                // Configuración del cliente SMTP de Gmail
                SmtpClient client = new SmtpClient(_settings.Server, _settings.Port)
                {
                    Credentials = new NetworkCredential(_settings.Email, _settings.Password),
                    EnableSsl = true
                };

            string body = $@"
            <html>
            <body style='font-family: Arial, sans-serif;'>
                <h2 style='color: #4CAF50;'>Hola {usuario},</h2>
                <p>Esta es tu confirmación de reserva. ¡Esperamos que disfrutes tu estancia con nosotros!</p>
                <p><strong>Tu {mensaje} </strong> </p>
                <p style='margin-top: 20px;'>Gracias por elegirnos.</p>
                <p>Saludos,<br><em>El equipo de Hotel UltraGroup</em></p>
            </body>
            </html>";



                // Creación del correo
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("ingdavid.25497@gmail.com"),
                    Subject = "UltraGroup Prueba Reserva confirmada",
                    Body = body,
                    IsBodyHtml = true
                };

                // Dirección de destino
                mailMessage.To.Add(emailDestino);

                // Envío del correo
                client.Send(mailMessage);
                Console.WriteLine("Correo enviado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
            return true;


        }

        public string obtenerconfig()
        {

            try
            {
                string server = _settings.Server;
                if (server == null || string.IsNullOrEmpty(server))
                {
                    return "No se ha configurado el servidor";
                }
                return server;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
            return "error al obtener";


        }
    }
}
