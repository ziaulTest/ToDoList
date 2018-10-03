using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace ToDoList.Interface
{
    public interface IDocumentDbRepository
    {
        Task<T> GetItemAsync<T>(string id) where T : class;

        Task<Document> CreateItemAsync<T>(T item) where T : class;

        Task<Document> UpdateItemAsync<T>(string id, T item) where T : class;

        Task DeleteItemAsync(string id);
    }
}
