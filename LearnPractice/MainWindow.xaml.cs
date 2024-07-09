using LearnPractice.ViewModel;
using System.Windows;
using LearnPractice.Services;

namespace LearnPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var windowService = new WindowService();
            DataContext = new MainViewModel(windowService);
            //MainViewModel принимает в качестве параметра объект класса WindowService,
            //который реализует интерфейс IWindowService для многослойнности системы.
        }
    }
}
