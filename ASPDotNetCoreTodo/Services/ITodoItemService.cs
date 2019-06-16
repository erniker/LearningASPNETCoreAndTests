using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASPDotNetCoreTodo.Models;
using ASPDotNetCoreTodo.Services;


namespace ASPDotNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(ApplicationUser user);
        
        //Ambos métodos de servicio deben aceptar un parámetro ApplicationUser
        Task<bool> AddItemAsync(TodoItem newItem, ApplicationUser user);
        Task<bool> MarkDoneAsync(Guid id, ApplicationUser user);
    }
}