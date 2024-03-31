using BackOffice.Domain.Entities.Users;
using BackOffice.Domain.Interfaces.Users;

namespace BackOffice.Application.Users;

public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;

    public UsersService(
            IUserRepository userRepository
        ) 
    {
        _userRepository = userRepository;
    }

    public async Task<List<User>> GetAsync() =>
        await _userRepository.GetAsync();

    public async Task<User?> GetAsync(string id) =>
        await _userRepository.GetByIdAsync(id);

    public async Task CreateAsync(User newUser) =>
        await _userRepository.CreateAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _userRepository.UpdateAsync(id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _userRepository.RemoveAsync(id);

}
