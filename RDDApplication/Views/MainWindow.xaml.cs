using System.Windows;


namespace RDDApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModels.MainWindowVM mainWindowVM = new ViewModels.MainWindowVM();
            this.DataContext = mainWindowVM;
        }
    }
}
