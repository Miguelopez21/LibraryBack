using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AuthorDto
    {
        [Required]
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string City { get; set; }

        public string Email { get; set; }
    }
}
