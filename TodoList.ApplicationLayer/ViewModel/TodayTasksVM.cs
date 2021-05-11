using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.ApplicationLayer.View;
using TodoList.Domain.Entity;
using TodoList.Domain.Reposiotry;

namespace TodoList.ApplicationLayer.ViewModel
{
    public class TodayTasksVM : DataViewModel
    {
        private ObservableCollection<Issue> todayIssues;
        public ObservableCollection<Issue> TodayIssues
        {
            get
            {
                return todayIssues;
            }
            set
            {
                todayIssues = value;
                OnPropertyChanged();
            }
        }

        private ICommand openNewCommand;
        public ICommand OpenNewCommand
        {
            get
            {
                return openNewCommand ?? (openNewCommand = new RelayCommand((param)=>OpenNew(param), true));
            }
        }

        public TodayTasksVM()
        {
            InitializeData();
            TodayIssues = new ObservableCollection<Issue>(Issues.Where(x => x.IssueDate.Date == DateTime.Now.Date).ToList());
        }

        private void OpenNew(object param)
        {
            NewTaskView newTaskView = new NewTaskView("");
            newTaskView.issue = null;

            if (newTaskView.ShowDialog().Value)
            {
                newTaskView.issue.Id = FileRepository.GetLastId("Issue");
                Issues.Add(newTaskView.issue);
                FileRepository.UpdateFile<Issue>("issue", Issues.ToList());
                if (newTaskView.issue.IssueDate.Date == DateTime.Now.Date)
                {
                    TodayIssues.Add(newTaskView.issue);
                }
            }
        }
    }
}
