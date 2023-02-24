namespace FlexiFlow;

public abstract class Account
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get;  private set; }
    public string? ImageUrl { get; private set; }
    public string Address { get; private set; }


    protected Account() { }
   
    protected Account(  
        string email,
        string password,
        string address
        )
    {
        Email = email;
        Password = password;
        Address = address;
        Id = Guid.NewGuid();
    }

    protected Account(
        Guid id,
        string email,
        string password,
        string address)
    {
        Id = id;
        Email = email;
        Password = password;
        Address = address;
    }

    private void SetImageUrl(string imageUrl) //set to public probs
    {
        ImageUrl = imageUrl;
    }
}