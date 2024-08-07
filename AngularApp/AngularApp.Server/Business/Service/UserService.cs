using AngularApp.Server.Business.Interface;
using AngularApp.Server.Dtos;
using AngularApp.Server.Models.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AngularApp.Server.Business.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager _signInManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, SignInManager signInManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }

        public Task<SignInResult> CheckUserPassword(UserUpdateDto userUpdateDto, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDto> CreateAccount(UserDto userDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserUpdateDto> GetUserByNome(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UsuarioExiste(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
