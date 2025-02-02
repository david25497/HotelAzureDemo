namespace HotelUltraGroup.Core.Application.Common
{
    public class EmailSettings
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Server {  get; set; }
        public int Port { get; set; }
        public bool enableSsl { get; set; } 
    }
}
