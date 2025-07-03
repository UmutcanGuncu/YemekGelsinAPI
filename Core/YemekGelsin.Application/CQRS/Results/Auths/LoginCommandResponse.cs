using YemekGelsin.Application.DTOs;

namespace YemekGelsin.Application.CQRS.Results.Auths;

public class LoginCommandResponse
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public string UserId { get; set; }
    public Token Token { get; set; }
}