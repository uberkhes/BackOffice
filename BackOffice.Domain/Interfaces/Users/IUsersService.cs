using BackOffice.Domain.Entities.Users;

namespace BackOffice.Domain.Interfaces.Users;

public interface IUsersService
{
    Task<List<User>> GetAsync();

    Task<User?> GetAsync(string id);

    Task CreateAsync(User newUser);

    Task UpdateAsync(string id, User updatedUser);

    Task RemoveAsync(string id);
}
