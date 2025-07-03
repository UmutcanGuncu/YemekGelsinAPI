namespace YemekGelsin.Application.DTOs.AuthDtos;

public class LoginResultDTO
{
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public string UserId { get; set; }
    public Token Token { get; set; }

}