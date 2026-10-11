using FluentValidation;
using SbankAPI.Application.Dto;
using SbankAPI.Application.Interface;
using SbankAPI.Domain.Entities;

namespace SbankAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IValidator<CreateUserDto> _validator;

        public UserService(IUserRepository repository, IValidator<CreateUserDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UserResponseDTO> AddUserAsynch(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
        {
            // Validate the DTO
            var validationResult = await _validator.ValidateAsync(createUserDto, cancellationToken);
            
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Use the constructor instead of property assignment
            var user = new Tbl_User(
                createUserDto.UserName,
                createUserDto.Email,
                createUserDto.Mobile,
                createUserDto.Password
            );

            await _repository.AddUserAsync(user, cancellationToken);
            await _repository.SaveChangesAsync();

            return new UserResponseDTO
            {
                UserID = user.UserID,
                UserName = user.UName,
                Email = user.UEmail,
                Mobile = user.UMobile
            };
        }
    }
}