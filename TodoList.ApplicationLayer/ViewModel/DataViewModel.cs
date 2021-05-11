using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoList.Domain.Entity;
using TodoList.Domain.Reposiotry;

namespace TodoList.ApplicationLayer.ViewModel
{
    public class DataViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Issue> issues;
        public ObservableCollection<Issue> Issues
        {
            get
            {
                return issues;
            }
            set
            {
                issues = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Project> projects;
        public ObservableCollection<Project> Projects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
                OnPropertyChanged();
            }
        }

        private Settings settings;
        public Settings Settings
        {
            get
            {
                return settings;
            }
            set
            {
                settings = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void InitializeData()
        {
            Settings = FileRepository.ReadSettings();
            Issues = new ObservableCollection<Issue>(FileRepository.ReadFile<Issue>("issue"));
            Projects = new ObservableCollection<Project>(FileRepository.ReadFile<Project>("project"));
        }
    }
}
