using Xunit;

namespace XunitTestFixtures
{
    /// <summary>
    /// This collection must be in the same assembly as the tests itself, its not possible to share it.
    /// https://xunit.github.io/docs/shared-context
    /// Important note: Fixtures can be shared across assemblies, but collection definitions must be in the same assembly as the test that uses them.
    /// </summary>
    [CollectionDefinition(nameof(TempDirectoryFixtureCollection))]
    public class TempDirectoryFixtureCollection : ICollectionFixture<TempDirectoryFixture>
    {
    }
}