using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class EditorialDto
    {
        [Required]
        public long Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Direction { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }

        [Required]
        public long MaxRegisteredBooks { get; set; }
    }
}
