using FluentAssertions;
using Xunit;

namespace XunitTestFixtures.Tests.TempDirectory.CustomSeedData
{
    public class CustomSeedDataTests : IClassFixture<CustomSeedDataFixture>
    {
        private readonly CustomSeedDataFixture fixture;

        public CustomSeedDataTests(CustomSeedDataFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CustomSeedDataSholdBeCopiedToTempDirectory()
        {
            this.fixture.TempDirectory.GetFiles().Length.Should().BeLessOrEqualTo(1);
            this.fixture.TempDirectory.GetFiles()[0].Name.Should().Be("TestFile.txt");
        }
    }
}