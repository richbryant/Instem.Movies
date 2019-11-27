using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

namespace Instem.Movies.Tests
{
    [TestFixture]
    public class MovieServiceTests
    {
        [Test]
        public void LoadDataFromJsonFileTest()
        {
            var dataLocation = @"DataLocation";
            var loaderUnderTest = new DataLoader();
            var loadedData = loaderUnderTest.Load(dataLocation);

            loadedData.Should().NotBeEmpty();

        }
    }
}