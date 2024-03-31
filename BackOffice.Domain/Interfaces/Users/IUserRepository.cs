using BackOffice.Domain.Entities.Users;

namespace BackOffice.Domain.Interfaces.Users;

public interface IUserRepository
{
    Task<List<User>> GetAsync();

    Task<User?> GetByIdAsync(string id);

    Task CreateAsync(User newUser);

    Task UpdateAsync(string id, User updatedUser);

    Task RemoveAsync(string id);
}
