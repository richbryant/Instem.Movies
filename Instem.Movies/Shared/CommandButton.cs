using System.Windows.Input;
using Microsoft.AspNetCore.Components;

namespace Instem.Movies.Shared
{
    public class CommandButton : Blazorise.Button
    {
        [Parameter]
        public ICommand Command { get; set; }
    }
}