﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace LearnPractice.Model
{
    public class MainModel: INotifyPropertyChanged
    {
        private string _taskName;
        public string TaskName
        {
            get => _taskName;
            set { _taskName = value; OnPropertyChanged("TaskName");}
        }

        private string _taskDescription;
        public string TaskDescription
        {
            get => _taskDescription;
            set { _taskDescription = value; OnPropertyChanged("TaskDescription"); }
        }

        private string _dateStart;
        public string DateStart
        {
            get => _dateStart;
            set { _dateStart = value; OnPropertyChanged("DateStart"); }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged("Status"); }
        }

        private DateTime? _dateFinish;
        public DateTime? DateFinish
        {
            get {
                return _dateFinish;
            }
            set { _dateFinish = value; OnPropertyChanged("DateFinish"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
