using System;
using Instem.Movies.Shared.Model;

namespace Instem.Movies.State
{
    public class AppState
    {
        public Movie SelectedMovie {get; private set;}

        public event Action OnChangeSelectedMovie;

        public void SetSelectedMovie(Movie movie)
        {
            SelectedMovie = movie;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChangeSelectedMovie?.Invoke();
    }
}