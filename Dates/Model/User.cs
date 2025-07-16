using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.ComponentModel.DataAnnotations;

namespace Dates.Models;

[Table("users")]
public class User : BaseModel
{
    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "اسم المستخدم مطلوب")]
    [Column("username")]
    public string Username { get; set; }

    [Required(ErrorMessage = "نوع المشروع مطلوب")]
    [Column("project_type")]
    public string ProjectType { get; set; }

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [Column("password_hash")]
    public string PasswordHash { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}
