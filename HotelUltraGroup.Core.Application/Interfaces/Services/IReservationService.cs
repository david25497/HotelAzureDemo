using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Interfaces.Services
{
    public interface IReservationService
    {   
        Task<IResultAPI<IEnumerable<ListGenderDTO>>> GetGenderListAsync();
        Task<IResultAPI<IEnumerable<ListDocumentTypeDTO>>> GetDocumentTypeListAsync();
        Task<IResultAPI<IEnumerable<ListCityDTO>>> GetCityListAsync();
        Task<IResultAPI<IEnumerable<ListAvailableHotelsDTO>>> GetAvailableHotelsAsync(DateTime checkInDate, DateTime checkOutDate, int numberOfPeople, int idCity);
        Task<IResultAPI<IEnumerable<ListAvailableHotelRoomsDTO>>> GetAvailableHotelRoomsAsync(int idHotel, DateTime checkInDate, DateTime checkOutDate, int numberOfPeople);
        Task<IResultAPI<string>> CreateReservationAsync(CreateReservationDTO createReservationDTO);
        Task<IResultAPI<string>> RegisterGuestAsync(CreateGuestDTO createGuestDTO);
    }

}
