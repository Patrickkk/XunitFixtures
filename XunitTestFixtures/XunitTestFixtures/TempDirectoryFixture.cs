using System;
using System.IO;

namespace XunitTestFixtures
{
    /// <summary>
    /// Provides a temp directory for file based tests. Cleans up the created tempdirectory.
    /// </summary>
    public class TempDirectoryFixture : IDisposable
    {
        public TempDirectoryFixture()
        {
            this.GuidFolder = Guid.NewGuid().ToString();
            var path = Path.Combine(Directory.GetCurrentDirectory(), GuidFolder);
            this.TempDirectory = new DirectoryInfo(path);
            if (this.TempDirectory.Exists)
            {
                this.TempDirectory.Delete(true);
            }
            this.TempDirectory.Create();
            this.TempDirectory.Refresh();
            CopySeedData();
        }

        public string GuidFolder { get; private set; }

        public virtual DirectoryInfo SeedDataPath { get; } = null;

        public DirectoryInfo TempDirectory { get; protected set; }

        public string TempDirectoryPath { get { return this.TempDirectory.FullName; } }

        /// <summary>
        /// Copies the intitial state to the temp directory if required.
        /// </summary>
        private void CopySeedData()
        {
            if (SeedDataPath == null)
            {
                return;
            }

            SeedDataPath.CopyContent(TempDirectory);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.TempDirectory.Delete(true);
                }

                disposedValue = true;
            }
        }

        #endregion IDisposable Support
    }
}