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
    public class UserRepository : IUserRepository
    {
        private readonly HotelContext _context;
        private readonly ErrorBD _errorBD;
        public UserRepository(HotelContext context, ErrorBD errorDBServices)
        {
            _context = context;
            _errorBD = errorDBServices;
        }

        public async Task<ResultBD<string>> CreateNewUserAsync(User user)
        {
            var idrol = 1;
            var usernameParam = new SqlParameter("@username", user.userName) { SqlDbType = SqlDbType.NVarChar };
            var passwordParam = new SqlParameter("@password", user.password.ToString()) { SqlDbType = SqlDbType.NVarChar };
            var idrolParam = new SqlParameter("@idrol", idrol) { SqlDbType = SqlDbType.Int };
            var emailParam = new SqlParameter("@email", user.email.ToString()) { SqlDbType = SqlDbType.NVarChar };

            return await _errorBD.EjecutarOperacionDB(async () =>
            {
               
                await _context.Database.ExecuteSqlRawAsync("EXEC [hotel].CreateNewUser @username, @password , @idrol, @email", usernameParam, passwordParam, idrolParam, emailParam);

                return "Creación Exitosa";
            }, "No se pudo crear el usuario.");
        }

        public async Task<ResultBD<IEnumerable<sp_getUserAccess>>> GetUserAccess(string _usuario, string _clave)
        {
            var usuarioParam = new SqlParameter("@username", _usuario) { SqlDbType = SqlDbType.NVarChar };
            var claveParam = new SqlParameter("@password", _clave) { SqlDbType = SqlDbType.NVarChar };
    
            return await _errorBD.EjecutarOperacionDB(async () =>
            {               
                var resultados = await _context.getUserAccess
                    .FromSqlRaw("EXEC [hotel].[GetUserAccess] @username, @password", usuarioParam, claveParam)
                    .ToListAsync();
               
                return resultados.AsEnumerable();
            }, "No se encontraron accesos para el usuario.");
        }


    }



}
