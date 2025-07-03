using MediatR;
using YemekGelsin.Application.CQRS.Results.Auths;

namespace YemekGelsin.Application.CQRS.Commands.Auths;

public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Age { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
}