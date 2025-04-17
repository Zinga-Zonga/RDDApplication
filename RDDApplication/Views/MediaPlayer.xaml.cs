using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace RDDApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : UserControl
    {
        private TimeSpan TotalTime;
        private DispatcherTimer Timer;
        public MediaPlayer()
        {
            ViewModels.MediaPlayerVM vm = new ViewModels.MediaPlayerVM();
            this.DataContext = vm;
            
            InitializeComponent();
            VideoSlider.AddHandler(MouseLeftButtonUpEvent,
                      new MouseButtonEventHandler(VideoSlider_MouseLeftButtonUp),
                      true);
            VideoSlider.AddHandler(MouseLeftButtonDownEvent,
                      new MouseButtonEventHandler(VideoSlider_MouseLeftButtonDown),
                      true);
            
        }
        

        private void PausePlayer(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Pause();
        }

        private void PlayPlayer(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Play();
        }

        private void VideoPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {

            if (VideoPlayer.NaturalDuration.HasTimeSpan)
            {
                TotalTime = VideoPlayer.NaturalDuration.TimeSpan;

                VideoSlider.Maximum = 1;
                Timer = new DispatcherTimer();
                Timer.Interval = TimeSpan.FromSeconds(1);
                Timer.Tick += new EventHandler(Timer_Tick);
                Timer.Start();
            }
            
        }


        void Timer_Tick(object sender, EventArgs e)
        {
            if (VideoPlayer.NaturalDuration.HasTimeSpan)
            {
                if (VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds > 0)
                {
                    if (TotalTime.TotalSeconds > 0)
                    {
                        VideoSlider.Value = VideoPlayer.Position.TotalSeconds / TotalTime.TotalSeconds;
                    }
                }
            }
            
        }

        private void VideoSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (TotalTime.TotalSeconds > 0)
            {
                VideoPlayer.Position = TimeSpan.FromSeconds(VideoSlider.Value * TotalTime.TotalSeconds);
            }
        }
        private void VideoSlider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            VideoPlayer.Pause();
        }

        private void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }

    }
}
