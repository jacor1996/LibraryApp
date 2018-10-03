﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace Library.Repositories.Interfaces
{
    interface IAuthorRepository
    {
        IEnumerable<Author> GetAuthors();

        Author GetAuthorById(int id);

        void CreateAuthor(Author author);

        void UpdateAuthor(Author author);

        void DeleteAuthor(int id);
    }
}
