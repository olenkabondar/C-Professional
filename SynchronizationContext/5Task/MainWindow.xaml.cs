using System.Windows;

namespace _5Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    /*Створіть програму за шаблоном WPF Application. Перемістіть з елементів керування (ToolBox) на форму текстове поле та кнопку. 
     Створіть асинхронний обробник події після натискання на кнопку.
     Створіть метод Addition, який приймає два параметри та повертає результат їх додаванням. З асинхронного обробника події викличте цей метод через Task.Run. 
     На повертаному значенні методу Run викличте метод ConfigureAwait із зазначенням параметра false. 
     Застосуйте оператор await до цього виразу і прийміть результат роботи задачі в цілісну змінну. Її значення виведіть у текстове поле.
     Подивіться результати роботи.*/
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int result = await Task.Run(() => Addition(3, 7)).ConfigureAwait(false);

                // Повернення в потік вручну
                await Dispatcher.InvokeAsync(() =>
                {
                    txtResult.Text = $"Result: {result}";
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private int Addition(int a, int b)
        {
            return a * b;
        }
    }
}