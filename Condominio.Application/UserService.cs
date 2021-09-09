using Condominio.Application.DTOs;
using Condominio.Application.Interfaces.Services;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await this.userRepository.GetUsers();

            var usersDtoList = new List<UserDto>();

            foreach (var user in users)
            {
                var unitDto = new UnitDto();
                unitDto.Id = user.Unit.Id;
                unitDto.Number = user.Unit.Number;

                var userDto = new UserDto();
                userDto.Id = user.Id;
                userDto.Name = user.Name;
                userDto.Unit = unitDto;                              

                usersDtoList.Add(userDto);
            }

            return usersDtoList;
        }

        public Task<User> GetUserById()
        {
            throw new NotImplementedException();
        }

    }
}
