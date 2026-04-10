using System;
using System.Collections.Generic;
using System.Text;

namespace GetQuestions
{
    public class ReadFile
    {
        public static void CheckFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Путь к файлу не может быть пустым");

            try
            {
                using StreamReader g = new StreamReader(filePath);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Файл не найден: " + filePath);
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Указанный путь не существует: " + filePath);
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("being used by another process"))
                {
                    throw new IOException("Файл занят другим процессом: " + filePath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Нет доступа к файлу: " + filePath);
            }
            catch (ArgumentException)
            {
                throw; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Непредвиденная ошибка при проверке файла {filePath}: {ex.Message}", ex);
            }
        }
    }
}
