using Entities;
using Interfaces.DataAccess;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> repositoryBook;
        private readonly IGenericRepository<Author> repositoryAuthor;
        private readonly IGenericRepository<Editorial> repositoryEditorial;

        public BooksController(
            IGenericRepository<Book> repositoryBook, 
            IGenericRepository<Author> repositoryAuthor, 
            IGenericRepository<Editorial> repositoryEditorial)
        {
            this.repositoryBook = repositoryBook;
            this.repositoryAuthor = repositoryAuthor;
            this.repositoryEditorial = repositoryEditorial;
        }

        // GET api/books
        [HttpGet]
        public async Task<ActionResult> Get(string title, string authorName, int year)
        {
            var list = await repositoryBook.GetAllAsync(filter => 
                (string.IsNullOrEmpty(title) || filter.Title.Contains(title))
                && (string.IsNullOrEmpty(authorName) || filter.Author.Name.Contains(authorName))
                && (year <= 0 || filter.Year.Year == year), new List<string>() {
                    "Author"
                });

            return Ok(list);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(BookDto book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (book?.AuthorDto?.Id == null)
            {
                return BadRequest("El autor no está registrado");
            }

            try
            {
                Author author = await repositoryAuthor.GetAsync(filter => filter.Id == book.AuthorDto.Id);
                if (author == null)
                {
                    return BadRequest("El autor no está registrado");
                }

                Editorial editorial = await repositoryEditorial.GetAsync(filter => filter.Id == book.EditorialDto.Id, 
                    new List<string>()
                    {
                        "Book"
                    });               
                if (editorial == null )
                {
                    return BadRequest("La editorial no está registrada");
                }

                if (editorial.Book.Count >= editorial.MaxRegisteredBooks)
                {
                    return BadRequest("No es posible registrar el libro, se alcanzó el máximo permitido");
                }

                Book bookToCreate = new Book()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Gender = book.Gender,
                    NumberOfPages = book.NumberOfPages,
                    Year = book.Year,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null,
                    AuthorId = author.Id,
                    Author = author,
                    EditorialId = editorial.Id,
                    Editorial = editorial
                };

                await repositoryBook.AddAsync(bookToCreate);
                Book createdBook = await repositoryBook.GetAsync(filter => filter.Id == bookToCreate.Id);
                return Ok(createdBook);
            }
            catch(Exception ex)
            {
                return BadRequest("Error al crear el libro.");
            }            
        }
    }
}