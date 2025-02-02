using HotelUltraGroup.Core.Domain.ValueObjets;
using System;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class Reservation
    {
        public int idReservation { get; private set; }
        public int idHotel { get; private set; }
        public int idRoom { get; private set; }
        public DateTime reservationDate { get; private set; }
        public DateTime checkInDate { get; private set; }
        public DateTime checkOutDate { get; private set; }
        public int guestCount { get; private set; }
        public decimal fixedNightlyRate { get; private set; }
        public string fullName { get; private set; }
        public Email reservationEmail { get; private set; }
        public string reservationCode { get; private set; }
        public string emergencyContactName { get; private set; }
        public string emergencyContactPhone { get; private set; }

        // Constructor para crear una nueva reserva
        public Reservation(int idHotel, int idRoom, DateTime checkInDate, DateTime checkOutDate, string fullName, Email reservationEmail,  string emergencyContactName, string emergencyContactPhone)
        {
            this.idHotel = idHotel;
            this.idRoom = idRoom;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.fullName = string.IsNullOrWhiteSpace(fullName) ? throw new ArgumentException("El nombre completo es obligatorio.", "Error_Reglas") : fullName;
            this.reservationEmail =reservationEmail;
            this.emergencyContactName = string.IsNullOrWhiteSpace(emergencyContactName) ? throw new ArgumentException("El nombre del contacto de emergencia es obligatorio.", "Error_Reglas") : emergencyContactName;
            this.emergencyContactPhone = string.IsNullOrWhiteSpace(emergencyContactPhone) ? throw new ArgumentException("El teléfono del contacto de emergencia es obligatorio.", "Error_Reglas") : emergencyContactPhone;
        }


    }
}
