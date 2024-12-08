using ArchivatorApp.Services.Interfaces;

namespace ArchivatorApp.Services.Commands;

public class ZipCommand : ICommand
{
    private string _sourcePath;
    private string _targetPath;
    private ICompressionStrategy _strategy;
    private bool _isFolder;

    public void Execute()
    {
        if (_strategy == null)
            throw new InvalidOperationException("Compression strategy not set.");
        if (string.IsNullOrWhiteSpace(_sourcePath))
            throw new InvalidOperationException("Source path not set.");
        if (string.IsNullOrWhiteSpace(_targetPath))
            throw new InvalidOperationException("Destination path not set.");

        if (_isFolder)
        {
            if (!Directory.Exists(_sourcePath))
                throw new FileNotFoundException($"The folder '{_sourcePath}' does not exist.");
        }
        else
        {
            if (!File.Exists(_sourcePath))
                throw new FileNotFoundException($"The file '{_sourcePath}' does not exist.");
        }

        _strategy.Compress(_sourcePath, _targetPath, _isFolder);
    }


    public void SetProperties(string sourcePath, string targetPath, ICompressionStrategy strategy, bool isFolder)
    {
        _sourcePath = sourcePath;
        _targetPath = targetPath;
        _strategy = strategy;
        _isFolder = isFolder;
    }
}