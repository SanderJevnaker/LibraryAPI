using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Model;

namespace LibraryAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class BooksController : Controller
{
    public static List<Book> books = new List<Book>
    {
        new Book {
                Id = 1,
                Published = DateTime.Now,
                Title = "Daniel Gustav for dummies",
                Isbn = 184827283,
                Subject = "Backend",
                Author = "Sander Jevnaker",
                Version = "v2",
                Shelf = "A32",
                Language = "Norwegian"
            }
        };

    [HttpGet] 
    public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(books);
        }
        
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetId(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book == null)
            return BadRequest("Book not found");
        return Ok(book);
    }
    
    [HttpGet("/title/{title}")]
    public async Task<ActionResult<Book>> GetTitle(string title)
    {
        var book = books.Find(b => b.Title == title);
        if (book == null)
            return BadRequest("Book not found");
        return Ok(book);
    }
    
    
    [HttpGet("/isbn/{isbn}")]
    public async Task<ActionResult<Book>> GetIsbn(long isbn)
    {
        var book = books.Find(b => b.Isbn == isbn);
        if (book == null)
            return BadRequest("Book not found");
        return Ok(book);
    }
    
    [HttpGet("/author/{author}")]
    public async Task<ActionResult<Book>> GetAuthor(string author)
    {
        var book = books.Find(b => b.Author == author);
        if (book == null)
            return BadRequest("Book not found");
        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Book>>> AddBook(Book libraryApi) 
    {
        books.Add(libraryApi);
        return Ok(books);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Book>>> UpdateBook(Book request)
    {
        var book = books.Find(b => b.Id == request.Id);
        if (book == null)
            return BadRequest("Book not found");
        
        book.Id = request.Id;
        book.Title = request.Title;
        book.Isbn = request.Isbn;
        book.Subject = request.Subject;
        book.Author = request.Author;
        book.Version = request.Version;
        book.Shelf = request.Shelf;
        book.Language = request.Language;

        return Ok(books);

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Book>>> DeleteBook(int id)
    {
        var book = books.Find(b => b.Id == id);
        if (book == null)
            return BadRequest("Book not found");

        books.Remove(book);
        return Ok(books);
    }

    }
    