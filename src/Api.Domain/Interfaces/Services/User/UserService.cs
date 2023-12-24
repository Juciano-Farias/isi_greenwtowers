using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface UserService
    {
        Task<UserEntity> Get(Guid id);
        Task<List<UserEntity>> GetAll();
        Task<UserEntity> Post(UserEntity user);
        Task<UserEntity> Put(UserEntity user);
        Task<UserEntity> Delete(UserEntity user);
    }
}