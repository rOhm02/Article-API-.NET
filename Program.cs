using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using SimpleApi;
using System.Text;

// Mock data of articles
List<Article> articles = new List<Article> { new Article(0, "HTML Dokumente", "Ren� Ohm", "17. Januar 2018 20:48", "Eine Kurze Einf�hrung in HTML Dokumente", "HTML Dokumente dienen der Strukturierung von Inhalten, die im Web bzw. mit Webtechnologien wie Internetbrowser und Hypertext Transfer Protocol (HTTP) verbreitet werden sollen. HTML Dokumente bestehen aus HTML-Elementen.", new string[] {"HTML5", "Dokument", "HTTP" }),
                                             new Article(1, "HTML Elemente", "Ren� Ohm", "16. Januar 2018 21:14", "Eine Kurze Einf�hrung in HTML Elemente", "Die HTML Elemente eines HTML Dokuments sind ineinander geschachtelt und bilden damit eine hierarchische Struktur, einen Baum.", new string[] {"HTML5", "Element"}, "baum.png"),
                                             new Article(2, "Semantische Strukturierung von HTML-Seiten", "Ren� Ohm", "16. Januar 2018 19:03", "Ein kurzer �berblick �ber semantische Elemente in HTML5", "In der Vergangenheit wurden HTML-Dokumente h�ufig mit Tabellen oder Frames (ok, sehr weit zur�ckliegende Vergangenheit...) strukturiert.", new string[] {"Semantik", "HTML5", "Element" }) };


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

RouteGroupBuilder articleItems = app.MapGroup("/articles");
app.MapGet("/", () => "Hello World!");
app.MapGet("/test", () => "This is a test");

articleItems.MapGet("/", GetArticles);
articleItems.MapGet("/{id}", GetArticle);
articleItems.MapPost("/", PostArticle);
articleItems.MapPut("/{id}", PutArticle);
articleItems.MapDelete("/{id}", DeleteArticle);

app.Run();


// Get all articles
List<Article> GetArticles()
{
    return articles;
}

// Get specific article with id
Article GetArticle(int id)
{
    return articles.Find(a => a.id == id);
}

// Add new article with id being the curren max id incremented
Article PostArticle([FromBody] Article article)
{
    int maxId = articles.Max(a => a.id) + 1;
    article.id = maxId;
    articles.Add(article);
    return articles.Find(a => a.id == maxId);
}

// Update article with given id
Article PutArticle([FromBody] Article article, int id)
{
    Article idArticle = articles.Find(a => a.id == id);
    if (idArticle == null)
    {
        return idArticle;
    }
    int index = articles.FindIndex(a => a.id == id);
    articles[index] = article;
    articles[index].id = id;
    return articles[index];
}

// Delete article with given id
List<Article> DeleteArticle(int id)
{
    articles.RemoveAll(a => a.id == id);
    return articles;
}
