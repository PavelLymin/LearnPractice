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
            DataContext = new MainViewModel(windowService);

            Top = (SystemParameters.WorkArea.Height - Height) / 2 + 50;
            Left = (SystemParameters.WorkArea.Width - Width) / 2 + 120;
        }
    }
}
