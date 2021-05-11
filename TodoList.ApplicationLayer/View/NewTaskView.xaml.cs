using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TodoList.ApplicationLayer.ViewModel;
using TodoList.Domain.Entity;

namespace TodoList.ApplicationLayer.View
{
    public partial class NewTaskView : Window
    {
        public Issue issue;

        public NewTaskView(string projectName)
        {
            InitializeComponent();
            this.DataContext = new NewTaskVM(issue, projectName, this);
        }
    }
}
