using HotelUltraGroup.Core.Application.Common;
using HotelUltraGroup.Core.Application.Common.Interfaces;
using HotelUltraGroup.Core.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUltraGroup.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<IResultAPI<string>> CreateNewUserAsync(CreateUserDTO _newUserDTO);
        Task<IResultAPI<string>> LoginAsync(LoginDTO _loginDTO, TokenConfigDTO _TokenConfigDTO);
    }
}
