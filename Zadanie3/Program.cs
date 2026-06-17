using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    // ABSTRAKCJA:
    public abstract class Room
    {
        // ENKAPSULACJA:
        public string RoomNumber { get; private set; }
        public decimal BasePrice { get; private set; }
        public bool IsAvailable { get; private set; }

        // KONSTRUKTOR:
        protected Room(string roomNumber, decimal basePrice)
        {
            RoomNumber = roomNumber;
            BasePrice = basePrice;
            IsAvailable = true;
        }

        public void Rent()
        {
            if (!IsAvailable) throw new Exception("Pokój jest już zajęty!");
            IsAvailable = false;
        }

        public void Release()
        {
            IsAvailable = true;
        }

        // POLIMORFIZM:
        public abstract decimal CalculatePrice(int days);

        public virtual string GetDescription()
        {
            return $"Pokój {RoomNumber} (Cena bazowa: {BasePrice} PLN/noc) - Dostępny: {IsAvailable}";
        }
    }

    // DZIEDZICZENIE:
    public class StandardRoom : Room
    {
        public StandardRoom(string roomNumber, decimal basePrice) : base(roomNumber, basePrice) { }

        // POLIMORFIZM:
        public override decimal CalculatePrice(int days)
        {
            return BasePrice * days;
        }

        public override string GetDescription()
        {
            return "[Standard] " + base.GetDescription();
        }
    }

    // DZIEDZICZENIE:
    public class SuiteRoom : Room
    {
        public bool HasJacuzzi { get; private set; }

        public SuiteRoom(string roomNumber, decimal basePrice, bool hasJacuzzi) : base(roomNumber, basePrice)
        {
            HasJacuzzi = hasJacuzzi;
        }

        // POLIMORFIZM:
        public override decimal CalculatePrice(int days)
        {
            decimal total = BasePrice * days;
            if (HasJacuzzi) total += 150 * days; 
            return total;
        }

        public override string GetDescription()
        {
            string jacuzziStr = HasJacuzzi ? "Z Jacuzzi" : "Bez Jacuzzi";
            return $"[Apartament] {base.GetDescription()} - {jacuzziStr}";
        }
    }

    // IDENTYFIKATORY:
    public class Guest
    {
        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Guest(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName() => $"{FirstName} {LastName}";
    }

    public class Reservation
    {
        public string ReservationId { get; private set; }
        public Guest Guest { get; private set; } 
        public Room Room { get; private set; }   
        public int Days { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Reservation(string id, Guest guest, Room room, int days)
        {
            ReservationId = id;
            Guest = guest;
            Room = room;
            Days = days;
            TotalPrice = room.CalculatePrice(days); 
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Rezerwacja {ReservationId}: {Guest.GetFullName()} -> {Room.RoomNumber} na {Days} dni. Koszt: {TotalPrice} PLN.");
        }
    }

    public class HotelManager
    {
        // RELACJE: 
        private List<Room> _rooms = new List<Room>();
        private List<Reservation> _reservations = new List<Reservation>();
        private int _reservationCounter = 1;

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public void DisplayRooms()
        {
            foreach (var room in _rooms)
            {
                Console.WriteLine(room.GetDescription());
            }
        }

        // RELACJE:
        public Reservation BookRoom(Guest guest, Room room, int days)
        {
            if (!room.IsAvailable)
            {
                Console.WriteLine($"Błąd: Pokój {room.RoomNumber} jest zajęty.");
                return null;
            }

            room.Rent(); // Enkapsulacja
            string resId = "RES" + _reservationCounter++;
            Reservation res = new Reservation(resId, guest, room, days);
            _reservations.Add(res);

            Console.WriteLine("Pomyślnie utworzono rezerwację!");
            return res;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HotelManager hotel = new HotelManager();

            Room room1 = new StandardRoom("101", 200m);
            Room room2 = new SuiteRoom("901", 500m, hasJacuzzi: true);
            Guest guest1 = new Guest("G-001", "Jan", "Kowalski");
            Guest guest2 = new Guest("G-002", "Anna", "Nowak");

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);

            Console.WriteLine("--- Dostępne pokoje ---");
            hotel.DisplayRooms();

            Console.WriteLine("\n--- Proces Rezerwacji ---");
            Reservation res1 = hotel.BookRoom(guest1, room1, 3);
            res1?.DisplayInfo();

            Reservation res2 = hotel.BookRoom(guest2, room2, 2);
            res2?.DisplayInfo();

            Console.WriteLine("\n--- Pokoje po rezerwacjach ---");
            hotel.DisplayRooms();
        }
    }
}
