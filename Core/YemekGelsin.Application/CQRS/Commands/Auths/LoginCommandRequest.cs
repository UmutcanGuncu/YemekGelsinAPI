using MediatR;
using YemekGelsin.Application.CQRS.Results.Auths;

namespace YemekGelsin.Application.CQRS.Commands.Auths;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}