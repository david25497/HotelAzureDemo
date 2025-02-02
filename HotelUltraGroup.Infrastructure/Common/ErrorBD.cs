
using HotelUltraGroup.Core.Application.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Infrastructure.Common
{
    public class ErrorBD
    {
        public async Task<ResultBD<T>> EjecutarOperacionDB<T>(Func<Task<T>> _dbOperacion, string _mensaje = null)
        {
            try
            {
                if (string.IsNullOrEmpty(_mensaje))
                {
                    _mensaje = "Sin Registros Encontrados";
                }
                var result = await _dbOperacion();
                if (result == null)
                {
                    return ResultBD<T>.Fail(_mensaje);
                }

                return ResultBD<T>.Success(result);
            }
            catch (SqlException ex)
            {
                if (ex.Number >= 50000)
                {
                    return ResultBD<T>.Fail($"Error:{ex.Message}");
                }
                else
                {
                    return ResultBD<T>.Fail($"Error interno BD");
                }
            }
            catch (Exception ex)
            {
                return ResultBD<T>.Fail("Error Code");
            }
        }
    }
}
