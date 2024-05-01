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
    /// Логика взаимодействия для MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void PausePlayer(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Pause();
        }

        private void PlayPlayer(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Play();
        }
    }
}
