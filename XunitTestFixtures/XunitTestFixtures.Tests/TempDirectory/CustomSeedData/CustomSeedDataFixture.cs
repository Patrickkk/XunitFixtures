using System.IO;

namespace XunitTestFixtures.Tests.TempDirectory.CustomSeedData
{
    public class CustomSeedDataFixture : TempDirectoryFixture
    {
        public override DirectoryInfo SeedDataPath { get { return new DirectoryInfo("TempDirectory/CustomSeedData/SeedData"); } }
    }
}