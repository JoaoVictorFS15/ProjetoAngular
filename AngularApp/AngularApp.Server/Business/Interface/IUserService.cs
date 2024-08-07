using AngularApp.Server.Dtos;
using AngularApp.Server.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Interface
{
    public interface IUserService
    {
        Task<bool> UsuarioExiste(string username);
        Task<UserUpdateDto> GetUserByNome(string username);
        Task<SignInResult> CheckUserPassword(UserUpdateDto userUpdateDto, string password);
        Task<UserDto> CreateAccount(UserDto userDto);
        Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto );

    }
}
