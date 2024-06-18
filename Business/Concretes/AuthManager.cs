using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.Auth;
using Business.Dtos.Requests.User;
using Business.Dtos.Responses.User;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Business.ValudationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concretes;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly AuthBusinessRules _authBusinessRules;

        public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _authBusinessRules = authBusinessRules;
        }

        [ValidationAspect(typeof(LoginValidator))]
        public async Task<IUser> Login(LoginRequest loginRequest)
        {
            return await _authBusinessRules.UserToCheck(loginRequest);
        }

        [ValidationAspect(typeof(RegisterValidator))]
        public async Task<IUser> Register(RegisterRequest registerRequest)
        {
            bool isRegister = await _authBusinessRules.CheckIfUserExists(registerRequest.Email);
            if (isRegister)
            {
                HashingHelper.CreatePasswordHash(registerRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);
                registerRequest._passwordHash = passwordHash;
                registerRequest._passwordSalt = passwordSalt;

                User user = _mapper.Map<User>(registerRequest);
                CreateUserRequest createUserRequest = _mapper.Map<CreateUserRequest>(user);
                CreatedUserResponse createdUserResponse = await _userService.AddAsync(createUserRequest);
                return _mapper.Map<User>(createdUserResponse);
            }
            else
            {
                return null;
            }
        }

        public AccessToken CreateAccessToken(IUser user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return accessToken;
        }
    }
}