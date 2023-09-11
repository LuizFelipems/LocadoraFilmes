using AutoMapper;
using LocadoraFilmes.Application.Commons.Handlers;
using LocadoraFilmes.Application.Commons.Responses;
using LocadoraFilmes.Domain.Interfaces.Data.Repositories;
using LocadoraFilmes.Domain.Interfaces.Data;
using MediatR;
using LocadoraFilmes.Application.UseCases.Security.Requests;
using LocadoraFilmes.Application.UseCases.Security.Responses;
using LocadoraFilmes.Application.Services;
using FluentValidation;

namespace LocadoraFilmes.Application.UseCases.Security.Handlers
{
    public class LoginUserUseCase : Handler, IRequestHandler<LoginUserCommand, Response<LoginUserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public LoginUserUseCase(IUnitOfWork uow, 
            IMapper mapper, 
            IUserRepository userRepository, 
            TokenService tokenService,
            IServiceProvider services)
            : base(uow, mapper, services)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<Response<LoginUserResponse>> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.LoginAsync(command.Login, command.Password, cancellationToken);
            if (user is null)
                return Fail<LoginUserResponse>();

            var token = _tokenService.GenerateToken(user.Login, user.Role);

            var response = _mapper.Map<LoginUserResponse>(user);
            response.Token = token;

            return Success(response);
        }
    }
}
