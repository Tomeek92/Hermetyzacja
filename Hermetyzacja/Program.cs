using System.Runtime.CompilerServices;

public class Hermetyzacja
{
   
    public static void Main(string[] args)
    {
        Console.WriteLine("Witaj w HILO!");
        Console.WriteLine("Wybierz liczbe między 1 a 10");
        HiLoGame.Hint();





        while (HiLoGame.GetPot() > 0)
        {
            Console.WriteLine("Wciśnij w (większą),m (mniejszą), lub ? (kupno wskazówki).");
           
            Console.WriteLine($"Inne klawisze to koniec gry z {HiLoGame.GetPot()}zł");
            char key = Console.ReadKey(true).KeyChar;
            if (key == 'w') HiLoGame.Guess(true);
            else if (key == 'm') HiLoGame.Guess(false);
          
            else if (key == '?') HiLoGame.Hint();
            else return;
        }
        Console.WriteLine("Skończyły Ci się pieniądze. Do zobaczenia!");
    }
   
}
static class HiLoGame
{
    public const int MAXIMUM = 10;
    private static Random random = new Random();
    private static int currentNumber = random.Next(1, MAXIMUM + 1);
    private static int pot = 10;

    public static int GetPot() { return pot; }

    public static void Guess(bool guess)
    {
        int nastepnaLiczbaLosowa = random.Next(1, MAXIMUM + 1);
        if ((guess && nastepnaLiczbaLosowa >= currentNumber) || (guess && nastepnaLiczbaLosowa <= currentNumber))
        {
            Console.WriteLine("Zgadłeś");
            pot++;
        }


        else
        {
            Console.WriteLine("Niestety zła odpowiedź");
            pot--;
        }
        currentNumber = nastepnaLiczbaLosowa;
        Console.WriteLine("Aktualna wartość to:" + " " + nastepnaLiczbaLosowa);
    }
    public static void Hint()
    {
        int half = MAXIMUM / 2;

        if (currentNumber >= half)
        {
            Console.WriteLine($"Liczba wynosi conajmniej {half}");

        }



        else
        {
            Console.WriteLine($"Liczba jest mniejsza niż {half}");
        }
        pot--;




    }
}