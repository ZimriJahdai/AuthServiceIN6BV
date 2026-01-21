using System.ComponentModel.DataAnnotations;
namespace AuthServiceIN6BV.Domain.Etities;

public class UserRole
{
    [Key]
    [MaxLength(16)]
    public string Id { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(16)]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [MaxLength(16)]
    public string RoleId { get; set; } = string.Empty;

    [Required]
    public UserRole User { get; set; } = null!;


    [Required]
    public Role Role { get; set; } = null!;


    public DateTime CreateAt { get; set;}


    public  DateTime UpdateAt { get; set;}






}