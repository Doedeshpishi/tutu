using System;
using System.IO;

namespace tutu
{
    public static class Logger
    {
        private static string logFilePath = "app_log.txt"; // Путь к файлу логов

        public static void Log(string message)
        {
            try
            {
                // Добавляем запись в файл логов
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки записи в лог, выводим сообщение в консоль (или можно показать MessageBox)
                Console.WriteLine("Ошибка при записи в лог: " + ex.Message);
            }
        }
    }
}