using LearnPractice.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPractice.Services
{
    public interface IWindowService
    {
        void OpenWindow(MainViewModel mainViewModel);

        void OpenWindowAddTask(MainViewModel mainViewModel);

        void OpenWindowInformation(MainViewModel mainViewModel);

        void ShowMessage(string message);
    }
}
