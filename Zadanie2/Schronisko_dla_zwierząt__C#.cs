using System;

class Animal
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string Volunteer { get; set; }
    public string Adopter { get; set; } 

    public Animal(string name, string species, int age)
    {
        Name = name;
        Species = species;
        Age = age;
        Volunteer = null;
        Adopter = null;
    }

    public void DisplayInfo()
    {
        string opiekun = string.IsNullOrEmpty(Volunteer) ? "Brak" : Volunteer;
        Console.WriteLine($"Imię: {Name} ({Species}), Wiek: {Age} lat  | Opiekun: {opiekun}");
    }
}

class Volunteer
{
    public string Name { get; set; }
    public string Phone { get; set; }

    public Volunteer(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public void Contact()
    {
        Console.WriteLine($"Imię i nazwisko: {Name} | Telefon: {Phone}");
    }

    public void AssignAnimal(Animal animal)
    {
        animal.Volunteer = Name;
    }
}

class Adoption
{
    public Animal AdoptedAnimal { get; set; }
    public string AdopterName { get; set; }

    public Adoption(Animal animal, string adopterName)
    {
        AdoptedAnimal = animal;
        AdopterName = adopterName;
        AdoptedAnimal.Adopter = adopterName;
    }

    public void AdoptionInfo()
    {
        Console.WriteLine($"Zaadoptowane zwierzę: {AdoptedAnimal.Name} | Adoptujący: {AdopterName}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal animal1 = new Animal("Milka", "Kot", 3);
        Animal animal2 = new Animal("Kapsel", "Pies", 10);

        Volunteer volunteer1 = new Volunteer("Anna Nowak", "123-456-789");

        volunteer1.AssignAnimal(animal2);

        Adoption adoption1 = new Adoption(animal1, "Marek Kowalski");
        Adoption adoption2 = new Adoption(animal2, "Jadwiga Rybak");

        Console.WriteLine("Zwierzęta: ");
        Console.WriteLine(new string('_', 100)); 
        animal1.DisplayInfo();
        animal2.DisplayInfo();

        Console.WriteLine(new string('=', 100));

        Console.WriteLine("\nWolontariusze: ");
        Console.WriteLine(new string('_', 100));
        volunteer1.Contact();

        Console.WriteLine(new string('=', 100));

        Console.WriteLine("\nAdopcje: ");
        Console.WriteLine(new string('_', 100));
        adoption1.AdoptionInfo();
        adoption2.AdoptionInfo();
    }
}
