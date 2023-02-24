namespace FlexiFlow.Model.Request;

public record UserRegisterRequest(
    string email,
    string password,
    string address,
    string firstName,
    string lastName
    );