using FlexiFlow.Repository.Interface;

namespace FlexiFlow.Repository.ListRepository;

public class UserListRepository : IUserRepository
{
    private readonly List<User> _users; 

    public UserListRepository()
    {
        _users = new();
    }

    public List<User> GetAll() => _users;

    public User? GetById(Guid id) => _users.Find(x => x.Id == id);
    
    public User? GetByEmail(string email) => _users.Find(x => x.Email == email);
    
    public void Add(User user)
    {
        if (!_users.Contains(user))
            _users.Add(user);
    }
}