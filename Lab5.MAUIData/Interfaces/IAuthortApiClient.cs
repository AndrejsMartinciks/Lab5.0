using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.MAUIData.Interfaces
{
    public interface IAuthorApiClient
    {
        Task<T[]> GetItemsAsync<T>(string url) where T : class;

        Task DeleteItemAsync(string url);

        Task UpdateItem<T>(string url, T entity) where T : class;
    }
}
