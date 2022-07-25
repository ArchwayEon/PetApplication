﻿namespace PetLib;

public class CSVPetRepository : IPetRepository
{
    private string _filePath;

    public CSVPetRepository(string filePath)
    {
        _filePath = filePath;
    }

    public Pet Create(Pet pet)
    {
        try
        {
            StreamWriter writer = new (_filePath, append:true);
            writer.WriteLine(pet.ToCSV());
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
            string? record;
            StreamReader reader = new(_filePath);
            record = reader.ReadLine();
            // Check for end-of-file (EOF)
            while (record != null)
            {
                string[] fields = record.Split(',');
                if(fields[0] == id)
                {
                    pet = new()
                    {
                        Name = fields[0],
                        Age = int.Parse(fields[1]),
                    };
                    break; // No need to check the other records
                }
                record = reader.ReadLine();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return pet;
    }

    public List<Pet> ReadAll()
    {
        List<Pet> pets = new();
        try
        {
            string? record;
            StreamReader reader = new(_filePath);
            record = reader.ReadLine();
            // Check for end-of-file (EOF)
            while(record != null)
            {
                string[] fields = record.Split(',');
                Pet pet = new()
                {
                    Name = fields[0],
                    Age = int.Parse(fields[1]),
                };
                pets.Add(pet);
                record = reader.ReadLine();
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

