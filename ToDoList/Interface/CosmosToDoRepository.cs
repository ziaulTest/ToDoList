using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public class CosmosToDoRepository : IToDoRepository
    {
        private const string EndpointUri = "https://bestesttodolist.documents.azure.com:443/";
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

        public async Task<List<ToDoListItems>> GetListDataStores()
        {
            var DB_Collection = _client.CreateDocumentQuery<ToDoListItems>(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items")).AsDocumentQuery();
            return (await DB_Collection.ExecuteNextAsync<ToDoListItems>()).ToList();
        }

        public async Task<ToDoListItems> GetById(string id)
        {
            return await _client.ReadDocumentAsync<ToDoListItems>(UriFactory.CreateDocumentUri("ToDoList", "Items", id));
        }

        public async Task<bool> InsertToDoList(ToDoListItems toDoListItems)
        {
            await _client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), toDoListItems);
            return true;
        }

        public async Task DeleteById(string id)
        {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id));
        }

        public async Task<Document> UpdateToDoList(string id, PartialToDoItems toDoListItems)
        {
            return await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri("ToDoList", "Items", id),toDoListItems);

            //var toDoListItem = ToDoListDataStore.Current.ToDoList.FirstOrDefault(l => l.Id == id.ToString());

            //if (toDoListItem == null) return;
            //toDoListItem.Priority = toDoListItems.Priority;
            //toDoListItem.Task = toDoListItems.Task;
        }
    }
}
