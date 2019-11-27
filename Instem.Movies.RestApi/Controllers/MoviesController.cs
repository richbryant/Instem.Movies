﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Instem.Movies.Data;
using Instem.Movies.Shared.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Instem.Movies.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly string _dataLocation;
        private readonly DataLoader _dataLoader;

        public MoviesController(ILogger<MoviesController> logger, IHostEnvironment environment)
        {
            _logger = logger;
            _dataLocation = environment.ContentRootPath + "/moviedata.json";
            _dataLoader = new DataLoader(_dataLocation);
        }

        [HttpGet]
        public async Task<List<Movie>> Get()
        {
            return await _dataLoader.LoadHomePageSelectionAsync();
        }

        [HttpGet]
        public async Task<List<Movie>> Get(string criteria)
        {
            return await _dataLoader.SearchResultsAsync(criteria);
        }
    }
}