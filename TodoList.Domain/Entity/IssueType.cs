using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Entity
{
    public enum IssueType
    {
        ImportantAndUrgent,
        ImportantAndNotUrgent,
        NotImportantAndUrgent,
        NotImportantAndNotUrgent
    }
}
