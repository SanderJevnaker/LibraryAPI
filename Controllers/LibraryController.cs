using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Model;

namespace LibraryAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class BooksController : Controller
{
    public static List<Book> books = new List<Book>
    {
    };

    private readonly DataContext _context;
    public BooksController(DataContext context)
    {
        _context = context;
        
    }

    [HttpGet] 
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        return Ok(await _context.Books.ToListAsync());
    }
        
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetId(int id)
    {
        var book = await _context.Books.FindAsync(id);
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
    
    [HttpGet("/subject/{subject}")]
    public async Task<ActionResult<Book>> GetSubject(string subject)
    {
        var book = books.Find(b => b.Subject == subject);
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
    public async Task<ActionResult<List<Book>>> AddBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return Ok(await _context.Books.ToListAsync());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Book>>> UpdateBook(Book request)
    {
        var dbBook = await _context.Books.FindAsync(request.Id);
        if (dbBook == null)
            return BadRequest("Book not found");
        
        dbBook.Id = request.Id;
        dbBook.Title = request.Title;
        dbBook.Isbn = request.Isbn;
        dbBook.Subject = request.Subject;
        dbBook.Author = request.Author;
        dbBook.Version = request.Version;
        dbBook.Shelf = request.Shelf;
        dbBook.Language = request.Language;

        await _context.SaveChangesAsync();

        return Ok(await _context.Books.ToListAsync());

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Book>>> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return BadRequest("Book not found");

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return Ok(await _context.Books.ToListAsync());
    }

    }
    
    