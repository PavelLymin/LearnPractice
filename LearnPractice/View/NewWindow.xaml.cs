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
            Top = (SystemParameters.WorkArea.Height - Height) / 2 + 115;
            Left = (SystemParameters.WorkArea.Width - Width) / 2 - 270;
        }
    }
}
