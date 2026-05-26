class Animal:
    def __init__(self, name, species, age):
        self.name = name
        self.species = species
        self.age = age
        self.volunteer = None

    def display_info(self):
        opiekun = self.volunteer if self.volunteer else "Brak"
        print(f"Imię: {self.name} ({self.species}), Wiek: {self.age} lat  | Opiekun: {opiekun}")

class Volunteer:
    def __init__(self, name, phone):
        self.name = name
        self.phone = phone

    def contact(self):
        print(f"Imię i nazwisko: {self.name} | Telefon: {self.phone}")
        
    def assign_animal(self, animal):
        animal.volunteer = self.name

class Adoption:
    def __init__(self, animal, adopter_name):
        self.animal = animal
        self.adopter_name = adopter_name
        self.animal.adopter = adopter_name 

    def adoption_info(self):
        print(f"Zaadoptowane zwierzę: {self.animal.name} | Adoptujący: {self.adopter_name}")



animal1 = Animal("Milka", "Kot", 3)
animal2 = Animal("Kapsel", "Pies", 10)

volunteer1 = Volunteer("Anna Nowak", "123-456-789")

volunteer1.assign_animal(animal2) 

adoption1 = Adoption(animal1, "Marek Kowalski")
adoption2 = Adoption(animal2, "Jadwiga Rybak")

print("Zwierzęta: ")
print("_"*100)
animal1.display_info()
animal2.display_info()

print("="*100)

print("\nWolontariusze: ")
print("_"*100)
volunteer1.contact()


print("="*100)

print("\nAdopcje: ")
print("_"*100)
adoption1.adoption_info()
adoption2.adoption_info()
