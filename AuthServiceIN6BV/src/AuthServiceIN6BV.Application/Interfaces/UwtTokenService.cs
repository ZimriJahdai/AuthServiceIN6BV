using AuthServiceIN6BV.Domain.Etities;

namespace AuthServiceIN6BV.Application.Interfaces;

public interface UwtTokenService
{
    
    string GenerateToken(User user);

    
}