namespace FlexiFlow.Service.Implementation;

public class OrganizationService : IOrganizationService
{
    
    
    public OrganizationService()
    {
        
    }
    
    public Organization GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Organization GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public void AddUserToOrganization(Guid userId, Guid organizationId)
    {
        throw new NotImplementedException();
    }
}