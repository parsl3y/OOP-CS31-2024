namespace ArchivatorApp.Services.Interfaces;

public interface ICompressionStrategy
{
    public void Compress(string sourceFilePath, string targetFilePath, bool isFolder);
}