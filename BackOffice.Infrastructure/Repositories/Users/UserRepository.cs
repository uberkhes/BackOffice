using BackOffice.Domain.Entities.Users;
using BackOffice.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BackOffice.Domain.Interfaces.Users;

namespace BackOffice.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserRepository(
            IOptions<DatabaseSettings> databaseSettings
        )
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(databaseSettings.Value.UsersCollectionName);
    }

    public async Task<List<User>> GetAsync() =>
    await _usersCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetByIdAsync(string id) =>
        await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    public async Task RemoveAsync(string id) =>
        await _usersCollection.DeleteOneAsync(x => x.Id == id);
}
