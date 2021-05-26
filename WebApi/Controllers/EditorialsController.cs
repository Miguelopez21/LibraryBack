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
    public class EditorialsController : ControllerBase
    {
        private readonly IGenericRepository<Editorial> repository;

        public EditorialsController(IGenericRepository<Editorial> repository)
        {
            this.repository = repository;
        }
       
        [HttpPost]
        public async Task<ActionResult> Post(EditorialDto editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await repository.AddAsync(new Editorial()
                {
                    Name = editorial.Name,
                    Email = editorial.Email,
                    Direction = editorial.Direction,
                    Phone = editorial.Phone,
                    MaxRegisteredBooks = editorial.MaxRegisteredBooks,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null
                });
                
                Editorial authorCreate = await repository.GetAsync(filter => filter.Id == editorial.Id);
                return Ok(authorCreate);
            }
            catch 
            {
                return BadRequest("Error al crear la Editorial");
            }           
        }         
    }
}