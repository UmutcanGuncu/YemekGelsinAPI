using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Auths;
using YemekGelsin.Application.CQRS.Results.Auths;
using YemekGelsin.Application.DTOs.AuthDtos;

namespace YemekGelsin.Application.CQRS.Handlers.Auths;

public class GoogleLoginCommandHandler(IAuthService _authService, IMapper _mapper) :  IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
{
    public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
    {
        var googleLoginDTO =  _mapper.Map<GoogleLoginDTO>(request);
        var result = await _authService.GoogleLoginAsync(googleLoginDTO);
        var response = _mapper.Map<GoogleLoginCommandResponse>(result);
        return response;
    }
}