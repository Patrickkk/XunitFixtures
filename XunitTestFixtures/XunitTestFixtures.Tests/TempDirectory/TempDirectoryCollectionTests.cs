using System.IO;
using Xunit;

namespace XunitTestFixtures.Tests.TempDirectory
{
    [Collection(nameof(TempDirectoryFixtureCollection))]
    public class TempDirectoryCollectionTests
    {
        private readonly TempDirectoryFixture tempDirectoryFixture;

        public TempDirectoryCollectionTests(TempDirectoryFixture tempDirectoryFixture)
        {
            this.tempDirectoryFixture = tempDirectoryFixture;
        }

        [Fact]
        public void TempDirectoryShouldExsist()
        {
            var x = new DirectoryInfo("TempDirectory/CustomSeedData/SeedData");
            var y = x.FullName;
            Assert.True(tempDirectoryFixture.TempDirectory.Exists);
        }
    }
}