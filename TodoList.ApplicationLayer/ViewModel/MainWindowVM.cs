using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TodoList.ApplicationLayer.View;
using System.Windows.Input;

namespace TodoList.ApplicationLayer.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private UserControl activeControl;
        public UserControl ActiveControl
        {
            get
            {
                return activeControl;
            }
            set
            {
                activeControl = value;
                OnPropertyChanged();
            }
        }

        private ICommand changeCommand;
        public ICommand ChangeCommand
        {
            get
            {
                return changeCommand ?? (changeCommand = new RelayCommand(param => ChangeWindow(param), true));
            }
        }

        public MainWindowVM()
        {
            activeControl = new TodayTasksView();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ChangeWindow(object window)
        {
            var windowName = window.ToString();

            switch (windowName)
            {
                case "TodayTasks":
                    ActiveControl = new TodayTasksView();
                    break;
                case "ThisWeek":
                    break;
                case "Projects":
                    break;
                case "Calendar":
                    break;
                case "Settings":
                    ActiveControl = new SettingsView();
                    break;
            }
        }
    }
}
