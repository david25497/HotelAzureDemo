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
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository  _repository;
        private readonly IMapper _mapper;
        public HotelService(IHotelRepository Repository,IMapper mapper)
        {
            _repository = Repository;
            _mapper = mapper;
        }

        public async Task<IResultAPI<IEnumerable<ListHotelDTO>>> GetHotelsAsync(int idUser)
        {
            try
            {
                var result = await _repository.GetHotelsAsync(idUser);

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListHotelDTO>>.Fail(result.Message);

                var resultDTO = _mapper.Map<IEnumerable<ListHotelDTO>>(result.Data);
                return ResultAPI<IEnumerable<ListHotelDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListHotelDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListHotelDTO>());
            }
        }

        public async Task<IResultAPI<string>> CreateHotelAsync(int idUser, CreateHotelDTO createHotelDTO)
        {
            try
            {
                // Crear la entidad Hotel a partir de los datos del DTO
                var hotel = new Hotel(
                    idUser,
                    createHotelDTO.name,
                    createHotelDTO.idCity,
                    createHotelDTO.address
                );

                // Llamar al repositorio para crear el hotel
                var result = await _repository.CreateHotelAsync(hotel);

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

        public async Task<IResultAPI<string>> UpdateHotelAsync( int idUser, UpdateHotelDTO updateHotelDTO)
        {
            try
            {
                // Crear la entidad Hotel a partir de los datos del DTO
                var hotel = new Hotel(
                    idUser,
                    updateHotelDTO.idHotel,
                    updateHotelDTO.name,
                    updateHotelDTO.idCity,
                    updateHotelDTO.address
                );

                // Llamar al repositorio para crear el hotel
                var result = await _repository.UpdateHotelAsync(hotel);

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
            
        public async Task<IResultAPI<string>> UpdateStatusHotelAsync(int idUser, UpdateStatusHotelDTO updateStatusHotelDTO)
        {
            try
            {
                // Crear la entidad Hotel a partir de los datos del DTO
                var hotel = new Hotel(
                    idUser,
                    updateStatusHotelDTO.idHotel,
                    updateStatusHotelDTO.isAvailable
                );

                // Llamar al repositorio para crear el hotel
                var result = await _repository.UpdateStatusHotelAsync(hotel);

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

        
        public async Task<IResultAPI<IEnumerable<ListReservationDTO>>> GetReservationsByHotel(int idUser, int idHotel)
        {
            try
            {
                var result = await _repository.GetReservationsByHotel(idUser,idHotel);

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListReservationDTO>>.Fail(result.Message);

                var resultDTO = _mapper.Map<IEnumerable<ListReservationDTO>>(result.Data);
                
                
                if (result.Data.Count()<=0)
                    return ResultAPI<IEnumerable<ListReservationDTO>>.Success("Sin registros",resultDTO);
               
                return ResultAPI<IEnumerable<ListReservationDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListReservationDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListReservationDTO>());
            }
        }

    
        public async Task<IResultAPI<IEnumerable<ListReservationDetailDTO>>> GetReservationDetail(int idUser, int idHotel, int idReservation)
        {
            try
            {
                var result = await _repository.GetReservationDetail(idUser, idHotel, idReservation);

                if (!result.IsSuccess)
                    return ResultAPI<IEnumerable<ListReservationDetailDTO>>.Fail(result.Message);

                var resultDTO = _mapper.Map<IEnumerable<ListReservationDetailDTO>>(result.Data);


                if (result.Data.Count() <= 0)
                    return ResultAPI<IEnumerable<ListReservationDetailDTO>>.Success("Sin registros", resultDTO);

                return ResultAPI<IEnumerable<ListReservationDetailDTO>>.Success(resultDTO);
            }
            catch (Exception e)
            {
                return ResultAPI<IEnumerable<ListReservationDetailDTO>>.Fail("Se ha producido un error al convertir la información", new List<ListReservationDetailDTO>());
            }
        }


    }
}
