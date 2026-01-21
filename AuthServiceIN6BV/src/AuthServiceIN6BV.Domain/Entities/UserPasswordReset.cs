using System.ComponentModel.DataAnnotations;

namespace AuthServiceIN6BV.Domain.Etities;

public class UserPasswordReset
{
    [Key]
    [MaxLength(16)]

    public string Id {get; set; } = string.Empty;

    [Required]
    [MaxLength(16)]

    public string UserId { get; set; } = string.Empty;

    [MaxLength(256)]
    public string? UserPasswordResetToken {get; set; }


    public DateTime? PasswordResetTokenExpiry {get; set; }

     [Required]

     public User User {get; set; } = null!;

}