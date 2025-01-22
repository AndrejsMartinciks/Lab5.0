using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;

namespace Lab5.MAUIData.Services
{
    public class ApiDataRepository : IDataRepository
    {
        private readonly IAuthorApiClient _authorApiClient;

        public ApiDataRepository(IAuthorApiClient apiClient)
        {
            _authorApiClient = apiClient;
        }

        public async Task DeleteBook(int authorId, int bookId)
        {
            await _authorApiClient
                .DeleteItemAsync($"{AuthorApiConstants.AuthorsUrl}/{authorId}/{AuthorApiConstants.BooksUrl}/{bookId}");
        }

        public async Task<Book[]> GetAuthorBooksAsync(int authorId)
        {
            var result = await _authorApiClient
                .GetItemsAsync<Book>($"{AuthorApiConstants.AuthorsUrl}/{authorId}/{AuthorApiConstants.BooksUrl}");
            return result;
        }

        public async Task<Author[]> GetAuthorsAsync()
        {
            var result = await _authorApiClient.GetItemsAsync<Author>(AuthorApiConstants.AuthorsUrl);
            return result;
        }

        public async Task UpdateAuthorAsync(Author author)
        {
            await _authorApiClient.UpdateItem<Author>($"{AuthorApiConstants.AuthorsUrl}/{author.Id}", author);
        }
    }
}
