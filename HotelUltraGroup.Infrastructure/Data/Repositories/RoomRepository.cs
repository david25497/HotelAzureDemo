using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Interfaces.Repositories;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;
using HotelUltraGroup.Infrastructure.Common;
using HotelUltraGroup.Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelUltraGroup.Infrastructure.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelContext _context;
        private readonly ErrorBD _errorBD;
        public RoomRepository(HotelContext context, ErrorBD errorDBServices)
        {
            _context = context;
            _errorBD = errorDBServices;
        }

        public async Task<ResultBD<IEnumerable<sp_GetRoomsByHotel>>> GetRoomsWithRoomTypeAsync(int idUser, int idHotel)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", idHotel) { SqlDbType = SqlDbType.Int };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var hotels = await _context.RoomsWithRoomType
                    .FromSqlRaw("EXEC [hotel].GetRoomsByHotel @idUser, @idHotel", idUserParam, idHotelParam)
                    .ToListAsync();

                return hotels.AsEnumerable();
            }, "Error al obtener las habitaciones.");
        }


        public async Task<ResultBD<string>> CreateRoomAsync(int idUser, Room room)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", room.idHotel) { SqlDbType = SqlDbType.Int };
            var idRoomTypeParam = new SqlParameter("@idRoomType", room.idRoomType) { SqlDbType = SqlDbType.Int };
            var nameParam = new SqlParameter("@name", room.name) { SqlDbType = SqlDbType.NVarChar };
            var locationParam = new SqlParameter("@location", room.location) { SqlDbType = SqlDbType.NVarChar };
            var nightlyRateParam = new SqlParameter("@nightlyRate", room.nightlyRate) { SqlDbType = SqlDbType.Decimal };
            var isAvailableParam = new SqlParameter("@isAvailable", room.isAvailable) { SqlDbType = SqlDbType.Bit };
            var capacityParam = new SqlParameter("@capacity", room.capacity) { SqlDbType = SqlDbType.Int };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].CreateRoom @idUser, @idHotel, @idRoomType, @name, @location, @nightlyRate, @isAvailable, @capacity",
                    idUserParam, idHotelParam, idRoomTypeParam, nameParam, locationParam, nightlyRateParam, isAvailableParam, capacityParam);
                return "Creación Exitosa";
            }, "Error en la creación");
        }

        public async Task<ResultBD<string>> UpdateRoomAsync(int idUser, Room room)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idRoomParam = new SqlParameter("@idRoom", room.idRoom) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", room.idHotel) { SqlDbType = SqlDbType.Int };
            var idRoomTypeParam = new SqlParameter("@idRoomType", room.idRoomType) { SqlDbType = SqlDbType.Int };
            var nameParam = new SqlParameter("@name", room.name) { SqlDbType = SqlDbType.NVarChar };
            var locationParam = new SqlParameter("@location", room.location) { SqlDbType = SqlDbType.NVarChar };
            var nightlyRateParam = new SqlParameter("@nightlyRate", room.nightlyRate) { SqlDbType = SqlDbType.Decimal };
            var capacityParam = new SqlParameter("@capacity", room.capacity) { SqlDbType = SqlDbType.Int };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].UpdateRoom @idUser, @idRoom, @idHotel, @idRoomType, @name, @location, @nightlyRate, @capacity",
                    idUserParam, idRoomParam, idHotelParam, idRoomTypeParam, nameParam, locationParam, nightlyRateParam, capacityParam);
                return "Actualización Exitosa";
            }, "Error en la actualizacion");
        }


        public async Task<ResultBD<string>> UpdateRoomStatusAsync(int idUser, Room room)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", room.idHotel) { SqlDbType = SqlDbType.Int };
            var idRoomParam = new SqlParameter("@idRoom", room.idRoom) { SqlDbType = SqlDbType.Int };
            var isAvailableParam = new SqlParameter("@isAvailable", room.isAvailable) { SqlDbType = SqlDbType.Bit };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].UpdateRoomStatus @idUser, @idHotel, @idRoom, @isAvailable",
                    idUserParam, idHotelParam, idRoomParam, isAvailableParam);
                return "Actualización Exitosa";
            }, "Error en la actualizacion");
        }


        public async Task<ResultBD<string>> CreateTaxAsync(int idUser, Tax tax)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", tax.idHotel) { SqlDbType = SqlDbType.Int };
            var nameParam = new SqlParameter("@name", tax.name) { SqlDbType = SqlDbType.NVarChar };
            var rateParam = new SqlParameter("@rate", tax.rate.Value) { SqlDbType = SqlDbType.Decimal };
            var descriptionParam = new SqlParameter("@description", tax.description) { SqlDbType = SqlDbType.NVarChar };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].CreateTax @idUser, @idHotel, @name, @rate, @description",
                    idUserParam, idHotelParam, nameParam, rateParam, descriptionParam);
                return "Creación Exitosa";
            }, "Error en la creación");
        }

        public async Task<ResultBD<string>> UpdateTaxAsync(int idUser, Tax tax)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idTaxParam = new SqlParameter("@idTax", tax.idTax) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", tax.idHotel) { SqlDbType = SqlDbType.Int };
            var nameParam = new SqlParameter("@name", tax.name) { SqlDbType = SqlDbType.NVarChar };
            var rateParam = new SqlParameter("@rate", tax.rate.Value) { SqlDbType = SqlDbType.Decimal };
            var descriptionParam = new SqlParameter("@description", tax.description) { SqlDbType = SqlDbType.NVarChar };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].UpdateTax @idUser, @idTax, @idHotel, @name, @rate, @description",
                    idUserParam, idTaxParam, idHotelParam, nameParam, rateParam, descriptionParam);
                return "Actualización Exitosa";
            }, "Error en la actualizacion");
        }


        public async Task<ResultBD<string>> AssignTaxToRoomAsync(int idUser, int idHotel, RoomTaxDetail roomTaxDetail)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idRoomParam = new SqlParameter("@idRoom", roomTaxDetail.idRoom) { SqlDbType = SqlDbType.Int };
            var idTaxParam = new SqlParameter("@idTax", roomTaxDetail.idTax) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", idHotel) { SqlDbType = SqlDbType.Int };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].AssignTaxToRoom @idUser, @idRoom, @idTax, @idHotel",
                    idUserParam, idRoomParam, idTaxParam, idHotelParam);
                return "Actualización Exitosa";
            }, "Error en la actualizacion");
        }

        public async Task<ResultBD<string>> RemoveTaxFromRoomAsync(int idUser, int idHotel, RoomTaxDetail roomTaxDetail)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idRoomParam = new SqlParameter("@idRoom", roomTaxDetail.idRoom) { SqlDbType = SqlDbType.Int };
            var idTaxParam = new SqlParameter("@idTax", roomTaxDetail.idTax) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", idHotel) { SqlDbType = SqlDbType.Int };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].RemoveTaxFromRoom @idUser, @idRoom, @idTax, @idHotel",
                    idUserParam, idRoomParam, idTaxParam, idHotelParam);
                return "Actualización Exitosa";
            }, "Error en la actualizacion");
        }

        public async Task<ResultBD<IEnumerable<sp_GetHotelTaxes>>> GetHotelTaxesAsync(int idUser, int idHotel)
        {
            var idUserParam = new SqlParameter("@idUser", idUser) { SqlDbType = SqlDbType.Int };
            var idHotelParam = new SqlParameter("@idHotel", idHotel) { SqlDbType = SqlDbType.Int };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var hotels = await _context.hotelTaxes
                    .FromSqlRaw("EXEC [hotel].GetHotelTaxes @idHotel, @idUser", idHotelParam, idUserParam)
                    .ToListAsync();

                return hotels.AsEnumerable();
            }, "Error al obtener las habitaciones.");
        }

    }



}
