using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Domain.Stored_Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Interfaces.Services
{
    public interface IHotelService
    {
        Task<IResultAPI<IEnumerable<ListHotelDTO>>> GetHotelsAsync(int idUser);
        Task<IResultAPI<string>> CreateHotelAsync(int idUser, CreateHotelDTO createHotelDTO);
        Task<IResultAPI<string>> UpdateHotelAsync(int idUser, UpdateHotelDTO updateHotelDTO);
        Task<IResultAPI<string>> UpdateStatusHotelAsync(int idUser, UpdateStatusHotelDTO updateStatusHotelDTO);
        Task<IResultAPI<IEnumerable<ListReservationDTO>>> GetReservationsByHotel(int idUser, int idHotel);
        Task<IResultAPI<IEnumerable<ListReservationDetailDTO>>> GetReservationDetail(int idUser, int idHotel, int idReservation);

    }

}
