using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities;
using Interfaces.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IGenericRepository<Author> repository;

        public AuthorsController(IGenericRepository<Author> repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> Post(AuthorDto author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await repository.AddAsync(new Author()
                {
                    Id = author.Id,
                    Name = author.Name,
                    City = author.City,
                    Birthday = author.Birthday,
                    Email = author.Email,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null
                });
               
                Author authorCreate = await repository.GetAsync(filter =>filter.Id == author.Id);
                return Ok(authorCreate);
            }
            catch 
            {
                return BadRequest("Error al crear el Autor");
            }           
        }
    }
}