// Lösning till uppgift Moment 3 i kurs DT071G. Kod skapad av Cecilia Edvardsson

using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace guestbook;

// Klass för att visa, lagra och radera inlägg
class Guestbook
{
    // Medlemsvariabler
    public string? Author { get; set; }
    public string? Content { get; set; }

    // Metod för att visa inlägg i lista från filen posts.json
    public static void ShowPosts()
    {
        // Hämtar in JSON-fil där inlägg lagras
        var postsFile = File.ReadAllText(@"./posts.json");

        // Lista skapas med struktur efter medlemsvariabler
        var postsList = JsonSerializer.Deserialize<List<Guestbook>>(postsFile);

        // Presentation
        Console.WriteLine("*** Lagrade inlägg ***");

        // Om inlägg finns lagrade så listas dessa
        if (postsList!.Count > 0)
        {
            for (var i = 0; postsList.Count > i; i++)
            {
                Console.WriteLine("[" + i + "] " + postsList[i].Author + " - " + postsList[i].Content);
            }
            Console.WriteLine("**********************");
        }
        else
        {
            Console.WriteLine("******************");
            Console.WriteLine("Inga inlägg finns lagrade ännu.");
            Console.WriteLine("******************");
        }
    }

    // Metod för att lagra inlägg
    public static void WritePost()
    {
        // Ser till att Console hämtar in och skriver ut åäö
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        // Tömmer tidigare skrift
        Console.Clear();

        // Presentation av innehåll
        Console.WriteLine(" ");
        Console.WriteLine("--------------------------- ");
        Console.WriteLine("Cecilias gästbok (´•o•`)");
        Console.WriteLine("--------------------------- ");
        Console.WriteLine(" ");
        ShowPosts();
        Console.WriteLine(" ");
        Console.WriteLine("Här kan du skriva nytt inlägg i gästboken.");
        Console.WriteLine("(För att gå tillbaka till programmets start, skriv 'X')");
        Console.WriteLine(" ");

        // Tar reda på författare
        Console.WriteLine("Vad heter du?");
        string? authorInput = Console.ReadLine();

        // Ger möjlighet att avsluta och återgå till huvudmeny
        while (authorInput == "X" || authorInput == "x")
        {
            return;
        }

        // Kontrollerar input
        while (authorInput?.Length < 3)
        {
            Console.WriteLine("Vad heter du? (Minst 3 tecken)");
            authorInput = Console.ReadLine();
        }

        // Tar reda på innehåll
        Console.WriteLine("Vad vill du skriva?");
        string? contentInput = Console.ReadLine();

        // Ger möjlighet att avsluta och återgå till huvudmeny
        while (contentInput == "X" || contentInput == "x")
        {
            return;
        }

        // Kontrollerar input
        while (contentInput?.Length < 3)
        {
            Console.WriteLine("Vad vill du skriva? (Minst 3 tecken)");
            contentInput = Console.ReadLine();
        }

        // Nytt inlägg skapas genom klassen Post
        Post newpost = new Post(authorInput!, contentInput!);

        // Tar fram tidigare sparade inlägg och skapar lista
        var postsFile = File.ReadAllText(@"./posts.json");
        var postsList = JsonSerializer.Deserialize<List<Guestbook>>(postsFile);

        // Lägger till inlägg i listan baserat på input
        postsList?.Add(new Guestbook() { Author = newpost.FetchAuthor(), Content = newpost.FetchContent() });

        // Säkerställer att åäö fungerar
        var unicodeOption = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        // Skapar ny fil med nya listan
        string fileName = "posts.json";
        string jsonString = JsonSerializer.Serialize(postsList, unicodeOption);
        File.WriteAllText(fileName, jsonString);

        // Metoden körs om för att ge ny chans till att addera inlägg
        WritePost();
    }

    public static void ErasePost()
    {
        // Tömmer tidigare skrift
        Console.Clear();

        // Presentation av innehåll
        Console.WriteLine(" ");
        Console.WriteLine("--------------------------- ");
        Console.WriteLine("Cecilias gästbok (´•o•`)");
        Console.WriteLine("--------------------------- ");
        Console.WriteLine(" ");
        ShowPosts();
        Console.WriteLine(" ");
        Console.WriteLine("För att radera ett inlägg, fyll i numret på inlägget.");
        Console.WriteLine("Om du vill återgå till programmets start, fyll i 'X'.");
        Console.WriteLine(" ");

        // Tar reda på önskad radering
        string? eraseInput = Console.ReadLine();

        // Kontrollerar input
        while (eraseInput?.Length < 1)
        {
            Console.WriteLine("Vänligen uppge vilket inlägg du vill tas bort.");
            eraseInput = Console.ReadLine();
        }

        // Ger möjlighet att avsluta
        while (eraseInput == "X" || eraseInput == "x")
        {
            return;
        }

        // Tar fram tidigare sparade inlägg och skapar lista
        var postsFile = File.ReadAllText(@"./posts.json");
        var postsList = JsonSerializer.Deserialize<List<Guestbook>>(postsFile);

        // Tar bort inlägg i listan baserat på input
        int chosenItem = Convert.ToInt32(eraseInput);

        if (chosenItem > postsList!.Count)
        {
            Console.WriteLine("Du har angett ett nummer som inte tillhör något inlägg. Tryck på valfri tangent för att göra ett nytt försök att radera inlägg.");
            Console.ReadLine();
            ErasePost();
        }

        postsList!.RemoveAt(chosenItem);

        // Säkerställer att åäö fungerar
        var unicodeOption = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        // Skapar ny fil med nya listan
        string fileName = "posts.json";
        string jsonString = JsonSerializer.Serialize(postsList, unicodeOption);
        File.WriteAllText(fileName, jsonString);

        // Fler raderingar kan göras då denna del laddas om
        ErasePost();
    }
}




