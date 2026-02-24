using fazyup.api.Shared.Domain;

public class UserRole : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public string RoleName { get; set; } 
    public User User { get; set; }
}
