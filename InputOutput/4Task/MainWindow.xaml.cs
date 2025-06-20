using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;

namespace _4Task
{
    /// <summary>
    /// Створіть програму WPF Application, яка дозволяє користувачам зберігати дані в ізольованому сховищі.
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string FileName = "4Task.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Create, isoStore))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(InputTextBox.Text);
                }
            }

            StatusTextBlock.Text = "Дані збережено!";
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            using (IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (isoStore.FileExists(FileName))
                {
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Open, isoStore))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        InputTextBox.Text = reader.ReadToEnd();
                    }

                    StatusTextBlock.Text = "Дані зчитано.";
                }
                else
                {
                    StatusTextBlock.Text = "Дані не знайдені.";
                }
            }
        }
    }
}