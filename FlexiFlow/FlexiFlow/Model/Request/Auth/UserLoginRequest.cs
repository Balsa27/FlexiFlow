namespace FlexiFlow.Model.Request;

public record UserLoginRequest(
    string email,
    string password);