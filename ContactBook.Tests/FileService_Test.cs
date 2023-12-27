﻿
using ConsoleApp.Interfaces;
using ConsoleApp.Services;

namespace ContactBook.Tests;

public class FileService_Test
{
    [Fact]
    public void SaveToFileShould_ReturnTrue_IfFilePathExist()
    {
        // Arrange 
        IFileService fileservice = new FileService();
        string filepath = @"c:\Education\C-sharp\ConsoleAppAssignment\test.txt";
        string content = "test content";
        
        // Act 
        bool result = fileservice.SaveContentToFile(filepath, content);

        // Assert
        Assert.True(result);

    }

    [Fact]
    public void SaveToFileShould_ReturnFalse_IfFilePathDoesNotExist()
    {
        // Arrange 
        IFileService fileservice = new FileService();
        string filepath = @$"c:\{Guid.NewGuid()}\test.txt";
        string content = "test content";

        // Act 
        bool result = fileservice.SaveContentToFile(filepath, content);

        // Assert
        Assert.False(result);

    }
}
