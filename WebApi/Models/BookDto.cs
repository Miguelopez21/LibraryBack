using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class BookDto
    {
        [Required]
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        
        public DateTime Year { get; set; }

        public string Gender { get; set; }

        [Range(1, 9999)]
        public long NumberOfPages { get; set; }

        [Required]
        public AuthorDto AuthorDto { get; set; }

        [Required]
        public EditorialDto EditorialDto { get; set; }
    }
}