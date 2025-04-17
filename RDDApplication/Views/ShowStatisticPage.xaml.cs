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

namespace RDDApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для ShowStatisticPage.xaml
    /// </summary>
    public partial class ShowStatisticPage : UserControl
    {
        public ShowStatisticPage()
        {
            InitializeComponent();
            ViewModels.ShowStatisticFilePageVM showStatisticFilePageVM = new ViewModels.ShowStatisticFilePageVM();
            this.DataContext = showStatisticFilePageVM;
        }
    }
}
