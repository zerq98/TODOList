using System;
using System.Collections.Generic;
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
        public Location Location { get; set; }
        public IssueType IssueType { get; set; }
        public Reminder Reminder { get; set; }
        public List<AddonPerson> AddonPeople { get; set; }
    }
}
