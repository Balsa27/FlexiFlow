namespace FlexiFlow.Exception;

public class UserNotInOrganizationException : System.Exception
{
    public UserNotInOrganizationException(string message) 
        : base(message) { }
}