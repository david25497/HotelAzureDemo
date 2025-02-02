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

namespace HotelUltraGroup.Infrastructure.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HotelContext _context;
        private readonly ErrorBD _errorBD;
        public ReservationRepository(HotelContext context, ErrorBD errorDBServices)
        {
            _context = context;
            _errorBD = errorDBServices;
        }

        public async Task<ResultBD<IEnumerable<sp_GetGenderList>>> GetGenderListAsync()
        {
            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var genders = await _context.genders
                    .FromSqlRaw("EXEC [hotel].GetGenderList")
                    .ToListAsync();

                return genders.AsEnumerable();
            }, "Error al obtener la lista de géneros.");
        }

        public async Task<ResultBD<IEnumerable<sp_GetDocumentTypeList>>> GetDocumentTypeListAsync()
        {
            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var documentTypes = await _context.documentTypes
                    .FromSqlRaw("EXEC [hotel].GetDocumentTypeList")
                    .ToListAsync();

                return documentTypes.AsEnumerable();
            }, "Error al obtener la lista de tipos de documentos.");
        }

        public async Task<ResultBD<IEnumerable<sp_GetCityList>>> GetCityListAsync()
        {
            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var cities = await _context.cities
                    .FromSqlRaw("EXEC [hotel].GetCityList")
                    .ToListAsync();

                return cities.AsEnumerable();
            }, "Error al obtener la lista de ciudades.");
        }


        public async Task<ResultBD<IEnumerable<sp_GetAvailableHotels>>> GetAvailableHotelsAsync(DateTime checkInDate, DateTime checkOutDate, int numberOfPeople, int idCity)
        {
            // Configuración de parámetros SQL
            var checkInDateParam = new SqlParameter("@checkInDate", checkInDate) { SqlDbType = SqlDbType.DateTime };
            var checkOutDateParam = new SqlParameter("@checkOutDate", checkOutDate) { SqlDbType = SqlDbType.DateTime };
            var numberOfPeopleParam = new SqlParameter("@numberOfPeople", numberOfPeople) { SqlDbType = SqlDbType.Int };
            var idCityParam = new SqlParameter("@idCity", idCity) { SqlDbType = SqlDbType.Int };

            // Ejecución del procedimiento almacenado
            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var hotels = await _context.availableHotels
                    .FromSqlRaw("EXEC [hotel].GetAvailableHotels @checkInDate, @checkOutDate, @numberOfPeople, @idCity",
                                checkInDateParam, checkOutDateParam, numberOfPeopleParam, idCityParam)
                    .ToListAsync();

                return hotels.AsEnumerable();
            }, "Error al obtener los hoteles disponibles.");
        }

        public async Task<ResultBD<IEnumerable<sp_GetAvailableHotelRooms>>> GetAvailableHotelRoomsAsync(int idHotel, DateTime checkInDate, DateTime checkOutDate, int numberOfPeople)
        {
            var idHotelParam = new SqlParameter("@idHotel", idHotel) { SqlDbType = SqlDbType.Int };
            var checkInDateParam = new SqlParameter("@checkInDate", checkInDate) { SqlDbType = SqlDbType.DateTime };
            var checkOutDateParam = new SqlParameter("@checkOutDate", checkOutDate) { SqlDbType = SqlDbType.DateTime };
            var numberOfPeopleParam = new SqlParameter("@numberOfPeople", numberOfPeople) { SqlDbType = SqlDbType.Int };



            // Ejecución del procedimiento almacenado
            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var rooms = await _context.availableHotelRooms
                 .FromSqlRaw("EXEC [hotel].GetAvailableHotelRooms @idHotel, @checkInDate, @checkOutDate, @numberOfPeople",
                   idHotelParam, checkInDateParam, checkOutDateParam, numberOfPeopleParam)
                 .ToListAsync();

                return rooms.AsEnumerable();
            }, "Error al obtener los hoteles disponibles.");

        }

        public async Task<ResultBD<string>> CreateReservationAsync(Reservation reservation)
        {
            var idHotelParam = new SqlParameter("@idHotel", reservation.idHotel) { SqlDbType = SqlDbType.Int };
            var idRoomParam = new SqlParameter("@idRoom", reservation.idRoom) { SqlDbType = SqlDbType.Int };
            var checkInDateParam = new SqlParameter("@checkInDate", reservation.checkInDate) { SqlDbType = SqlDbType.DateTime };
            var checkOutDateParam = new SqlParameter("@checkOutDate", reservation.checkOutDate) { SqlDbType = SqlDbType.DateTime };
            var fullNameParam = new SqlParameter("@fullName", reservation.fullName) { SqlDbType = SqlDbType.NVarChar };
            var emailParam = new SqlParameter("@email", reservation.reservationEmail.ToString()) { SqlDbType = SqlDbType.NVarChar };
            var emergencyContactNameParam = new SqlParameter("@emergencyContactName", reservation.emergencyContactName) { SqlDbType = SqlDbType.NVarChar };
            var emergencyContactPhoneParam = new SqlParameter("@emergencyContactPhone", reservation.emergencyContactPhone) { SqlDbType = SqlDbType.NVarChar };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                var reservationCode =  await _context.reservationCode
                    .FromSqlRaw(
                    "EXEC [hotel].CreateReservation @idHotel, @idRoom, @checkInDate, @checkOutDate, @fullName, @email, @emergencyContactName, @emergencyContactPhone",
                    idHotelParam, idRoomParam, checkInDateParam, checkOutDateParam, fullNameParam, emailParam, emergencyContactNameParam, emergencyContactPhoneParam).ToListAsync();

                return $"Codigo De Reserva: {reservationCode.FirstOrDefault().reservationCode}";
            }, "Error al crear la reserva.");
        }

        public async Task<ResultBD<string>> RegisterGuestAsync(string reservationCode, Guest guest)
        {
            // Configuración de parámetros SQL
            var reservationCodeParam = new SqlParameter("@reservationCode", reservationCode) { SqlDbType = SqlDbType.NVarChar, Size = 50 };
            var firstNameParam = new SqlParameter("@firstName", guest.firstName) { SqlDbType = SqlDbType.NVarChar, Size = 100 };
            var lastNameParam = new SqlParameter("@lastName", guest.lastName) { SqlDbType = SqlDbType.NVarChar, Size = 100 };
            var idGenderParam = new SqlParameter("@idGender", guest.idGender) { SqlDbType = SqlDbType.Int };
            var idDocumentTypeParam = new SqlParameter("@idDocumentType", guest.idDocumentType) { SqlDbType = SqlDbType.Int };
            var documentNumberParam = new SqlParameter("@documentNumber", guest.documentNumber) { SqlDbType = SqlDbType.NVarChar, Size = 255 };
            var emailParam = new SqlParameter("@email", guest.email.ToString()) { SqlDbType = SqlDbType.NVarChar, Size = 255 };
            var phoneParam = new SqlParameter("@phone", guest.phone) { SqlDbType = SqlDbType.NVarChar, Size = 20 };

            // Ejecución del procedimiento almacenado
            return await _errorBD.EjecutarOperacionDB(async () =>
            {
                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC [hotel].RegisterGuest @reservationCode, @firstName, @lastName, @idGender, @idDocumentType, @documentNumber, @email, @phone",
                    reservationCodeParam, firstNameParam, lastNameParam, idGenderParam, idDocumentTypeParam, documentNumberParam, emailParam, phoneParam
                );

                return "Registro de huésped exitoso";
            }, "Error al registrar el huésped.");
        }



    }



}
