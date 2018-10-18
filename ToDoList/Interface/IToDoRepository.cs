using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public interface IToDoRepository
    {
        Task<List<ToDoListItems>> GetListDataStores();
        // IOrderedQueryable<Document> GetListDataStores();

        Task<ToDoListItems> GetById(string id);

        Task<Document> InsertToDoList(ToDoListItems toDoListItems);

        Task DeleteById(string id);

        Task<Document> UpdateToDoList(string id, PartialToDoItems toDoListItems);
    }
}
