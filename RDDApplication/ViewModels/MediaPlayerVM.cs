using Microsoft.Win32;
using RDDApplication.Utils;
using System.Diagnostics;
using System.IO;

namespace RDDApplication.ViewModels
{
    internal class MediaPlayerVM : ViewModelBase
    {
        public MediaPlayerVM()
        {
            OpenFileCommand = new RelayCommand(OpenFile, () => true);
            this.Video = App.VideoPath;
            ImagePath = "";
            
        }

        public string ImagePath { get; set; }
        private string _videoPath;

        public string Video { 
            get { return _videoPath; }
            set { _videoPath = App.VideoPath; }
        }
        public RelayCommand OpenFileCommand { get; }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".mp4";
            openFileDialog.Filter = "Видео файлы (.mp4, .wav)|*.mp4;*.wav";
            string modelPath = "DamageDetection\\MainModel.pt";
            if (openFileDialog.ShowDialog().HasValue == true)
            {
                
                string videoPath = openFileDialog.FileName;
                if(videoPath == string.Empty) {}
                else
                {
                    ShowImage();
                    

                    LaunchProgram("DamageDetection\\DamageDetection.exe",
                    $"{Path.GetFullPath(modelPath)} {videoPath}");
                    App.VideoPath = $"Results/Videos/{Path.GetFileName(videoPath)}";
                    HideImage();
                    Video = App.VideoPath;
                    
                    OnPropertyChanged(nameof(Video));
                }
                
            }
            
        }

      
        private void LaunchProgram(string filepath, string args)
        {
            
            Process p = new Process();
            
            p.StartInfo.FileName = filepath;
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.Arguments = args;
            
            p.Start();
            p.WaitForExit();
        }

        private void ShowImage()
        {
            ImagePath = "/Views/WaitPls.png";
            OnPropertyChanged(nameof(ImagePath));
        }

        private void HideImage()
        {
            ImagePath = "";
            OnPropertyChanged(nameof(ImagePath));
        }
    }
}
