using System.Windows;
using System.Windows.Threading;

namespace _2Task
{
    /*Створіть WPF програму, розмістіть у вікні TextBox і дві кнопки. 
     * При натисканні на першу кнопку в TextBox виводиться повідомлення «Підключено до бази даних», при цьому в обробнику встановіть затримку 
     * в 3-5 сек для імітації підключення до БД, також ця кнопка запускає таймер, який з періодичністю в кілька секунд виводить
     * у TextBox повідомлення «Дані отримані». При натисканні на другу кнопку за аналогією з першою відключаємось від бази (із затримкою), 
     * виводимо повідомлення та зупиняємо таймер.*/
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private bool _isConnected = false;
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
        }
        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isConnected) return;

            AppendMessage("Підключення до бази...");
            await Task.Delay(3000); // затримка 3 сек

            _isConnected = true;
            AppendMessage("Підключено до бази даних");

            _timer.Start();
        }

        private async void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isConnected) return;

            AppendMessage("Відключення від бази...");
            await Task.Delay(3000); // затримка 3 сек

            _isConnected = false;
            AppendMessage("Відключено від бази даних");

            _timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_isConnected)
            {
                AppendMessage("Дані отримані");
            }
        }

        private void AppendMessage(string message)
        {
            OutputTextBox.AppendText($"{DateTime.Now:HH:mm:ss} — {message}\n");
            OutputTextBox.ScrollToEnd();
        }
    }
}