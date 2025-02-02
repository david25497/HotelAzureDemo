using AutoMapper;
using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.DTOs;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<sp_GetHotels, ListHotelDTO>();
            CreateMap<sp_GetRoomsByHotel, ListRoomWithRoomTypeDto>();
            CreateMap<sp_GetGenderList, ListGenderDTO>();
            CreateMap<sp_GetDocumentTypeList, ListDocumentTypeDTO>();
            CreateMap<sp_GetCityList, ListCityDTO>();
            CreateMap<sp_GetAvailableHotels, ListAvailableHotelsDTO>();
            CreateMap<sp_GetAvailableHotelRooms, ListAvailableHotelRoomsDTO>();
            CreateMap<sp_GetHotelTaxes, ListTaxDTO>();
            CreateMap<sp_GetReservationsByHotel, ListReservationDTO>();
            CreateMap<sp_GetReservationDetail, ListReservationDetailDTO>();
        }

    }
}
