using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.IO;

namespace ChiliChek
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                if (OutputTextBox == null)
                {
                    Trace.WriteLine("OutputTextBox is null!");
                }
                else
                {
                    Trace.WriteLine("OutputTextBox initialized successfully.");
                }
                var listener = new TextWriterTraceListener(Console.Out);
                Trace.Listeners.Add(listener);
                Trace.WriteLine("Запуск инициализации...");
                ChiliChek.Database.Database.Initialize();
                Trace.WriteLine("Инициализация завершена.");
                DataContext = new UI.ViewModels.MainViewModel();
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"InitializeComponent failed: {ex.Message}");
                File.AppendAllText("errors.log", $"[MainWindow Init] {ex.Message}\n");
            }
        }

        private void WhatsNewButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is UI.ViewModels.MainViewModel vm)
            {
                vm.Threats.Add(new Models.Threat
                {
                    Type = "Info",
                    Description = "Новое",
                    Details = "Новые функции будут добавлены позже!",
                    Timestamp = DateTime.Now
                });
            }
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Trace.WriteLine($"Image load failed: {e.ErrorException.Message}");
            File.AppendAllText("errors.log", $"[Image Load] {e.ErrorException.Message}\n");
            if (DataContext is UI.ViewModels.MainViewModel vm)
            {
                vm.Threats.Add(new Models.Threat
                {
                    Type = "Error",
                    Description = "Image Load",
                    Details = $"Ошибка загрузки изображения: {e.ErrorException.Message}",
                    Timestamp = DateTime.Now
                });
            }
        }
    }
}