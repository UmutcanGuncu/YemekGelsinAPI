namespace YemekGelsin.Application.Abstractions.Token;

public interface ITokenHandler
{
    Task<DTOs.Token> CreateAccessToken(string userId); 
    string CreateRefreshToken();
}