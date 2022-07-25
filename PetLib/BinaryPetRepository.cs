namespace PetLib;

public class BinaryPetRepository : IPetRepository
{
    private string _filePath;

    public BinaryPetRepository(string filePath)
    {
        _filePath = filePath;
    }

    public Pet Create(Pet pet)
    {
        
        try
        {
            FileStream stream = new (_filePath, FileMode.Append);
            BinaryWriter writer = new (stream);
            writer.Write(pet.Name);
            writer.Write(pet.Age);
            writer.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return pet;
    }

    public Pet? Read(string id)
    {
        Pet? pet = null;
        try
        {
            FileStream stream = new(_filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new(stream);
            // Check for end-of-file (EOF)
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                string name = reader.ReadString();
                int age = reader.ReadInt32();   
                if(name == id)
                {
                    pet = new()
                    {
                        Name = name,
                        Age = age,
                    };
                    break;
                }
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            // Should not be here because here is not UI
            Console.WriteLine(ex.Message);
        }
        return pet;
    }

    public List<Pet> ReadAll()
    {
        List<Pet> pets = new();
        try
        {
            FileStream stream = new(_filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new(stream);
            // Check for end-of-file (EOF)
            while (reader.BaseStream.Position != reader.BaseStream.Length)
            {
                Pet pet = new()
                {
                    Name = reader.ReadString(),
                    Age = reader.ReadInt32(),
                };
                pets.Add(pet);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            // Should not be here because here is not UI
            Console.WriteLine(ex.Message);
        }
        return pets;
    }
}

