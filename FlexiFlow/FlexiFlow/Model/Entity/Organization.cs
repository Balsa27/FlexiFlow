using FlexiFlow.Exception;

namespace FlexiFlow;

public class Organization : Account
{
    public string OrganizationName { get; private set; }
    public List<User> Users { get; private set; } = new();

    public Organization() { }

    public Organization(Guid guid, string email, string password, string address, string organizationName, List<User> users) 
        : base(guid, email, password, address)
    {
        OrganizationName = organizationName;
        Users = users;
    }
    
    public Organization(string email, string password, string address, string organizationName, List<User>? users) //on creation 
        : base(email, password, address)
    {
        OrganizationName = organizationName;
        Users = users!;
    }
    
    public void AddUser(User user)
    {
        if(!Users.Contains(user))
            Users.Add(user);
        throw new UserAlreadyInOrganizationException("User is already in organization");
    }

    public void RemoveUser(User user)
    {
        if(Users.Contains(user))
            Users.Remove(user);
        throw new UserNotInOrganizationException("User is not in organization");
    }
}