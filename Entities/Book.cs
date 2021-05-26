using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Gender { get; set; }
        public long NumberOfPages { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public long AuthorId { get; set; }

        [ForeignKey("EditorialId")]
        public Editorial Editorial { get; set; }
        public long EditorialId { get; set; }
    }
}
