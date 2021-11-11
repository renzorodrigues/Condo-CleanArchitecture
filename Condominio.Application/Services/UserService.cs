using Condominio.Application.DTOs;
using Condominio.Application.Interfaces.Services;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await this.userRepository.GetUsers();

            var usersDtoList = new List<User>();           

            return usersDtoList;
        }

        public Task<User> GetUserById()
        {
            throw new NotImplementedException();
        }

    }
}
