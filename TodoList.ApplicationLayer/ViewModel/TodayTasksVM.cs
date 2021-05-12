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

        private ICommand showDetailCommand;
        public ICommand ShowDetailCommand
        {
            get
            {
                return showDetailCommand ?? (showDetailCommand = new RelayCommand((param) => OpenNew(param), true));
            }
        }

        private ICommand completeCommand;
        public ICommand CompleteCommand
        {
            get
            {
                return completeCommand ?? (completeCommand = new RelayCommand((param) => MarkAsCompleted(param), true));
            }
        }

        private ICommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand((param) => Remove(param), true));
            }
        }

        public TodayTasksVM()
        {
            InitializeData();
            TodayIssues = new ObservableCollection<Issue>(Issues.Where(x => x.IssueDate.Date == DateTime.Now.Date).ToList());
        }

        private void OpenNew(object param)
        {
            NewTaskView newTaskView;
            int id;
            int.TryParse(param.ToString(), out id);

            if (id > 0)
            {
                newTaskView= new NewTaskView("", Issues.FirstOrDefault(x => x.Id == id));
            }
            else
            {
                newTaskView = new NewTaskView("", null);
            }

            if (newTaskView.ShowDialog().Value)
            {
                newTaskView.Issue.Id = FileRepository.GetLastId("Issue");
                Issues.Add(newTaskView.Issue);
                FileRepository.UpdateFile<Issue>("issue", Issues.ToList());
                if (newTaskView.Issue.IssueDate.Date == DateTime.Now.Date)
                {
                    TodayIssues.Add(newTaskView.Issue);
                }
            }
        }

        private void Remove(object param)
        {
            int id;
            int.TryParse(param.ToString(), out id);

            var issue = Issues.FirstOrDefault(x => x.Id == id);

            if (issue != null)
            {
                Issues.Remove(issue);
                TodayIssues.Remove(issue);
                FileRepository.UpdateFile<Issue>("issue", Issues.ToList());
            }
        }

        private void MarkAsCompleted(object param)
        {
            int id;
            int.TryParse(param.ToString(), out id);

            var issue = Issues.FirstOrDefault(x => x.Id == id);

            if (issue != null)
            {
                var index = Issues.IndexOf(issue);
                var indexSecond = TodayIssues.IndexOf(issue);

                Issues[index].IsCompleted = true;
                TodayIssues[indexSecond].IsCompleted = true;
                FileRepository.UpdateFile<Issue>("issue", Issues.ToList());
            }
        }
    }
}
