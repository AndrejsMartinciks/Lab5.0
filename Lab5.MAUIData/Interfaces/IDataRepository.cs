using Lab5.MAUIData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.MAUIData.Interfaces
{
    public interface IDataRepository
    {
        Task<Author[]> GetAuthorsAsync();

        Task<Book[]> GetAuthorBooksAsync(int authorId);

        Task DeleteBook(int authorId, int bookId);
        Task UpdateAuthorAsync(Author author);
    }
}
