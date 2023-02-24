namespace FlexiFlow.Exception;

public class UserNotFoundException : System.Exception
{
    public UserNotFoundException(string message) : base(message) { }    
}