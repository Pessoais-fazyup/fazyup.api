using fazyup.api.Shared.Domain;
using fazyup.api.Shared.Domain.Entities;

namespace fazyup.api.Shared.Domain.Entities;

public class UserRole : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public User? User { get; set; }
}