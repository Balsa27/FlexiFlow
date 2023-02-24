using FlexiFlow.Exception;
using FlexiFlow.Repository.Interface;

namespace FlexiFlow.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetById(Guid id)
    {
        User? user = _userRepository.GetById(id);
        if (user is not null)
            return user;
        throw new UserNotFoundException("User not found");
    }

    public User GetByEmail(string email)
    {
        User? user = _userRepository.GetByEmail(email);
        if (user is not null)
            return user;
        throw new UserNotFoundException("User not found");
    }

    public List<User> GetAll() => _userRepository.GetAll();

}