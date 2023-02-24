namespace FlexiFlow.Model.Response;

public record UserRegisterResponse(
    Guid id,
    string token,
    string email,
    string password,
    string address,
    string firstName,
    string lastName);
