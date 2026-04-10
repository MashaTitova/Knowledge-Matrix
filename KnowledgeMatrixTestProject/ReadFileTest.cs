using GetQuestions;


public class ReadFileTests
{
    private const string NonExistentFilePath = "non_existent.txt";
    private const string LockedFilePath = "locked.txt";

    [Fact]
    public void CheckFile_NullPath_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => ReadFile.CheckFile(null)
        );
        Assert.Contains("Путь к файлу не может быть пустым", exception.Message);
    }

    [Fact]
    public void CheckFile_EmptyPath_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(
            () => ReadFile.CheckFile("")
        );
        Assert.Contains("Путь к файлу не может быть пустым", exception.Message);
    }


    [Fact]
    public void CheckFile_NonExistentFile_ThrowsFileNotFoundException()
    {
        var exception = Assert.Throws<FileNotFoundException>(
            () => ReadFile.CheckFile(NonExistentFilePath)
        );
        Assert.Contains($"Файл не найден: {NonExistentFilePath}", exception.Message);
    }

    [Fact]
    public void CheckFile_NonExistentDirectory_ThrowsDirectoryNotFoundException()
    {
        string filePath = Path.Combine("non_existent_dir", "file.txt");

        var exception = Assert.Throws<DirectoryNotFoundException>(
            () => ReadFile.CheckFile(filePath)
        );
        Assert.Contains($"Указанный путь не существует: {filePath}", exception.Message);
    }

    [Fact]
    public void CheckFile_WithLockedFile_ShouldThrowIOException()
    {
        File.WriteAllText(LockedFilePath, "locked content");
        var fileStream = File.Open(LockedFilePath, FileMode.Open, FileAccess.Read, FileShare.None);

        try
        {
            var exception = Assert.Throws<IOException>(
                () => ReadFile.CheckFile(LockedFilePath)
            );
            Assert.Contains($"Файл занят другим процессом: {LockedFilePath}", exception.Message);
        }
        finally
        {
            fileStream.Close();
            File.Delete(LockedFilePath);
        }
    }
}

    
