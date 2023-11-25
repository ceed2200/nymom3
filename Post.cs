// Lösning till uppgift Moment 3 i kurs DT071G. Kod skapad av Cecilia Edvardsson

// Klass för att skapa nya inlägg

namespace guestbook;
public class Post
{
    // Medlemsvariabler
    private string? author = "";
    private string? content = "";

    // Konstruktor
    public Post(string inputAuthor, string inputContent)
    {
        author = inputAuthor;
        content = inputContent;
    }

    // Metoder för att hämta ut privata variabler

    public string FetchAuthor()
    {
        return author!;
    }

    public string FetchContent()
    {
        return content!;
    }
}




