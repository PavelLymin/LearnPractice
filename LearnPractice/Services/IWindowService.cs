using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnPractice.Services
{
    public interface IWindowService
    {
        void OpenWindow();

        void CloseWindow();

        void ShowMessage(string message);
    }
}
