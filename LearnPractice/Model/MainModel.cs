using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LearnPractice.Model
{
    public class MainModel: INotifyPropertyChanged
    {
        private string _taskName;

        public string TaskName
        {
            get
            {
                return _taskName;
            }
            set
            {
                _taskName = value;
                OnPropertyChanged("TaskName");
            }
        }

        private string _taskDescription;

        public string TaskDescription
        {
            get
            {
                return _taskDescription;
            }
            set
            {
                _taskDescription = value;
                OnPropertyChanged("TaskDescription");
            }
        }

        private string _dateStart;

        public string DateStart
        {
            get
            {
                return _dateStart;
            }
            set
            {
                _dateStart = value;
                OnPropertyChanged("DateStart");
            }
        }

        private string _status;

        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private string _dateFinish;

        public string DateFinish
        {
            get
            {
                return _dateFinish;
            }
            set
            {
                _dateFinish = value;
                OnPropertyChanged("DateFinish");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
