using AuthServiceIN6BV.Domain.Etities;

namespace AuthServiceIN6BV.Domain.Interfaces
{
    
}
public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string name);

    Task <int> CountUserInRoleAsync(string roleName);

    Task<IReadOnlyList<User>> GetUserByRoleAsync(string roleName);

    Task<IReadOnlyList <string>> GetUserRoleNameAsync(string userId);
}
