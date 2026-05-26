using System;

class Program
{
    static void Main()
    {
        Console.Write("Wybierz konwersję (C - z Celsjusza na Fahrenheita, F - z Fahrenheita na Celsjusza): ");

        // trim usuwa białe znaki a toupper interpretuje male znaki na duze
        string opcja = Console.ReadLine().Trim().ToUpper();

        if (opcja == "C" || opcja == "F")
        {
            Console.Write("Podaj temperaturę: ");
            double temp = Convert.ToDouble(Console.ReadLine());

            if (opcja == "C")
            {
                double wynik = temp * 1.8 + 32;
                Console.WriteLine($"{temp}°C = {wynik}°F");
            }
            else if (opcja == "F")
            {
                double wynik = (temp - 32) / 1.8;
                Console.WriteLine($"{temp}°F = {wynik}°C");
            }
        }
        else
        {
            Console.WriteLine("Błąd! Wpisz C lub F.");
        }
    }
}
