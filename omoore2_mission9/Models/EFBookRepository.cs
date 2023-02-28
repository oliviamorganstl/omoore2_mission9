using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omoore2_mission9.Models
{
    public class EFBookRepository : IBookRepository
    {
        private BookContext context { get; set; }
        public EFBookRepository(BookContext temp)
        {
            context = temp;
        }
        public IQueryable<Book> Books => context.Books;
    }
}
