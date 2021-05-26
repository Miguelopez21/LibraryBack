using System;

namespace Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Email { get; set; }     
    }
}
