namespace AuthService.Application.Interfaces;
 
public interface IPasswordHashService
{
    string HashPassword(string hashPassword);
    bool VerifyPassword(string password, string hasedPassword);
}