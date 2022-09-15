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
    
    [HttpPost]
    public async Task<ActionResult<List<LibraryAPI>>> addBook(LibraryAPI libraryApi) 
    {
        books.Add(libraryApi);
        return Ok(books);
    }

    }
    