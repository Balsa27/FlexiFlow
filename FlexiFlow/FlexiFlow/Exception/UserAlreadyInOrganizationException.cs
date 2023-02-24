namespace FlexiFlow.Exception;

public class UserAlreadyInOrganizationException : System.Exception
{
    public UserAlreadyInOrganizationException(string message) 
        : base(message) { }
}