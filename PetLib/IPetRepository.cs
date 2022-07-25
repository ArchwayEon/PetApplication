namespace PetLib;

/// <summary>
/// Interface for CRRUD
/// </summary>
public interface IPetRepository
{
    Pet Create(Pet pet);
    List<Pet> ReadAll();
    Pet? Read(string id);
}

