using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<ResultBD<IEnumerable<sp_GetGenderList>>> GetGenderListAsync();
        Task<ResultBD<IEnumerable<sp_GetDocumentTypeList>>> GetDocumentTypeListAsync();
        Task<ResultBD<IEnumerable<sp_GetCityList>>> GetCityListAsync();
        Task<ResultBD<IEnumerable<sp_GetAvailableHotels>>> GetAvailableHotelsAsync(DateTime checkInDate, DateTime checkOutDate, int numberOfPeople, int idCity);
        Task<ResultBD<IEnumerable<sp_GetAvailableHotelRooms>>> GetAvailableHotelRoomsAsync(int idHotel, DateTime checkInDate, DateTime checkOutDate, int numberOfPeople);
        Task<ResultBD<string>> CreateReservationAsync(Reservation reservation);
        Task<ResultBD<string>> RegisterGuestAsync(string reservationCode, Guest guest);
        
    }
}
