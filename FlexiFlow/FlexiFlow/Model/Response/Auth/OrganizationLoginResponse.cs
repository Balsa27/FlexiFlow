namespace FlexiFlow.Model.Response;

public record OrganizationLoginResponse(
    Guid id,
    string token,
    string email,
    string password,
    string address,
    string organizationName,
    List<User> Users);