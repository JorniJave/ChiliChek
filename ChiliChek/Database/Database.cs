using Microsoft.Data.Sqlite;
using System.IO;
using System.Diagnostics; // Для Trace
using SQLitePCL; // Для Batteries.Init

namespace ChiliChek.Database
{
    public static class Database
    {
        public static void Initialize()
        {
            Trace.WriteLine("Начало инициализации базы данных...");
            try
            {
                string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
                Trace.WriteLine($"Путь к папке: {dataFolder}");
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                    Trace.WriteLine($"Папка создана: {dataFolder}");
                }
                string dbPath = Path.Combine(dataFolder, "chili_chek.db");
                Trace.WriteLine($"Путь к БД: {dbPath}");

                // Инициализация SQLitePCL
                Batteries.Init();
                Trace.WriteLine("Провайдер SQLitePCL инициализирован.");

                using var conn = new SqliteConnection($"Data Source={dbPath}");
                Trace.WriteLine("Подключение создано, попытка открытия...");
                conn.Open();
                Trace.WriteLine("Подключение к БД открыто.");
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS threats (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        type TEXT,
                        description TEXT,
                        details TEXT,
                        timestamp DATETIME,
                        steam_id TEXT
                    );
                    CREATE TABLE IF NOT EXISTS steam (
                        steam_id TEXT PRIMARY KEY,
                        name TEXT,
                        profile_status TEXT,
                        vac_bans TEXT
                    );
                    CREATE TABLE IF NOT EXISTS logs (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        message TEXT,
                        timestamp DATETIME
                    );
                ";
                Trace.WriteLine("Выполнение команды создания таблиц...");
                cmd.ExecuteNonQuery();
                Trace.WriteLine("Таблицы созданы.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Ошибка: {ex.Message}");
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errors.log");
                File.AppendAllText(logPath, $"[Database Init] {ex.Message}\n");
                Trace.WriteLine($"Лог записан в: {logPath}");
            }
            Trace.WriteLine("Инициализация завершена.");
        }
    }
}