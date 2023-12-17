namespace ConsoleApp.Interfaces;

internal interface IFileService
{
    bool SaveContentToFile (string filePath, string content);
    string GetContentFromFile (string filePath);
}
