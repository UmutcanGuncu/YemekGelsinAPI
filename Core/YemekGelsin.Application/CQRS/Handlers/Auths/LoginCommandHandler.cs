using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Auths;
using YemekGelsin.Application.CQRS.Results.Auths;
using YemekGelsin.Application.DTOs.AuthDtos;

namespace YemekGelsin.Application.CQRS.Handlers.Auths;

public class LoginCommandHandler(IAuthService _authService, IMapper _mapper) : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var loginDTO =  _mapper.Map<LoginDTO>(request);
        var result = await _authService.LoginAsync(loginDTO);
        var response = _mapper.Map<LoginCommandResponse>(result);
        return response;
    }
}