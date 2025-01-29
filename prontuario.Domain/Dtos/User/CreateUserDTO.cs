using prontuario.Domain.Dtos.Profile;

namespace prontuario.Domain.Dtos.User;

public record CreateUserDTO(
    string Name,
    string Email,
    string Cpf,
    string Position,
    ProfileDTO Profile
    );