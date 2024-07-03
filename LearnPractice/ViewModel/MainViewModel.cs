using LearnPractice.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LearnPractice.Services;

namespace LearnPractice.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<MainModel> Tasks { get; set; }

        private List<string> textTask = new List<string>();

        private MainModel selectedModel;
        public MainModel SelectedModel
        {
            get => selectedModel; 
            
            set
            {
                selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));
            }
        }

        private MainModel _taskItem;
        public MainModel TaskItem
        {
            get => _taskItem;
            set
            {
                _taskItem = value;
                OnPropertyChanged(nameof(TaskItem));
            }
        }

        public MainViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            OpenWindowCommand = new RelayCommand(() => OnOpenWindow());
            CloseWindowCommand = new RelayCommand(() => OnCloseWindow());
            Tasks = new ObservableCollection<MainModel>();
            TaskItem = new MainModel();
            ListTasks();
        }

        public List<string> ReadText()
        {
            string path1 = "Task.txt";
            var srcEncoding = Encoding.GetEncoding("UTF-8");
            using (StreamReader reader = new StreamReader(path1, encoding: srcEncoding))
            {
                textTask.Add(reader.ReadToEnd());
            }
            return textTask;
        }

        public void UploadingToAFile()
        {
            string path = "Task.txt";
            string text1 = "";

            foreach (var task in Tasks)
            {
                text1 += $"{task.TaskName}\n";
                text1 += $"{task.TaskDescription}\n";
                text1 += $"{task.DateStart}\n";
                text1 += $"{task.Status}\n";
                text1 += $"{task.DateFinish}\n";
            }

            File.WriteAllText(path, text1.Trim());
        }

        public void ListTasks()
        {
            int index = 0;
            for (int i = 0; i < ReadText()[0].Split('\n').Length / 5; i++)
            {
                MainModel taskItem = new MainModel
                {
                    TaskName = ReadText()[0].Split('\n')[index++],
                    TaskDescription = ReadText()[0].Split('\n')[index++],
                    DateStart = ReadText()[0].Split('\n')[index++],
                    Status = ReadText()[0].Split('\n')[index++],
                    DateFinish = ReadText()[0].Split('\n')[index++],
                };
                Tasks.Add(taskItem);
            }
        }

        public void AddTask()
        {
            if (TaskItem.Status == "Завершена")
                _windowService.ShowMessage("Not");
            else
            {
                TaskItem.DateStart = DateTime.Now.ToString();
                Tasks.Add(TaskItem);
                TaskItem = new MainModel();
                UploadingToAFile();
            }
        }

        public void RemoveTask()
        {
            if (SelectedModel != null)
            {
                Tasks.Remove(SelectedModel);
            }
            UploadingToAFile();
        }

        public void Save()
        {
            if (SelectedModel != null)
            {
                OnPropertyChanged(nameof(SelectedModel));
            }
        }

        private IWindowService _windowService;
        public ICommand OpenWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        private void OnOpenWindow()
        {
            _windowService.OpenWindow();
        }

        private void OnCloseWindow()
        {
            _windowService.CloseWindow();
        }

        private ICommand addNewTaskButton;
        public ICommand AddNewTaskButton => addNewTaskButton ?? (addNewTaskButton = new RelayCommand(AddTask));

        private ICommand removeTaskButton;
        public ICommand RemoveTaskButton => removeTaskButton ?? (removeTaskButton = new RelayCommand(RemoveTask));

        private ICommand saveTask;
        public ICommand SaveTask => saveTask ?? (saveTask = new RelayCommand(Save));

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
