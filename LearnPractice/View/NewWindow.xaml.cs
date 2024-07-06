using System.Windows;
using LearnPractice.Services;
using LearnPractice.ViewModel;

namespace LearnPractice.View
{
    /// <summary>
    /// Логика взаимодействия для NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        public NewWindow()
        {
            InitializeComponent();

            var windowService = new WindowService();
            var mainViewModel = new MainViewModel(windowService);
            DataContext = mainViewModel;

            Top = (SystemParameters.WorkArea.Height - Height) / 2 + 200;
            Left = (SystemParameters.WorkArea.Width - Width) / 2 - 340;
        }
    }
}
