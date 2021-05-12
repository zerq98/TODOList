using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Entity
{
    public class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public bool IsCompleted { get; set; }
        public IssueTypeEnum IssueType { get; set; }
        public DateTime IssueDate { get; set; }
        public string Localization { get; set; }
        public ObservableCollection<string> People { get; set; }
    }
}
