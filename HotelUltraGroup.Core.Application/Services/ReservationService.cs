using AutoMapper;
using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Application.Interfaces.Repositories;
using HotelUltraGroup.Core.Application.Interfaces.Services;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HotelUltraGroup.Core.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailServices _emailService;
        public ReservationService(IReservationRepository Repository, IMapper mapper, IEmailServices emailService)
        {
            _repository = Repository;
            _mapper = mapper;
            _emailService = emailService;
        }


        public async Task<IResultAPI<IEnumerable<ListGenderDTO>>> GetGenderListAsync()
        {
            try
            {
                var result = await _repository.GetGenderListAsync();

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListGenderDTO>>.Fail(result.Message);

                if (result.Data.Count() <= 0)
                    return ResultAPI<IEnumerable<ListGenderDTO>>.Fail("Sin coincidencias encontradas");

                var resultDTO = _mapper.Map<IEnumerable<ListGenderDTO>>(result.Data);
                return ResultAPI<IEnumerable<ListGenderDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListGenderDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListGenderDTO>());
            }
        }
        public async Task<IResultAPI<IEnumerable<ListDocumentTypeDTO>>> GetDocumentTypeListAsync()
        {
            try
            {
                var result = await _repository.GetDocumentTypeListAsync();

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListDocumentTypeDTO>>.Fail(result.Message);

                if (result.Data.Count() <= 0)
                    return ResultAPI<IEnumerable<ListDocumentTypeDTO>>.Fail("Sin coincidencias encontradas");

                var resultDTO = _mapper.Map<IEnumerable<ListDocumentTypeDTO>>(result.Data);
                return ResultAPI<IEnumerable<ListDocumentTypeDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListDocumentTypeDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListDocumentTypeDTO>());
            }
        }
        public async Task<IResultAPI<IEnumerable<ListCityDTO>>> GetCityListAsync()
        {
            try
            {
                var result = await _repository.GetCityListAsync();

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListCityDTO>>.Fail(result.Message);

                if (result.Data.Count() <= 0)
                    return ResultAPI<IEnumerable<ListCityDTO>>.Fail("Sin coincidencias encontradas");

                var resultDTO = _mapper.Map<IEnumerable<ListCityDTO>>(result.Data);
                return ResultAPI<IEnumerable<ListCityDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListCityDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListCityDTO>());
            }
        }
        public async Task<IResultAPI<IEnumerable<ListAvailableHotelsDTO>>> GetAvailableHotelsAsync(DateTime checkInDate, DateTime checkOutDate, int numberOfPeople, int idCity)
        {
            try
            {
                var result = await _repository.GetAvailableHotelsAsync(checkInDate, checkOutDate, numberOfPeople, idCity);

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListAvailableHotelsDTO>>.Fail(result.Message);

                if (result.Data.Count() <= 0)
                    return ResultAPI<IEnumerable<ListAvailableHotelsDTO>>.Fail("Sin coincidencias encontradas");

                var resultDTO = _mapper.Map<IEnumerable<ListAvailableHotelsDTO>>(result.Data);
                return ResultAPI<IEnumerable<ListAvailableHotelsDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListAvailableHotelsDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListAvailableHotelsDTO>());
            }
        }

        public async Task<IResultAPI<IEnumerable<ListAvailableHotelRoomsDTO>>> GetAvailableHotelRoomsAsync(int idHotel, DateTime checkInDate, DateTime checkOutDate, int numberOfPeople)
        {
            try
            {
                var result = await _repository.GetAvailableHotelRoomsAsync(idHotel, checkInDate, checkOutDate, numberOfPeople);

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListAvailableHotelRoomsDTO>>.Fail(result.Message);

                if (result.Data.Count() <= 0)
                    return ResultAPI<IEnumerable<ListAvailableHotelRoomsDTO>>.Fail("Sin coincidencias encontradas");

                var resultDTO = _mapper.Map<IEnumerable<ListAvailableHotelRoomsDTO>>(result.Data);
                return ResultAPI<IEnumerable<ListAvailableHotelRoomsDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListAvailableHotelRoomsDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListAvailableHotelRoomsDTO>());
            }
        }

        public async Task<IResultAPI<string>> CreateReservationAsync(CreateReservationDTO createReservationDTO)
        {

            try
            {               
                var reservation = new Reservation(createReservationDTO.idHotel, createReservationDTO.idRoom, createReservationDTO.checkInDate, createReservationDTO.checkOutDate, createReservationDTO.fullName, new Email(createReservationDTO.reservationEmail) , createReservationDTO.emergencyContactName, createReservationDTO.emergencyContactPhone);


                var result = await _repository.CreateReservationAsync(reservation);

                if (!result.IsSuccess)
                    return ResultAPI<string>.Fail(result.Message);

                _emailService.EnviarEmailDePedidoConfirmado(createReservationDTO.fullName, createReservationDTO.reservationEmail, result.Data);

                return ResultAPI<string>.Success(result.Data);
            }
            catch (ArgumentException ex) when (ex.ParamName == "Error_Reglas")
            {
                return ResultAPI<string>.Fail("Error" + ex.Message);
            }
            catch (Exception ex)
            {
                return ResultAPI<string>.Fail("Se ha producido un error interno"  + ex.Message);
            }
        }


        public async Task<IResultAPI<string>> RegisterGuestAsync(CreateGuestDTO createGuestDTO)
        {
            try
            {
                var guest = new Guest(createGuestDTO.firstName, createGuestDTO.lastName, createGuestDTO.idGender, createGuestDTO.idDocumentType, createGuestDTO.documentNumber, new Email(createGuestDTO.email), createGuestDTO.phone);

                var result = await _repository.RegisterGuestAsync(createGuestDTO.reservationCode, guest);

                if (!result.IsSuccess)
                    return ResultAPI<string>.Fail(result.Message);

                return ResultAPI<string>.Success(result.Data);
            }
            catch (ArgumentException ex) when (ex.ParamName == "Error_Reglas")
            {
                return ResultAPI<string>.Fail("Error" + ex.Message);
            }
            catch (Exception ex)
            {
                return ResultAPI<string>.Fail("Se ha producido un error interno");
            }
        }


    }
}
