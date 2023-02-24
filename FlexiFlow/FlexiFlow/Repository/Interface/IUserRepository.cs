namespace FlexiFlow.Repository.Interface;

public interface IUserRepository
{
    List<User> GetAll();
    User? GetById(Guid id);
    User? GetByEmail(string email);
    void Add(User user);
}