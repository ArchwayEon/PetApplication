using PetLib;

//IPetRepository repo = new CSVPetRepository("Pets.csv");
IPetRepository repo = new BinaryPetRepository("Pets.data");
List<Pet> pets;

string answer;
do
{
    pets = repo.ReadAll();
    ShowAllPets(pets);
    ShowMenu();
    answer = ReadString("Enter your choice: ");
    switch (answer.ToUpper())
    {
        case "C":
            repo.Create(ReadPet());
            break;
        case "V":
            ViewPet(repo);
            break;
        case "D":
            DeletePet(pets);
            break;
    }
} while (answer.ToUpper() != "X");

static void DeletePet(List<Pet> pets)
{
    var petName = ReadString("Enter the pet's name: ");
    var pet = pets.FirstOrDefault(p => p.Name.ToLower() == petName.ToLower());
    if (pet != null)
    {
        // You should really confirm this!
        pets.Remove(pet);
        Console.WriteLine($"{petName} was removed!");
    }
    else
    {
        Console.WriteLine($"{petName} was not found!");
    }
}

static void ViewPet(IPetRepository repo)
{
    var petName = ReadString("Enter the pet's name: ");
    var pet = repo.Read(petName);
    if(pet != null)
    {
        Console.WriteLine(pet);
    }
    else
    {
        Console.WriteLine($"{petName} was not found!");
    }
}

static Pet ReadPet()
{
    Pet pet = new();
    pet.Name = ReadString("Enter your pet's name:");
    ReadAge(pet);
    return pet;
}

static void ShowAllPets(List<Pet> pets)
{
    Console.WriteLine();
    Console.WriteLine(new String('-', 80));
    string h1 = "Name";
    string h2 = "Age";
    Console.WriteLine($"{h1,-30} {h2,-4}");
    Console.WriteLine(new String('-', 80));
    foreach (Pet pet in pets)
    {
        Console.WriteLine($"{pet.Name,-30} {pet.Age,4}");
    }
}

static void ShowMenu()
{
    Console.WriteLine("C = Create Pet | V = View Pet | D = Delete Pet | X = Exit");
}


static void ReadAge(Pet pet)
{
    do
    {
        int age = ReadInteger("Please enter your pet's age: ");
        try
        {
            pet.Age = age;
            break;
        }
        catch(InvalidAgeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    } while (true);
}

static int ReadInteger(string prompt)
{
    int value;
    do
    {
        Console.Write(prompt);
        string? valueStr = Console.ReadLine();
        if (valueStr != null)
        {
            try
            {
                value = int.Parse(valueStr);
                break;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    } while (true);
    return value;
}

static string ReadString(string prompt)
{
    string value = "";
    Console.Write(prompt);
    string? valueStr = Console.ReadLine();
    if(valueStr != null)
    {
        value = valueStr.Trim();
    }
    return value;
}

