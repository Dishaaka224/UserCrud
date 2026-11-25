namespace ConsoleUserCrud.Models;

public class UserServices
{
    private readonly List<User> user = new();
    private int _nextID = 1;
    public string CreateUser (string name, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "The name must not be empty.";

        foreach (var u in user)
        {
            if (u.Email == email)
                return "This email already exists";
        }

        user.Add(new User(_nextID, name, email));
        _nextID++;
        return "User added";
    }
    public User GetUserById(int id)
    {
        foreach (var u in user)
        {
            if (u.Id == id)
                return u;
        }
        return null;
    }
     public List<User> GetAllUsers()
    {
        return user;
    }
    public string UpdateUser (int id, string name, string email)
    {
        var existingUser = GetUserById(id);

        if (existingUser == null)
        return "Such an ID was not found";

        if (string.IsNullOrWhiteSpace(name))
        return "The name must not be empty.";

        foreach (var u in user)
        {
            if (u.Email == email && u.Id != id)
                return "This email is already in use by another user.";
        }

        existingUser.Update(name, email);
        return "Updated";
    }
    public string DeleteUser(int id)
    {
        var user = GetUserById(id);
        if (user == null)
            return "Id not found ";

        user.Remove(user);
        return "Deleted";
    }
}