using System;

class Program
{
    static void Main()
    {
        Console.Write("Podaj liczbę ocen: ");
        int liczbaOcen = Convert.ToInt32(Console.ReadLine());

        double sumaOcen = 0;

        for (int i = 0; i < liczbaOcen; i++)
        {
            Console.Write($"Podaj ocenę {i + 1}: ");
            double ocena = Convert.ToDouble(Console.ReadLine());
            sumaOcen += ocena;
        }

        if (liczbaOcen > 0)
        {
            double srednia = sumaOcen / liczbaOcen;

            //F2 to ilosc miejsc po przecinku
            Console.WriteLine($"Średnia: {srednia.ToString("F2")}");

            if (srednia >= 3.0)
            {
                Console.WriteLine("Uczeń zdał.");
            }
            else
            {
                Console.WriteLine("Uczeń nie zdał.");
            }
        }
        else
        {
            Console.WriteLine("Brak ocen do obliczenia średniej.");
        }
    }
}
