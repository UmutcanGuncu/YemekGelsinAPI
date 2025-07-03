using MediatR;
using YemekGelsin.Application.CQRS.Results.Auths;

namespace YemekGelsin.Application.CQRS.Commands.Auths;

public class GoogleLoginCommandRequest : IRequest<GoogleLoginCommandResponse>
{
    public string Id { get; set; }
    public string IdToken { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhotoUrl { get; set; }
    public string Provider { get; set; }
}