using fazyup.api.Shared.Domain.Entities;

namespace fazyup.api.Repository;

public interface IUserRepository
{
    Task<bool> EmailAlreadyExistsAsync(string email);
    Task AddAsync(User user);
}
