using fazyup.api.Feature.User;
using fazyup.api.Repository;
using fazyup.api.Shared.Domain.Entities;

namespace fazyup.api.Feature.Admin;

public class CreateAdminUseCase
{
    private readonly IUserRepository _repository;

    public CreateAdminUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserOutput> ExecuteAsync(AdminInput input)
    {
        var emailExists = await _repository.EmailAlreadyExistsAsync(input.Email);

        if (emailExists)
            throw new InvalidOperationException("Email já cadastrado.");

        var user = new Shared.Domain.Entities.User(
            input.Name,
            input.Email
        );

        user.AddRole("admin");

        await _repository.AddAsync(user);

        return new UserOutput
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }
}