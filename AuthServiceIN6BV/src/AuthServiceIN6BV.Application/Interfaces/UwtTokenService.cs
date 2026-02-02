using AuthServiceIN6BV.Domain.Entities;

namespace AuthServiceIN6BV.Application.Interfaces;

public interface UwtTokenService
{
    
    string GenerateToken(User user);

    
}