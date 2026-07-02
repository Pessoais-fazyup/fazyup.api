using System.Text.RegularExpressions;
using fazyup.api.Shared.Domain.Entities;

namespace fazyup.api.Shared.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public ICollection<UserRole> UserRoles { get; private set; }

    protected User() { }

    public User(string name, string email)
    {
        SetName(name);
        SetEmail(email);
        UserRoles = new List<UserRole>();
    }

    public void AddRole(string role)
    {
        UserRoles.Add(new UserRole
        {
            UserId = Id,
            RoleName = role
        });
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome obrigatório");

        Name = name.Trim();
    }

    private void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email obrigatório");

        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Email inválido");

        Email = email.ToLower();
    }
}