using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Interfaces.Repositories
{
    public interface IHotelRepository
    {
        Task<ResultBD<IEnumerable<sp_GetHotels>>> GetHotelsAsync(int idUser);
        Task<ResultBD<string>> CreateHotelAsync(Hotel hotel);
        Task<ResultBD<string>> UpdateHotelAsync(Hotel hotel);
        Task<ResultBD<string>> UpdateStatusHotelAsync(Hotel hotel);
        Task<ResultBD<IEnumerable<sp_GetReservationsByHotel>>> GetReservationsByHotel(int idUser, int idHotel);
        Task<ResultBD<IEnumerable<sp_GetReservationDetail>>> GetReservationDetail(int idUser, int idHotel, int idReservation);


    }
}
