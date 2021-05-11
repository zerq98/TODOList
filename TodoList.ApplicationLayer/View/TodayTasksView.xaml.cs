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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoList.ApplicationLayer.ViewModel;

namespace TodoList.ApplicationLayer.View
{
    /// <summary>
    /// Interaction logic for TodayTasksView.xaml
    /// </summary>
    public partial class TodayTasksView : UserControl
    {
        public TodayTasksView()
        {
            InitializeComponent();
            this.DataContext = new TodayTasksVM();
        }
    }
}
