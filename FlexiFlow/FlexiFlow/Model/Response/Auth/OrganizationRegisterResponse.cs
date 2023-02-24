namespace FlexiFlow.Model.Response;

public record OrganizationRegisterResponse(
    Guid id,
    string token,
    string email,
    string password,
    string address,
    string organizationName,
    List<User> Users);