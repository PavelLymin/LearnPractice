using LearnPractice.View;
using LearnPractice.ViewModel;
using System.Linq;
using System.Windows;

namespace LearnPractice.Services
{
    public class WindowService : IWindowService
    {
        public void OpenWindow(MainViewModel mainViewModel)
        {
            var window = new NewWindow();
            window.DataContext = mainViewModel;
            mainViewModel.TaskItem = new Model.MainModel(); 
            window.Show();
        }

        public void OpenWindowAddTask(MainViewModel mainViewModel)
        {
            var windowAdd = new AddView();
            windowAdd.DataContext = mainViewModel;
            mainViewModel.TaskItem = new Model.MainModel();
            windowAdd.Show();
        }

        public void OpenWindowInformation(MainViewModel mainViewModel) 
        {
            var windowInformation = new InformationTask();
            windowInformation.DataContext = mainViewModel;
            windowInformation.Show();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
