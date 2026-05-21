using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj pierwszą liczbę: ");
        double l1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Podaj drugą liczbę: ");
        double l2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Operatory arytmetyczne \n Dodawanie + \n Odejmowanie - \n Mnożenie * \n Dzielenie / \n Wybierz operację: ");
        string opcja = Console.ReadLine();

        if (opcja == "+")
        {
            Console.WriteLine($"Wynik: {l1 + l2}");
        }
        else if (opcja == "-")
        {
            Console.WriteLine($"Wynik: {l1 - l2}");
        }
        else if (opcja == "*")
        {
            Console.WriteLine($"Wynik: {l1 * l2}");
        }
        else if (opcja == "/")
        {
            if (l2 == 0)
            {
                Console.WriteLine("Wynik: Błąd (nie dzieli się przez zero)");
            }
            else
            {
                Console.WriteLine($"Wynik: {l1 / l2}");
            }
        }
        else
        {
            Console.WriteLine("Wynik: Nie rozpoznano operatora");
        }
    }
}
