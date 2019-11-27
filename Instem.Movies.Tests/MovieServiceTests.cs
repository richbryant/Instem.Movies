using NUnit.Framework;
using FluentAssertions;
using Instem.Movies.Data;

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

            loadedData.Should().NotBeEmpty();

        }

        [Test]
        public void Homepage_LoadFourMoviesByDescendingYear()
        {
            var dataLocation = @"TestData\moviedata.json";
            var loaderUnderTest = new DataLoader();
            var loadedData = loaderUnderTest.LoadHomePageSelection(dataLocation);

            loadedData.Count.Should().Be(4);
        }
    }
}