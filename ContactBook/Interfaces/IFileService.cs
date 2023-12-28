namespace ConsoleApp.Interfaces;

public interface IFileService
{
    /// <summary>
    /// Saves content to a specified filepath
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="content"></param>
    /// <returns>returns true if successfullly saved, else returns false</returns>
    bool SaveContentToFile (string filePath, string content);

    /// <summary>
    /// Gets content from a specified filepath
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>retruns content if sucessfull, else returns null </returns>
    string GetContentFromFile (string filePath);
}
