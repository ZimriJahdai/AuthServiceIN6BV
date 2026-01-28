using AuthServiceIN6BV.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthServiceIN6BV.Persistence.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<Role>
            {
                new()
                {
                    Id = GenerateUserId(),  // Corrección aquí
                    Name = "Admin"
                },
                new()
                {
                    Id = GenerateUserId(),  // Corrección aquí
                    Name = "User"
                }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }

        if (!await context.Users.AnyAsync())
        {
            var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
            if (adminRole != null)
            {
                // Generar IDs
                var profileId = GenerateUserId();
                var emailId = GenerateUserId();
                var userRoleId = GenerateUserId();
                var userId = GenerateUserId();

                var admin = new User
                {
                    Id = userId,
                    Name = "Admin",
                    Surname = "User",
                    UserName = "admin",  // Faltaba esta propiedad
                    Email = "admin@ksports.local",  // Corrección: punto en lugar de coma
                    Password = HashPassword("Admin1234!"),  // Corrección aquí
                    Status = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    UserProfile = new UserProfile
                    {
                        Id = profileId,
                        UserId = userId,
                        ProfilePicture = string.Empty,
                        Phone = "00000000"  // Requiere 8 dígitos según validación
                    },
                    UserEmail = new UserEmail
                    {
                        Id = emailId,
                        UserId = userId,
                        EmailVerified = true,
                        EmailVerificationToken = null,
                        EmailVerificationTokenExpiry = null
                    },
                    UserRoles = [
                        new UserRole
                        {
                            Id = userRoleId,
                            UserId = userId,
                            RoleId = adminRole.Id,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow
                        }
                    ],
                    UserPasswordReset = new UserPasswordReset  // Faltaba esta propiedad
                    {
                        Id = GenerateUserId(),
                        UserId = userId,
                        UserPasswordResetToken = null,
                        PasswordResetTokenExpiry = null
                    }
                };

                await context.Users.AddAsync(admin);  // Corrección: admin en lugar de adminUser
                await context.SaveChangesAsync();
            }
        }
    }

    // Métodos auxiliares para reemplazar UuidGenerator
    private static string GenerateUserId()
    {
        // Genera un ID de 16 caracteres hexadecimales
        return Guid.NewGuid().ToString("N")[..16];
    }

    private static string HashPassword(string password)
    {
        // Método simple de hash para el seeder (en producción usarías un servicio real)
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}