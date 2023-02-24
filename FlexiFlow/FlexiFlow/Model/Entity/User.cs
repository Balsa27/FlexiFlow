namespace FlexiFlow;

public class User : Account
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Preference? Preferences { get; private set; }
    public List<WorkDay>? WorkDays { get; private set; }


    public User() { }

    public User(string email, string password, string address, string firstName, string lastName) : base(email,
        password, address)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public User(Guid id, string email, string password, string address, string firstName, string lastName) : base(id,
        email, password, address)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    
    public void AddWorkDay(WorkDay workDay)
    {
        if (WorkDays is null)   
            WorkDays = new();
        WorkDays.Add(workDay);
    }
    
    public void SetPreference(Preference preference)
    {
        if (Preferences is null)
            Preferences = new Preference();

        Preferences = preference;
    }


    public override bool Equals(object? obj) 
    {
        User? user = obj as User;
      
        if (user.Id.Equals(Id))
            return true;

        return false;
    }
}