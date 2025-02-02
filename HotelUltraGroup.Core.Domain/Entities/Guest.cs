using HotelUltraGroup.Core.Domain.ValueObjets;
using System;

namespace HotelUltraGroup.Core.Domain.Entities
{
    public class Guest
    {
        public int id { get; private set; }
        public int idReservation { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public int idGender { get; private set; }
        public int idDocumentType { get; private set; }
        public string documentNumber { get; private set; }
        public Email email { get; private set; }
        public string phone { get; private set; }

        public Guest(string firstName, string lastName, int idGender, int idDocumentType, string documentNumber, Email email, string phone)
        {
            this.firstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentException("First name is required.");
            this.lastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentException("Last name is required.");
            this.idGender = idGender;
            this.idDocumentType = idDocumentType;
            this.documentNumber = !string.IsNullOrWhiteSpace(documentNumber) ? documentNumber : throw new ArgumentException("Document number is required.");
            this.email = email;
            this.phone = phone ?? throw new ArgumentException("Phone is required.");
        }
    }
}
