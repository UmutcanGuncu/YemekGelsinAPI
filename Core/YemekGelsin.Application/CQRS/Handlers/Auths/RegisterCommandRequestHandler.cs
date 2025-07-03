using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Auths;
using YemekGelsin.Application.CQRS.Results.Auths;
using YemekGelsin.Application.DTOs.AuthDtos;

namespace YemekGelsin.Application.CQRS.Handlers.Auths;

public class RegisterCommandRequestHandler(IMapper _mapper, IAuthService _authService) : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
    public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request,
        CancellationToken cancellationToken)
    {
        var data = _mapper.Map<RegisterDTO>(request);
        var result = await _authService.RegisterAsync(data);
        RegisterCommandResponse response = _mapper.Map<RegisterCommandResponse>(result);
        return response;
    }
}