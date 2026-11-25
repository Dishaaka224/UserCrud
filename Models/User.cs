namespace ConsoleUserCrud.Models;

public class User
{
    private object nextId;

    public User(object nextId, string name, string email)
    {
        this.nextId = nextId;
        Name = name;
        Email = email;
    }

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int Age { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    internal void Remove(User user)
    {
        throw new NotImplementedException();
    }

    internal void Update(string name, string email)
    {
        throw new NotImplementedException();
    }
}
