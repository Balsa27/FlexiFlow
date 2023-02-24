namespace FlexiFlow.Model.Response;

public record UserLoginResponse( //same thing like UserRegisterResponse but i couldn`t bother to abstract it 
    Guid id,
    string token,
    string email,
    string password,
    string address,
    string firstName,
    string lastName);