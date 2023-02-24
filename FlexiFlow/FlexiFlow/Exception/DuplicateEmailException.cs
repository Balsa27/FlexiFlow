namespace FlexiFlow.Exception;

public class DuplicateEmailException : System.Exception
{
    public DuplicateEmailException(string message) : base(message) { }
}