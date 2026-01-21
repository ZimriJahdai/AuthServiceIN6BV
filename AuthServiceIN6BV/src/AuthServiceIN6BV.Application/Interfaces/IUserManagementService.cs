using AuthServiceIN6BV.Application.DTOs;
namespace AuthServiceIN6BV.Application.Interfaces;

public interface IUserManagementService
{
    
    Task<UserResponseDto> UpdateUserRoleAsync(string userId, string roleName );
    Task<IReadOnlyList<string>> GetUserRoleAsync(string userId);
    Task<IReadOnlyList<UserResponseDto>> GetUserByRoleAsync(string roleName);
    

}