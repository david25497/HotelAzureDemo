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
    public class UserService : IUserService
    {
        private readonly IUserRepository  _repository;
        private readonly ITokenServices _tokenService;

        public UserService(IUserRepository Repository , ITokenServices tokenService)
        {
            _repository = Repository;
            _tokenService = tokenService;
        }

        public async Task<IResultAPI<string>> CreateNewUserAsync(CreateUserDTO newUserDTO)
        {
            try
            {
                var usuario = new User(
                newUserDTO.username,
                new Email(newUserDTO.email),
                new Password(newUserDTO.password));

                var result = await _repository.CreateNewUserAsync(usuario);

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


        public async Task<IResultAPI<string>> LoginAsync(LoginDTO _loginDTO, TokenConfigDTO _TokenConfigDTO)
        {
            try
            {
                var result = await _repository.GetUserAccess(_loginDTO.username, _loginDTO.password);

                if (result == null)
                    return ResultAPI<string>.Fail("Se ha producido un error al recuperar la información");

                if (result.Data.Count()<=0)
                {
                    return ResultAPI<string>.Fail("Usuario o clave invalido");
                }


                string id = result.Data.FirstOrDefault().id.ToString();
                string rol = "Admi";
                string token = await _tokenService.GenerateTokenAsync(_loginDTO.username, id, rol, _TokenConfigDTO);

                return ResultAPI<string>.Success("TOKEN", token);
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
