using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Library.DTO;
using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly DBContext DBContext;

        public BooksController(DBContext DBContext)
        {
            this.DBContext = DBContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksDTO>>> Get()
        {
            //DBContext db = new DBContext();
            var List = await DBContext.Books.Select(
                s => new BooksDTO
                {
                    Id = s.Id,
                    Published = s.Published,
                    Title = s.Title,
                    Isbn = s.Isbn,
                    Subject = s.Subject,
                    Author = s.Author,
                    Version = s.Version,
                    Shelf = s.Shelf,
                    Language = s.Language
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BooksDTO>> GetBooksById(int Id)
        {
            BooksDTO Book = await DBContext.Books.Select(s => new BooksDTO
            {
                Id = s.Id,
                Published = s.Published,
                Title = s.Title,
                Isbn = s.Isbn,
                Subject = s.Subject,
                Author = s.Author,
                Version = s.Version,
                Shelf = s.Shelf,
                Language = s.Language
            }).FirstOrDefaultAsync(s => s.Id == Id);

            if (Book == null)
            {
                return NotFound();
            }
            else
            {
                return Book;
            }
        }
        [HttpPost]
        public async Task<HttpStatusCode> InsertBook(BooksDTO books)
        {
            var entity = new Book()
            {
                Id = books.Id,
                Published = books.Published,
                Title = books.Title,
                Isbn = books.Isbn,
                Subject = books.Subject,
                Author = books.Author,
                Version = books.Version,
                Shelf = books.Shelf,
                Language = books.Language
            };
            DBContext.Books.Add(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPut("{Id}")]
        public async Task<HttpStatusCode> UpdateBook(BooksDTO books)
        {
            var entity = await DBContext.Books.FirstOrDefaultAsync(s => s.Id == books.Id);
            entity.Id = books.Id;
            entity.Published = books.Published;
            entity.Title = books.Title;
            entity.Isbn = books.Isbn;
            entity.Subject = books.Subject;
            entity.Author = books.Author;
            entity.Version = books.Version;
            entity.Shelf = books.Shelf;
            entity.Language = books.Language;
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("{Id}")]
        public async Task<HttpStatusCode> DeleteBook(int Id)
        {
            var entity = new Book()
            {
                Id = Id
            };
            DBContext.Books.Attach(entity);
            DBContext.Books.Remove(entity);
            await DBContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

    }


}

