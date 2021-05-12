using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.ApplicationLayer.View;
using TodoList.Domain.Entity;

namespace TodoList.ApplicationLayer.ViewModel
{
    public class NewTaskVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Issue issue;
        public Issue Issue
        {
            get
            {
                return issue;
            }
            set
            {
                issue = value;
                OnPropertyChanged();
            }
        }

        private string actionText;
        public string ActionText
        {
            get
            {
                return actionText;
            }
            set
            {
                actionText = value;
                OnPropertyChanged();
            }
        }

        private NewTaskView _view;

        public NewTaskVM(Issue issue,string projectName,NewTaskView view)
        {
            _view = view;
            _view.PriorityCB.ItemsSource = Enum.GetValues(typeof(IssueTypeEnum));

            if (issue != null)
            {
                Issue = issue;
                ActionText = "Update";
            }
            else
            {
                Issue = new Issue
                {
                    Id = 0,
                    Title = "",
                    Description = "",
                    IssueDate = DateTime.Now,
                    IssueType = IssueTypeEnum.NotImportantAndUrgent,
                    Localization = "",
                    People = new ObservableCollection<string>(),
                    ProjectName = projectName
                };
                ActionText = "Create";
            }
        }

        private ICommand buttonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return buttonCommand ?? (buttonCommand = new RelayCommand((param) => Execute(param), true));
            }
        }

        private void Execute(object param)
        {
            switch (param.ToString())
            {
                case "Confirm":
                    _view.Issue = Issue;
                    _view.DialogResult = true;
                    _view.Close();
                    break;
                case "Cancel":
                    _view.DialogResult = false;
                    break;
                case "Add":
                    break;
            }
        }
    }
}
