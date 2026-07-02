using fazyup.api.Shared.Domain.Entities;
using fazyup.api.Database;

namespace fazyup.api.Repository;

public class UserRepository : IUserRepository
{
    private readonly FazyupDbContext _context;

    public UserRepository(FazyupDbContext context)
    {
        _context = context;
    }

    public async Task<bool> EmailAlreadyExistsAsync(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}