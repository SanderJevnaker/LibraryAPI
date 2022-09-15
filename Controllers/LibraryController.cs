using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class LibraryController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        //Test
        var test = new List<LibraryAPI>
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
        return Ok(test);

    }
}