using Microsoft.AspNetCore.Mvc;
using SbankAPI.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SbankAPI.Application.Interface
{
    public interface IUserService
    {
        Task<UserResponseDTO> AddUserAsynch(CreateUserDto createUserDto , CancellationToken cancellationToken= default);
        Task<UserResponseDTO> UpdateUserProfileAsync(long userId, string name, string mobile, CancellationToken cancellationToken = default);
    }
}
