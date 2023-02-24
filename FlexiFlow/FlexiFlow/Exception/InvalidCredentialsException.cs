namespace FlexiFlow.Exception;

public class InvalidCredentialsException : System.Exception
{
    public InvalidCredentialsException(string message) : base(message) { }
}