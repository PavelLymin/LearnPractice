using LearnPractice.Services;
using LearnPractice.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LearnPractice.View
{
    /// <summary>
    /// Логика взаимодействия для AddView.xaml
    /// </summary>
    public partial class AddView : Window
    {
        public AddView()
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
