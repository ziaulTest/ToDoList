using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public interface IToDoRepository
    {
        List<DocumentCollection> GetListDataStores();

        Task<Document> GetById(string id);

        Task<Document> InsertToDoList(ToDoListItems toDoListItems);

        Task DeleteById(string id);

        Task<Document> UpdateToDoList(string id, PartialToDoItems toDoListItems);
    }
}
