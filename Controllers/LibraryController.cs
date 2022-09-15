using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class LibraryController : Controller
{
    public static List<LibraryAPI> books = new List<LibraryAPI>
    {
        new LibraryAPI {
                Id = 1,
                Title = "SQL for dummies",
                Isbn = 184827283,
                Subject = "Backend",
                Author = "Sander Jevnaker",
                Version = "v2",
                Shelf = "A32",
                Language = "Norwegian"
            }
        };

    [HttpGet] 
    public async Task<ActionResult<List<LibraryAPI>>> Get()
        {
            return Ok(books);
        }
        
    [HttpGet("{id}")]
    public async Task<ActionResult<LibraryAPI>> Get(int id)
    {
        var book = books.Find(h => h.Id == id);
        if (book == null)
            return BadRequest("Book not found");
        return Ok(book);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<LibraryAPI>>> addBook(LibraryAPI libraryApi) 
    {
        books.Add(libraryApi);
        return Ok(books);
    }
    
    [HttpPut]
    public async Task<ActionResult<List<LibraryAPI>>> updateBook(LibraryAPI request)
    {
        var book = books.Find(h => h.Id == request.Id);
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

    }
    