using fazyup.api.Repository;
using fazyup.api.Shared.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace fazyup.api.Feature.User;

public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger<CreateUserUseCase> _logger;

    public CreateUserUseCase(
        IUserRepository userRepository,
        ILogger<CreateUserUseCase> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<UserOutput> ExecuteAsync(UserInput input)
    {
        _logger.LogInformation("Iniciando cadastro de usuário com email {Email}", input.Email);

        var emailExists = await _userRepository.EmailAlreadyExistsAsync(input.Email);

        if (emailExists)
        {
            _logger.LogWarning("Tentativa de cadastro com email já existente: {Email}", input.Email);
            throw new InvalidOperationException("Email já cadastrado.");
        }

        var user = new Shared.Domain.Entities.User(
            input.Name,
            input.Email
        );

        await _userRepository.AddAsync(user);

        _logger.LogInformation("Usuário criado com sucesso. Id: {UserId}", user.Id);

        return new UserOutput
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }
}
