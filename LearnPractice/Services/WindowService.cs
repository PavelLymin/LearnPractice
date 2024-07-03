﻿using LearnPractice.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LearnPractice.Services
{
    public class WindowService: IWindowService
    {
        public void OpenWindow()
        {
            var window = new NewWindow();

            window.Show();
        }

        public void CloseWindow()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

            if (window != null)
            {
                window.Close();
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
