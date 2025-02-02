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
    public interface IRoomRepository
    {
        Task<ResultBD<IEnumerable<sp_GetRoomsByHotel>>> GetRoomsWithRoomTypeAsync(int idUser, int idHotel);
        Task<ResultBD<string>> CreateRoomAsync(int idUser, Room room);
        Task<ResultBD<string>> UpdateRoomAsync(int idUser, Room room);
        Task<ResultBD<string>> UpdateRoomStatusAsync(int idUser, Room room);
        Task<ResultBD<string>> CreateTaxAsync(int idUser, Tax tax);
        Task<ResultBD<string>> UpdateTaxAsync(int idUser, Tax tax);
        Task<ResultBD<string>> AssignTaxToRoomAsync(int idUser, int idHotel, RoomTaxDetail roomTaxDetail);
        Task<ResultBD<string>> RemoveTaxFromRoomAsync(int idUser, int idHotel, RoomTaxDetail roomTaxDetail);
        Task<ResultBD<IEnumerable<sp_GetHotelTaxes>>> GetHotelTaxesAsync(int idUser, int idHotel);
    }
}
