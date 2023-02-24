namespace FlexiFlow.Repository.Interface;

public interface IOrganizationRepository
{
    Organization? GetById(Guid id);
    Organization? GetByEmail(string email);
    List<Organization> GetAll();
    void Add(Organization organization);
}