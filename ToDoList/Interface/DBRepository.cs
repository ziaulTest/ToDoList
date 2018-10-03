using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace ToDoList.Interface
{
    public class DbRepository : IDocumentDbRepository
    {
        private const string EndpointUri = "https://to-dolist.documents.azure.com:443/";
        private const string PrimaryKey = "9XgxGAlkkplAXQvZo6nMI7OzjVqwS3hqFV9SCERK66NOl6RlNzo14jkgH5bitrBSQOQYZ1IqBvHQbuSoKak6cg==";
        private readonly DocumentClient _client;
        private readonly string DatabaseName = "ToDoList";


        public DbRepository()
        {
            _client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            _client.CreateDatabaseIfNotExistsAsync(new Database { Id = "ToDoList" }).Wait();
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public async Task<T> GetItemAsync<T>(string id) where T : class
        {
            await _client.ReadAttachmentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id));

            return (T) (dynamic) _client;
        }

        public async Task<Document> CreateItemAsync<T>(T item) where T : class
        {
            return await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), item);
        }

        public async Task<Document> UpdateItemAsync<T>(string id, T item) where T : class
        {
            return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id), item);
        }

        public async Task DeleteItemAsync(string id)
        {
            await _client.DeleteAttachmentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id));
        }
    }
}
