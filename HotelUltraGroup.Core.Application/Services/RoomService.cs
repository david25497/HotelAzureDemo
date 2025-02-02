using AutoMapper;
using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Application.Interfaces.Repositories;
using HotelUltraGroup.Core.Application.Interfaces.Services;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;
using HotelUltraGroup.Core.Domain.ValueObjets;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository userRepository, IMapper mapper)
        {
            _repository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResultAPI<IEnumerable<ListRoomWithRoomTypeDto>>> GetRoomsWithRoomTypeAsync(int idUser, int idHotel)
        {
            try
            {
                var result = await _repository.GetRoomsWithRoomTypeAsync(idUser, idHotel);

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListRoomWithRoomTypeDto>>.Fail(result.Message);

                var resultDTO = _mapper.Map<IEnumerable<ListRoomWithRoomTypeDto>>(result.Data);
                return ResultAPI<IEnumerable<ListRoomWithRoomTypeDto>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListRoomWithRoomTypeDto>>.Fail("Se ha producido un error al convertir la información", new List<ListRoomWithRoomTypeDto>());
            }
        }

        public async Task<IResultAPI<string>> CreateRoomAsync(int idUser, CreateRoomDTO createRoomDTO)
        {
            try
            {
                var room = new Room(
                createRoomDTO.idHotel, createRoomDTO.name, createRoomDTO.idRoomType, createRoomDTO.nightlyRate, createRoomDTO.capacity, createRoomDTO.location);

                var result = await _repository.CreateRoomAsync(idUser, room);

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

        public async Task<IResultAPI<string>> UpdateRoomAsync(int idUser, UpdateRoomDTO updateRoomDTO)
        {
            try
            {
                var room = new Room(
                updateRoomDTO.idRoom, updateRoomDTO.idHotel, updateRoomDTO.name, updateRoomDTO.idRoomType, updateRoomDTO.nightlyRate, updateRoomDTO.capacity, updateRoomDTO.location);

                var result = await _repository.UpdateRoomAsync(idUser, room);

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


        public async Task<IResultAPI<string>> UpdateRoomStatusAsync(int idUser, UpdateStatusRoomDTO updateStatusRoomDTO)
        {
            try
            {
                // Crear la entidad Hotel a partir de los datos del DTO
                var room = new Room(
                    updateStatusRoomDTO.idRoom,
                    updateStatusRoomDTO.idHotel,
                    updateStatusRoomDTO.isAvailable
                );

                // Llamar al repositorio para crear el hotel
                var result = await _repository.UpdateRoomStatusAsync(idUser, room);

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

        public async Task<IResultAPI<string>> CreateTaxAsync(int idUser, CreateTaxDTO createTaxDTO)
        {
            try
            {
                var tax = new Tax(
                    createTaxDTO.idHotel,
                    createTaxDTO.name,
                    new Rate(createTaxDTO.rate),
                    createTaxDTO.description
               );

                var result = await _repository.CreateTaxAsync(idUser, tax);

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
        public async Task<IResultAPI<string>> UpdateTaxAsync(int idUser, UpdateTaxDTO updateTaxDTO)
        {
            try
            {
                var tax = new Tax(
                    updateTaxDTO.idTax,
                    updateTaxDTO.idHotel,
                    updateTaxDTO.name,
                    new Rate(updateTaxDTO.rate),
                    updateTaxDTO.description
               );

                var result = await _repository.UpdateTaxAsync(idUser, tax);

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


        public async Task<IResultAPI<string>> AssignTaxToRoomAsync(int idUser, RoomTaxAssignmentDTO roomTaxAssignmentDTO)
        {
            try
            {
                var roomTaxDetail = new RoomTaxDetail(
                    roomTaxAssignmentDTO.idRoom,
                    roomTaxAssignmentDTO.idTax
               );

                var result = await _repository.AssignTaxToRoomAsync(idUser, roomTaxAssignmentDTO.idHotel, roomTaxDetail);

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
        public async Task<IResultAPI<string>> RemoveTaxFromRoomAsync(int idUser, RoomTaxAssignmentDTO roomTaxAssignmentDTO)
        {
            try
            {
                var roomTaxDetail = new RoomTaxDetail(
                    roomTaxAssignmentDTO.idRoom,
                    roomTaxAssignmentDTO.idTax
               );

                var result = await _repository.RemoveTaxFromRoomAsync(idUser, roomTaxAssignmentDTO.idHotel, roomTaxDetail);

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

      
        public async Task<IResultAPI<IEnumerable<ListTaxDTO>>> GetHotelTaxesAsync(int idUser, int idHotel)
        {
            try
            {
                var result = await _repository.GetHotelTaxesAsync(idUser, idHotel);

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListTaxDTO>>.Fail(result.Message);

                var resultDTO = _mapper.Map<IEnumerable<ListTaxDTO>>(result.Data);
                return ResultAPI<IEnumerable<ListTaxDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListTaxDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListTaxDTO>());
            }
        }

    }
}
