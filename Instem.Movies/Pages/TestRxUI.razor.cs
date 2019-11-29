using Instem.Movies.Shared;
using Instem.Movies.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Instem.Movies.Pages
{
    public class ToDoListView : ComponentBase
    {
        //public ToDoListViewModel DataContext => Service;

        public ToDo ToDo { get; set; } = new ToDo();
    }
}
