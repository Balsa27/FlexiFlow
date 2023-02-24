namespace FlexiFlow.Model.Request;

public record OrganizationRegisterRequest(string email, string password, string address, string organizationName);
