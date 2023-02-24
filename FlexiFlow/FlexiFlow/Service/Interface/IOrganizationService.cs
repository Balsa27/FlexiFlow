namespace FlexiFlow.Service;

public interface IOrganizationService
{
    Organization GetById(Guid id);
    Organization GetByEmail(string email);
    void AddUserToOrganization(Guid userId, Guid organizationId);
}