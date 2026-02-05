using fazyup.api.Shared.Domain;

public class User : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
