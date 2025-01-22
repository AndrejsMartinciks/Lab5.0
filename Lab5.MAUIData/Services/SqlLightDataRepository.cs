using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Services
{
    public class SqlLightDataRepository : IDataRepository
    {
        public Task DeleteBook(int authorId, int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Book[]> GetAuthorBooksAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Author[]> GetAuthorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAuthorAsync(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
