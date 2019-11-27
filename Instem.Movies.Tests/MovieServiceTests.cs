using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Instem.Movies.Data;
using Instem.Movies.Shared.Model;

namespace Instem.Movies.Tests
{
    [TestFixture]
    public class MovieServiceTests
    {
        [Test]
        public void LoadDataFromJsonFileTest()
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader(dataLocation);
            var loadedData = loaderUnderTest.Load();

            loadedData.Should().BeOfType(typeof(List<Movie>));
            loadedData.Should().NotBeEmpty();

        }

        [Test]
        public void Homepage_LoadFourMoviesByDescendingYear()
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader(dataLocation);
            var loadedData = loaderUnderTest.LoadHomePageSelection();

            loadedData.Should().BeOfType(typeof(List<Movie>));
            loadedData.Count.Should().Be(4);
        }

        [Test]
        public async Task Homepage_LoadFourMoviesByDescendingYearAsync()
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader(dataLocation);
            var loadedData = await loaderUnderTest.LoadHomePageSelectionAsync();

            loadedData.Should().BeOfType(typeof(List<Movie>));
            loadedData.Count.Should().Be(4);
        }

        [TestCase("1982", 0)]
        [TestCase("Hunger", 0)]
        [TestCase("Action", 0)]
        [TestCase("Scott", 0)]
        [TestCase("Ford", 0)]
        [TestCase("replicants", 0)]
        [TestCase("Cucumber", 1)]
        public void SearchReturnsData(string criteria, int countResult)
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader(dataLocation);
            var loadedData = loaderUnderTest.SearchResults(criteria);

            loadedData.Should().BeOfType(typeof(List<Movie>));
            (0 - loadedData.Count).Should().BeLessThan(countResult);
        }

        [TestCase("1982", 0)]
        [TestCase("Hunger", 0)]
        [TestCase("Action", 0)]
        [TestCase("Scott", 0)]
        [TestCase("Ford", 0)]
        [TestCase("replicants", 0)]
        [TestCase("Cucumber", 1)]
        public async Task SearchReturnsDataAsync(string criteria, int countResult)
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader(dataLocation);
            var loadedData = await loaderUnderTest.SearchResultsAsync(criteria);

            loadedData.Should().BeOfType(typeof(List<Movie>));
            (0 - loadedData.Count).Should().BeLessThan(countResult);
        }
    }
}