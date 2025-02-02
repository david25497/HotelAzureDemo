using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Interfaces.Services
{
    public interface IRoomService
    {
        Task<IResultAPI<IEnumerable<ListRoomWithRoomTypeDto>>> GetRoomsWithRoomTypeAsync(int idUser, int idHotel);
        Task<IResultAPI<string>> CreateRoomAsync(int idUser, CreateRoomDTO createRoomDTO);
        Task<IResultAPI<string>> UpdateRoomAsync(int idUser, UpdateRoomDTO updateRoomDTO);
        Task<IResultAPI<string>> UpdateRoomStatusAsync(int idUser, UpdateStatusRoomDTO updateStatusRoomDTO);
        Task<IResultAPI<string>> CreateTaxAsync(int idUser, CreateTaxDTO createTaxDTO);
        Task<IResultAPI<string>> UpdateTaxAsync(int idUser, UpdateTaxDTO updateTaxDTO);
        Task<IResultAPI<string>> AssignTaxToRoomAsync(int idUser,  RoomTaxAssignmentDTO roomTaxAssignmentDTO);
        Task<IResultAPI<string>> RemoveTaxFromRoomAsync(int idUser, RoomTaxAssignmentDTO roomTaxAssignmentDTO);
        Task<IResultAPI<IEnumerable<ListTaxDTO>>> GetHotelTaxesAsync(int idUser, int idHotel);
    }
}
