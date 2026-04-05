using System;
using System.Collections.Generic;
using System.Text;

namespace GetQuestions
{
    public class ReadFile
    {
        public static void CheckFile(string filePath)
        {
            try
            {
                StreamReader g = new StreamReader(filePath);
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("being used by another process"))
                {
                    throw new IOException("Файл занят другим процессом.");
                }
                else
                {
                    throw new IOException("Ошибка при работе с файлом");
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Нет доступа к файлу");
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException("Непредвиденная ошибка");
            }
        }
    }
}
