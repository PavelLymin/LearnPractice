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


        }
    }
}
