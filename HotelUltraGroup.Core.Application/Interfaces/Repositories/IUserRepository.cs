using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Domain.Entities;
using HotelUltraGroup.Core.Domain.Stored_Procedure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ResultBD<string>> CreateNewUserAsync(User user);
        Task<ResultBD<IEnumerable<sp_getUserAccess>>> GetUserAccess(string username, string password);
    }
}
