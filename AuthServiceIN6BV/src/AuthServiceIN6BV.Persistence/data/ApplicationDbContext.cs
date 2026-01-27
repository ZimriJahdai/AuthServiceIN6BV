using AuthServiceIN6BV.Domain.Etities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace AuthServiceIN6BV.Persistence.Data;
 
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserEmail> UserEmails { get; set; }
    public DbSet<UserPasswordReset> UserPasswordResets { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
 
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
 
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
 
    private void UpdateTimestamps()
    {
       
    }
 
    private static string ToSnakeCase(string input)
    {
        return "";
    }
 
   
 
}
 
 