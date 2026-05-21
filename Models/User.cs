using System.ComponentModel.DataAnnotations.Schema;

namespace Taskflow.Models;

[Table("users")]
public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}