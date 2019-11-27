using System.Collections.Generic;
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
            var loaderUnderTest = new DataLoader();
            var loadedData = loaderUnderTest.Load(dataLocation);

            loadedData.Should().BeOfType(typeof(List<Movie>));
            loadedData.Should().NotBeEmpty();

        }

        [Test]
        public void Homepage_LoadFourMoviesByDescendingYear()
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader();
            var loadedData = loaderUnderTest.LoadHomePageSelection(dataLocation);

            loadedData.Should().BeOfType(typeof(List<Movie>));
            loadedData.Count.Should().Be(4);
        }

        [TestCase("1982")]
        [TestCase("Hunger")]
        [TestCase("Action")]
        [TestCase("Scott")]
        [TestCase("Ford")]
        [TestCase("replicants")]
        public void SearchReturnsData(string criteria)
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader();
            var loadedData = loaderUnderTest.SearchResults(dataLocation, criteria);

            loadedData.Should().BeOfType(typeof(List<Movie>));
            loadedData.Should().NotBeEmpty();
        }
    }
}