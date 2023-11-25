// Lösning till uppgift Moment 3 i kurs DT071G. Kod skapad av Cecilia Edvardsson

namespace guestbook;

class Program
{
    static void Main(string[] args)
    {
        // Tömmer eventuell tidigare skrift
        Console.Clear();

        // Presentation av innehåll
        Console.WriteLine(" ");
        Console.WriteLine("--------------------------- ");
        Console.WriteLine("Cecilias gästbok (´•o•`)");
        Console.WriteLine("--------------------------- ");
        Console.WriteLine(" ");

        // Tar fram listan med inlägg genom klassen Guestbook
        Guestbook.ShowPosts();

        // Huvudmenyn
        Console.WriteLine(" ");
        Console.WriteLine("Vad vill du göra? Välj siffra eller bokstav enligt nedanstående alternativ.");
        Console.WriteLine("1. Skriv nytt inlägg");
        Console.WriteLine("2. Ta bort inlägg");
        Console.WriteLine("X. Avsluta programmet");
        Console.WriteLine(" ");

        // Hämta in användarens kommando för att göra något
        string? inputAction = Console.ReadLine();

        // Val av åtgärd i gästboken inklusive kontroll att rimligt input görs
        while (inputAction != "1" && inputAction != "2" && inputAction != "X" && inputAction != "x")
        {
            Console.WriteLine("Vänligen välj åtgärd bland de listade alternativen.");
            inputAction = Console.ReadLine();
        }

        if (inputAction == "1")
        {
            // Inlägg skapas och lagrasgenom klassen Guestbook
            Guestbook.WritePost();

            // När man lämnar sidan för att skriva inlägg hamnar man hos huvudmenyn igen
            Console.Clear();
            Main(args);
        }
        else if (inputAction == "2")
        {
            // Inlägg raderas genom klassen Guestbook
            Guestbook.ErasePost();

            // När man lämnar sidan för att radera inlägg hamnar man hos huvudmenyn igen
            Console.Clear();
            Main(args);
        }
        else if (inputAction == "X" || inputAction == "x")
        {
            // Stänger programmet
            Environment.Exit(0);
        }

    }
}
