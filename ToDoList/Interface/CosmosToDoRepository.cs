using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public class CosmosToDoRepository : IToDoRepository
    {
        private const string EndpointUri = "https://to-dolist.documents.azure.com:443/";
        private const string PrimaryKey = "9XgxGAlkkplAXQvZo6nMI7OzjVqwS3hqFV9SCERK66NOl6RlNzo14jkgH5bitrBSQOQYZ1IqBvHQbuSoKak6cg==";
        private readonly DocumentClient _client;
        private readonly string DatabaseName = "ToDoList";

        public CosmosToDoRepository()
        {
            _client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
            _client.CreateDatabaseIfNotExistsAsync(new Database { Id = "ToDoList" }).Wait();
        }
        public void Dispose()
        {
            _client.Dispose();
        }

        public List<DocumentCollection> GetListDataStores()
        {
            var collections = _client.CreateAttachmentQuery<DocumentCollection>("Items", "SELECT * FROM c").ToList();

            return collections;
            //List<DocumentCollection> collections = _client.CreateDocumentCollectionQuery(DatabaseName).ToList();
            //_client.CreateDatabaseQuery("SELECT * FROM d WHERE d.id = \"[ToDoList]\"").AsEnumerable().First();
            //return collections;
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
