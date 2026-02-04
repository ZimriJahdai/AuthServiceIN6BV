namespace AuthServiceIN6BV.Application.Interfaces;
 
public interface IPasswordHashService
{
    string HashPassword(string hashPassword);
    bool VerifyPassword(string password, string hasedPassword);
}