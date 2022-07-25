namespace PetLib;

public class InvalidAgeException : Exception
{
    public InvalidAgeException() : base("Invalid age!")
    {
    }

    public InvalidAgeException(string message) : base(message)
    {
    }

    /// <summary>
    /// Two argument constructor
    /// </summary>
    /// <param name="message"></param>
    /// <param name="inner"></param>
    public InvalidAgeException(string message, Exception inner) : base(message, inner)
    {
    }
}

