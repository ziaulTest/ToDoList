using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public interface IToDoRepository
    {
        Task<List<ToDoListItems>> GetListDataStores();

        Task<ToDoListItems> GetById(string id);

        Task<bool> InsertToDoList(ToDoListItems toDoListItems);

        Task DeleteById(string id);

        Task<bool> UpdateToDoList(string id, PartialToDoItems toDoListItems);
    }
}
