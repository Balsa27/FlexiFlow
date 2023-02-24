using FlexiFlow.Repository.Interface;
using FlexiFlow.Service;

namespace FlexiFlow.Repository.ListRepository;

public class OrganizationRepository : IOrganizationRepository 
{
    private readonly List<Organization> _organizations;
    
    public OrganizationRepository()
    {
        _organizations = new();
    }
    
    public Organization? GetById(Guid id) => _organizations.FirstOrDefault(o => o.Id == id);

    public Organization? GetByEmail(string email) => _organizations.FirstOrDefault(o => o.Email == email);

    public List<Organization> GetAll() => _organizations;
    
    public void Add(Organization organization)
    {
        if(!_organizations.Contains(organization))
            _organizations.Add(organization);
    }
}