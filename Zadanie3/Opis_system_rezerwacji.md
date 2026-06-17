System Rezerwacji Pokoi Hotelowych

1. Opis tematu

Aplikacja to uproszczony system zarządzania rezerwacjami w hotelu. Pozwala na dodawanie pokoi różnego typu (standardowe oraz apartamenty), rejestrację gości oraz tworzenie rezerwacji. System weryfikuje dostępność pokoju przed dokonaniem rezerwacji i automatycznie oblicza jej koszt w zależności od typu pokoju i liczby dni.

3. Lista klas
   
* Room (Klasa abstrakcyjna) – bazowa klasa reprezentująca pokój hotelowy. Przechowuje wspólne cechy (numer pokoju, cena bazowa, status dostępności).
* StandardRoom – dziedziczy po `Room`. Zwykły pokój hotelowy.
* SuiteRoom – dziedziczy po `Room`. Luksusowy apartament (posiada dodatkową właściwość określającą obecność jacuzzi i modyfikuje sposób obliczania ceny).
* Guest – reprezentuje gościa hotelowego (przechowuje unikalne ID, imię, nazwisko i dane kontaktowe).
* Reservation – klasa łącząca gościa, pokój oraz czas trwania pobytu. Odpowiada za przechowywanie szczegółów konkretnej transakcji.
* HotelManager – klasa zarządzająca logiką systemu. Realizuje zasadę jednej odpowiedzialności (Single Responsibility) poprzez zarządzanie kolekcjami pokoi, gości i rezerwacji, zamiast wrzucać tę logikę do samych pokoi.

3. Opis relacji między klasami
   
  1.  Kolekcja (Kompozycja/Agregacja): Klasa `HotelManager` posiada kolekcje (listy) obiektów `Room`, `Guest` oraz `Reservation`.
  2.  Agregacja: Klasa `Reservation` agreguje w sobie obiekty `Guest` oraz `Room` (przechowuje referencje do nich jako swoje właściwości). Rezerwacja nie może istnieć bez gościa i pokoju.
  3.  Parametry metod: Metoda `BookRoom` w klasie `HotelManager` przyjmuje jako parametry obiekty `Guest` i `Room`, łącząc je w nową rezerwację.

4. Wskazanie czterech zasad OOP
   
* Abstrakcja: Klasa `Room` jest klasą abstrakcyjną. Narzuca ona kontrakt – wymusza na klasach pochodnych implementację metody `CalculatePrice(int days)`. Nie można utworzyć instancji samego "ogólnego pokoju".
* Dziedziczenie: Klasy `StandardRoom` i `SuiteRoom` dziedziczą po klasie `Room`. Rozszerzają jej funkcjonalność i reprezentują relację "jest rodzajem" (Apartament *jest rodzajem* pokoju).
* Polimorfizm: Metoda `CalculatePrice(int days)` jest wywoływana na obiektach typu `Room`, ale wykonuje się inaczej w zależności od tego, czy pod spodem kryje się `StandardRoom` (zwykłe mnożenie), czy `SuiteRoom` (doliczana jest dodatkowa opłata za luksusowy standard).
* Enkapsulacja: Pola obiektów (np. `_isAvailable` w Pythonie lub własności z `private set` w C#) są chronione przed niekontrolowaną zmianą. Zmiana statusu pokoju odbywa się wyłącznie przez dedykowane metody `Rent()` i `Release()`.
