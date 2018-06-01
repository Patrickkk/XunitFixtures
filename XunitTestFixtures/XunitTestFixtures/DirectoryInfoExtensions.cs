using System.IO;

namespace XunitTestFixtures
{
    public static class DirectoryInfoExtensions
    {
        public static void CopyContent(this DirectoryInfo sourceDirectory, DirectoryInfo targetDirectory)
        {
            foreach (var sourceSubDirectory in sourceDirectory.GetDirectories("*", SearchOption.AllDirectories))
            {
                var subTargetDirectory = targetDirectory.CreateSubdirectory(sourceSubDirectory.Name);
                CopyContent(sourceSubDirectory, subTargetDirectory);
            }

            foreach (var file in sourceDirectory.GetFiles("*", SearchOption.AllDirectories))
            {
                file.CopyTo(Path.Combine(targetDirectory.FullName, file.Name));
            }
        }
    }
}