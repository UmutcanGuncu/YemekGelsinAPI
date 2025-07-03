namespace YemekGelsin.Application.CQRS.Results.Auths;

public class RegisterCommandResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}