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
using File = System.IO.File;
using System.Globalization;
using System.Windows.Markup;

namespace LearnPractice.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private IWindowService _windowService;

        public MainModel SelectedModel { get; set; }

        private MainModel _mainModelItem;
        public MainModel MainModelItem 
        {
            get => _mainModelItem;
            set 
            {
                _mainModelItem = value;
                OnPropertyChanged(nameof(MainModelItem));
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

        public ObservableCollection<MainModel> Tasks { get; set; }

        private List<string> textTask = new List<string>();

        public MainViewModel(IWindowService windowService)
        {
            _windowService = windowService;
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

            File.WriteAllText(path, text1);
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
            if (TaskItem.Status == "Завершена" || TaskItem.Status == "Выполняется" || TaskItem.Status == "Приостановлена")
                _windowService.ShowMessage($"Вы не можете создать задачу с статусом: \"{TaskItem.Status}\".");
            else
            {
                TaskItem.DateStart = DateTime.Now.ToString("dd.MM.yyyy");
                Tasks.Add(TaskItem);
                UploadingToAFile();
                TaskItem = null;
                TaskItem = new MainModel();
            }
        }

        public void RemoveTask()
        {
            if (SelectedModel != null)
            {
                Tasks.Remove(SelectedModel);
                UploadingToAFile();
            }
            else
                _windowService.ShowMessage("Выберите задачу для удаления.");
        }

        public void Save()
        {
            if (MainModelItem != null)
            {
                if (SelectedModel.Status == "Создана" && MainModelItem.Status == "Завершена"
                    || SelectedModel.Status == "Приостановлена" && MainModelItem.Status == "Завершена")
                {
                    _windowService.ShowMessage("Вы не можете изменить статус на \"Завершена\" пока задача не имеет статус \"Выполняется\"");
                }
                else
                {
                    SelectedModel.TaskName = MainModelItem.TaskName;
                    SelectedModel.TaskDescription = MainModelItem.TaskDescription;
                    SelectedModel.Status = MainModelItem.Status;
                    SelectedModel.DateFinish = MainModelItem.DateFinish;
                    SelectedModel.DateStart = MainModelItem.DateStart;
                }

                UploadingToAFile();
            }
        }

        private void OnOpenWindow()
        {
            if (SelectedModel != null)
            {
                MainModelItem = new MainModel();
                MainModelItem.TaskName = SelectedModel.TaskName;
                MainModelItem.TaskDescription = SelectedModel.TaskDescription;
                MainModelItem.Status = SelectedModel.Status;
                MainModelItem.DateFinish = SelectedModel.DateFinish;
                MainModelItem.DateStart = SelectedModel.DateStart;
                _windowService.OpenWindow(this);
            }
            else
                _windowService.ShowMessage("Выберите задачу для редактирования.");
        }

        private void OnOpenWindowAddTask() 
        {
            _windowService.OpenWindowAddTask(this);
        }

        private void OnOpenWindowInformationTask()
        {
            if (SelectedModel != null)
            {
                MainModelItem = new MainModel();
                MainModelItem.TaskName = SelectedModel.TaskName;
                MainModelItem.TaskDescription = SelectedModel.TaskDescription;
                MainModelItem.Status = SelectedModel.Status;
                MainModelItem.DateFinish = SelectedModel.DateFinish;
                MainModelItem.DateStart = SelectedModel.DateStart;
                _windowService.OpenWindowInformation(this);
            }
            else
                _windowService.ShowMessage("Выбирете задачу для просмотра информации");
        }

        private ICommand openWindowCommand;
        private ICommand addTaskWindowCommand;
        private ICommand openWindowInformationCommand;
        private ICommand addNewTaskButton;
        private ICommand removeTaskButton;
        private ICommand saveTask;
        public ICommand OpenWindowCommand => openWindowCommand ?? (openWindowCommand = new RelayCommand(OnOpenWindow));
        public ICommand AddTaskWindowCommand => addTaskWindowCommand ?? (addTaskWindowCommand = new RelayCommand(OnOpenWindowAddTask));
        public ICommand OpenWindowInformationCommand => openWindowInformationCommand ?? (openWindowInformationCommand = new RelayCommand(OnOpenWindowInformationTask));
        public ICommand AddNewTaskButton => addNewTaskButton ?? (addNewTaskButton = new RelayCommand(AddTask));
        public ICommand RemoveTaskButton => removeTaskButton ?? (removeTaskButton = new RelayCommand(RemoveTask));
        public ICommand SaveTask => saveTask ?? (saveTask = new RelayCommand(Save));

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
