namespace ArchivatorApp.Services.Interfaces;

public interface IConsoleWrapper
{
    void DisplayText(string text);
    void ShowCommand(string key, string command);
    (string sourcePath, string targetPath, string strategy) CommandQueue();
}