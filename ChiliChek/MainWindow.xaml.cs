using System.Diagnostics; // Для Trace и Process
using System.IO; // Добавлено для Path и File
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace ChiliChek
{
    public partial class MainWindow : Window
    {
        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        private static extern int Everything_SetSearchW(string lpSearchString);

        [DllImport("Everything.dll")]
        private static extern void Everything_QueryW(bool bWait);

        [DllImport("Everything.dll")]
        private static extern int Everything_GetNumResults();

        [DllImport("Everything.dll", CharSet = CharSet.Unicode)]
        private static extern bool Everything_GetResultFullPathNameW(int nIndex, StringBuilder lpString, uint nMaxCount);

        public MainWindow()
        {
            InitializeComponent();
            var listener = new TextWriterTraceListener(System.Console.Out);
            Trace.Listeners.Add(listener);
            Trace.WriteLine("Запуск инициализации...");
            ChiliChek.Database.Database.Initialize();
            Trace.WriteLine("Инициализация завершена.");
        }

        private void EverythingButton_Click(object sender, RoutedEventArgs e)
        {
            Everything_SetSearchW("*"); // Поиск всех файлов
            Everything_QueryW(true);
            int numResults = Everything_GetNumResults();
            StringBuilder sb = new StringBuilder(260);
            string results = "";
            for (int i = 0; i < numResults; i++)
            {
                if (Everything_GetResultFullPathNameW(i, sb, 260))
                {
                    results += sb.ToString() + "\n";
                }
            }
            OutputTextBox.Text = results.Length > 0 ? results : "Нет результатов.";
        }

        // Оставшиеся методы
        private void JournalTraceButton_Click(object sender, RoutedEventArgs e)
        {
            RunUtility("Tools\\JournalTrace.exe");
        }

        private void ShellBagAnalyzerButton_Click(object sender, RoutedEventArgs e)
        {
            RunUtility("Tools\\shellbag_analyzer_cleaner.exe");
        }

        private void ExecutedProgramsListButton_Click(object sender, RoutedEventArgs e)
        {
            RunUtility("Tools\\ExecutedProgramsList.exe");
        }

        private void RegScannerButton_Click(object sender, RoutedEventArgs e)
        {
            RunUtility("Tools\\RegScanner.exe");
        }

        private void USBDeviewButton_Click(object sender, RoutedEventArgs e)
        {
            RunUtility("Tools\\USBDeview.exe");
        }

        private void RunUtility(string exeName)
        {
            try
            {
                string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, exeName);
                if (File.Exists(exePath))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = exePath;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    OutputTextBox.Text = output;
                    if (string.IsNullOrEmpty(output))
                    {
                        OutputTextBox.Text = $"Утилита {Path.GetFileNameWithoutExtension(exeName)} не вернула вывод.";
                    }
                }
                else
                {
                    OutputTextBox.Text = $"Файл {exeName} не найден в {Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory)}";
                }
            }
            catch (Exception ex)
            {
                OutputTextBox.Text = $"Ошибка при запуске {Path.GetFileNameWithoutExtension(exeName)}: {ex.Message}";
            }
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Информация о приложении.";
        }

        private void AppsButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Список приложений.";
        }

        private void LibraryButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Библиотека программ.";
        }

        private void BrowserCheckButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Проверка браузера.";
        }

        private void SteamCheckButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Проверка Steam.";
        }

        private void SystemButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Информация о системе.";
        }

        private void SupportButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Поддержка.";
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Настройки.";
        }

        private void WhatsNewButton_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Text = "Новые функции будут добавлены позже!";
        }
    }
}