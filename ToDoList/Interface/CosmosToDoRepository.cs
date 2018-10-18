using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public class CosmosToDoRepository : IToDoRepository
    {
        private const string EndpointUri = "https://bestesttodolist.documents.azure.com:443/";
        // 9XgxGAlkkplAXQvZo6nMI7OzjVqwS3hqFV9SCERK66NOl6RlNzo14jkgH5bitrBSQOQYZ1IqBvHQbuSoKak6cg==
        // N6RCbEOexLlnkmSeMgeg2UBBYGFjerOvAzQ2ngBvV7VirMa51wilFMLeHFqBLBSA9fhXLegnAQISKa1PMm8iTQ==
        private const string PrimaryKey = "N6RCbEOexLlnkmSeMgeg2UBBYGFjerOvAzQ2ngBvV7VirMa51wilFMLeHFqBLBSA9fhXLegnAQISKa1PMm8iTQ==";
        private readonly DocumentClient _client;

        public CosmosToDoRepository()
        {
            _client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            _client.CreateDatabaseIfNotExistsAsync(new Database { Id = "ToDoList" }).Wait();
        }
        public void Dispose()
        {
            _client.Dispose();
        }

        public IOrderedQueryable<Document> GetListDataStores()
        {
            return _client.CreateDocumentQuery(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"));
        }

        public async Task<Document> GetById(string id)
        {
            return await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id));
        }

        public async Task<Document> InsertToDoList(ToDoListItems toDoListItems)
        {
            return await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), toDoListItems);
        }

        public async Task DeleteById(string id)
        {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id));
        }

        public async Task<Document> UpdateToDoList(string id, PartialToDoItems toDoListItems)
        {
            return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id), toDoListItems);
        }
    }
}
