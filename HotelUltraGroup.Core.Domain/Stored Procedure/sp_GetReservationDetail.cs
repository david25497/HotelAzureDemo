namespace HotelUltraGroup.Core.Domain.Stored_Procedure
{
    public class sp_GetReservationDetail
    {
        public int ReservationId { get; set; }
        public string ReservationCode { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string RoomName { get; set; }
        public decimal NightlyRate { get; set; }
        public int MaxGuestsAllowed { get; set; }
        public string RoomLocation { get; set; }
        public int StayDuration { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorTotalConImpuestos { get; set; }
    }
}
