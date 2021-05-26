
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Editorial : BaseEntity
    {
       public string Name { get; set; }
       public string Direction { get; set; }
       public long Phone { get; set; }
       public string Email { get; set; }
       public long MaxRegisteredBooks { get; set; }

       [InverseProperty("Editorial")]
       public virtual List<Book> Book { get; set; }
    }
}
