using System.Threading.Tasks;
using HotelUltraGroup.Core.Application.Common;

namespace HotelUltraGroup.Core.Application.Common.Interfaces
{
    public interface ITokenServices
    {
        Task<string> GenerateTokenAsync(string _user, string _id, string _rol, TokenConfigDTO _TokenConfigDTO);
    }
}
