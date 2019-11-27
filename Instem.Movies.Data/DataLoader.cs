using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Instem.Movies.Shared.Model;


namespace Instem.Movies.Data
{
    public class DataLoader
    {
        public List<Movie> Load(string dataLocation)
        {
            var list = new List<Movie>();
            using(var sr = new StreamReader(dataLocation))
            {
                var data = sr.ReadToEnd();
                list.AddRange(JsonSerializer.Deserialize<List<Movie>>(data));
            }
            return list;
        }
    }
}
