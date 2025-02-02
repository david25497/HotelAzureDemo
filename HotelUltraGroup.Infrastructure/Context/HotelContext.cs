using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Infrastructure.Context
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
        }
        public DbSet<sp_getUserAccess> getUserAccess { get; set; }
        public DbSet<sp_GetHotels> hotels { get; set; }
        public DbSet<sp_GetRoomsByHotel> RoomsWithRoomType { get; set; }
        public DbSet<sp_GetAvailableHotels> availableHotels { get; set; }
        public DbSet<sp_GetAvailableHotelRooms> availableHotelRooms { get; set; }
        public DbSet<sp_GetGenderList> genders { get; set; }
        public DbSet<sp_GetDocumentTypeList> documentTypes { get; set; }
        public DbSet<sp_GetCityList> cities { get; set; }
        public DbSet<sp_GetHotelTaxes> hotelTaxes { get; set; }
        public DbSet<sp_CreateReservation> reservationCode { get; set; }

        public DbSet<sp_GetReservationsByHotel> reservationByHotel{ get; set; }

        public DbSet<sp_GetReservationDetail> reservationDetail { get; set; }

        //Contexto de Hotel
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<sp_getUserAccess>().HasNoKey().ToView(null);
            builder.Entity<sp_GetHotels>().HasNoKey().ToView(null);
            builder.Entity<sp_GetRoomsByHotel>().HasNoKey().ToView(null);
            builder.Entity<sp_GetAvailableHotels>().HasNoKey().ToView(null);
            builder.Entity<sp_GetAvailableHotelRooms>().HasNoKey().ToView(null);
            builder.Entity<sp_GetGenderList>().HasNoKey().ToView(null);
            builder.Entity<sp_GetDocumentTypeList>().HasNoKey().ToView(null);
            builder.Entity<sp_GetCityList>().HasNoKey().ToView(null);
            builder.Entity<sp_GetHotelTaxes>().HasNoKey().ToView(null);
            builder.Entity<sp_CreateReservation>().HasNoKey().ToView(null);
            builder.Entity<sp_GetReservationsByHotel>().HasNoKey().ToView(null);
            builder.Entity<sp_GetReservationDetail>().HasNoKey().ToView(null);
            
            //Aplicamos de forma automatica las configuraciones que se encuentran en la carpeta CONFIGURACIONES
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
