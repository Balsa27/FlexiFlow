namespace FlexiFlow.Exception;

public class TokenNotFoundException : System.Exception
{
    public TokenNotFoundException(string message) : base(message) { }
}