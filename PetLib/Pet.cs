namespace PetLib;

public class Pet
{
    private int _age;

    public string Name { get; set; } = String.Empty;

    public int Age 
    { 
        get { return _age; }
        set
        {
            if(value < 1)
            {
                throw new InvalidAgeException("Age must be greater than zero!");
            }
            if(value > 20)
            {
                throw new InvalidAgeException("Age must be less than 21!");
            }
            _age = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {Name} Age:{Age}";
    }

    public string ToCSV()
    {
        return $"{Name},{Age}";
    }
}

