namespace AuthService.Application.Interfaces;
 
public interface IPasswordHashService
{
    string hashPassword(string hashPassword);
    bool verifyPassword(string password, string hasedPassword);
}