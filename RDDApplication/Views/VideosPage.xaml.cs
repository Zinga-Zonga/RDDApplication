using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RDDApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для VideosPage.xaml
    /// </summary>
    public partial class VideosPage : UserControl
    {
        public VideosPage()
        {
            InitializeComponent();
            ViewModels.VideoFilePageVM videoFilePageVM = new ViewModels.VideoFilePageVM();
            this.DataContext = videoFilePageVM;
        }

        private void VideoPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = sender as MediaElement;
            mediaElement.ScrubbingEnabled = true;
            mediaElement.Position += TimeSpan.FromSeconds(1);
            mediaElement.Play();
            mediaElement.Stop();
        }

        
    }
}
