using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Domain.Entity
{
    public class Reminder
    {
        public int Id { get; set; }
        public DateTime ReminderTime { get; set; }
        public bool IsReminded { get; set; }
    }
}
