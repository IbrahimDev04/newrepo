namespace EcoCoinUni.Exceptions.UserExceptions;

public class UserExistsException : Exception
{
    public UserExistsException() : base("Username or Email already exist")
    {
    }

    public UserExistsException(string? message) : base(message)
    {
    }
}