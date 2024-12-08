using System.IO.Compression;
using ArchivatorApp.Services.Interfaces;

namespace ArchivatorApp.Services.Strategies;

public abstract class BaseCompressionStrategy : ICompressionStrategy
{
    protected abstract CompressionLevel CompressionLevel { get; }

    public void Compress(string sourceFilePath, string targetFilePath, bool isFolder)
    {
        if (string.IsNullOrWhiteSpace(sourceFilePath) || string.IsNullOrWhiteSpace(targetFilePath))
            throw new ArgumentNullException(nameof(sourceFilePath), "Source or target path cannot be null or empty.");

        if (isFolder)
        {
            if (!Directory.Exists(sourceFilePath))
                throw new DirectoryNotFoundException($"The folder '{sourceFilePath}' does not exist.");

            ZipFile.CreateFromDirectory(sourceFilePath, targetFilePath, CompressionLevel, true);
        }
        else
        {
            if (!File.Exists(sourceFilePath))
                throw new FileNotFoundException($"The file '{sourceFilePath}' does not exist.");

            using (var archive = ZipFile.Open(targetFilePath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(sourceFilePath, Path.GetFileName(sourceFilePath), CompressionLevel);
            }
        }
    }
}