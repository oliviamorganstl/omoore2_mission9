﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace omoore2_mission9.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
