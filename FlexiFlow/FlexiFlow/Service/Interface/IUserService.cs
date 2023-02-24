namespace FlexiFlow.Service;

public interface IUserService
{
    User GetById(Guid id);
    User GetByEmail(string email);
    List<User> GetAll();
}