from abc import ABC, abstractmethod
from typing import List

# ABSTRAKCJA:
class Room(ABC):
    def __init__(self, room_number: str, base_price: float):
        # ENKAPSULACJA:
        self._room_number = room_number
        self._base_price = base_price
        self._is_available = True

    # Właściwości:
    @property
    def room_number(self) -> str:
        return self._room_number
    
    @property
    def is_available(self) -> bool:
        return self._is_available

    def rent(self):
        if not self._is_available:
            raise ValueError(f"Pokój {self._room_number} jest już zajęty!")
        self._is_available = False

    def release(self):
        self._is_available = True

    @abstractmethod
    def calculate_price(self, days: int) -> float:
        pass

    def get_description(self) -> str:
        return f"Pokój {self._room_number} (Cena: {self._base_price} PLN/noc) - Dostępny: {self._is_available}"


# DZIEDZICZENIE:
class StandardRoom(Room):
    def __init__(self, room_number: str, base_price: float):
        super().__init__(room_number, base_price)

    # POLIMORFIZM:
    def calculate_price(self, days: int) -> float:
        return self._base_price * days

    def get_description(self) -> str:
        return f"[Standard] {super().get_description()}"


# DZIEDZICZENIE:
class SuiteRoom(Room):
    def __init__(self, room_number: str, base_price: float, has_jacuzzi: bool):
        super().__init__(room_number, base_price)
        self._has_jacuzzi = has_jacuzzi

    # POLIMORFIZM:
    def calculate_price(self, days: int) -> float:
        total = self._base_price * days
        if self._has_jacuzzi:
            total += 150 * days  
        return total

    def get_description(self) -> str:
        jacuzzi_str = "Z Jacuzzi" if self._has_jacuzzi else "Bez Jacuzzi"
        return f"[Apartament] {super().get_description()} - {jacuzzi_str}"


# IDENTYFIKATORY:
class Guest:
    def __init__(self, guest_id: str, first_name: str, last_name: str):
        self._guest_id = guest_id
        self.first_name = first_name
        self.last_name = last_name

    def get_full_name(self) -> str:
        return f"{self.first_name} {self.last_name}"


# RELACJE:
class Reservation:
    def __init__(self, res_id: str, guest: Guest, room: Room, days: int):
        self.reservation_id = res_id
        self.guest = guest 
        self.room = room   
        self.days = days
        self.total_price = room.calculate_price(days) 

    def display_info(self):
        print(f"Rezerwacja {self.reservation_id}: {self.guest.get_full_name()} -> {self.room.room_number} na {self.days} dni. Koszt: {self.total_price} PLN.")


class HotelManager:
    def __init__(self):
        # RELACJE: 
        self._rooms: List[Room] = []
        self._reservations: List[Reservation] = []
        self._reservation_counter = 1

    def add_room(self, room: Room):
        self._rooms.append(room)

    def display_rooms(self):
        for room in self._rooms:
            print(room.get_description())

    # RELACJE:
    def book_room(self, guest: Guest, room: Room, days: int) -> Reservation:
        if not room.is_available:
            print(f"Błąd: Pokój {room.room_number} jest zajęty.")
            return None

        room.rent() 
        res_id = f"RES-{self._reservation_counter}"
        self._reservation_counter += 1
        
        reservation = Reservation(res_id, guest, room, days)
        self._reservations.append(reservation)
        
        print("Pomyślnie utworzono rezerwację!")
        return reservation


if __name__ == "__main__":
    hotel = HotelManager()

    room1 = StandardRoom("101", 200.0)
    room2 = SuiteRoom("901", 500.0, has_jacuzzi=True)
    
    guest1 = Guest("G-001", "Jan", "Kowalski")
    guest2 = Guest("G-002", "Anna", "Nowak")

    hotel.add_room(room1)
    hotel.add_room(room2)

    print("--- Dostępne pokoje ---")
    hotel.display_rooms()

    print("\n--- Proces Rezerwacji ---")
    res1 = hotel.book_room(guest1, room1, 3)
    if res1:
        res1.display_info()

    res2 = hotel.book_room(guest2, room2, 2)
    if res2:
        res2.display_info()

    print("\n--- Pokoje po rezerwacjach ---")
    hotel.display_rooms()
