using Microsoft.Win32;
using RDDApplication.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;

namespace RDDApplication.ViewModels
{
    internal class MediaPlayerVM : ViewModelBase
    {
        public MediaPlayerVM() 
        {
            OpenFileCommand = new RelayCommand(OpenFile, () => true);
            Video = "";
            
        }
        public string Video { get; set; }
        public RelayCommand OpenFileCommand { get; }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".mp4";
            openFileDialog.Filter = "Видео файлы (.mp4, .wav)|*.mp4;*.wav";
            if(openFileDialog.ShowDialog().HasValue == true)
            {
                
                Video = openFileDialog.FileName;
                var engine = Python.CreateEngine();
                var path = engine.GetSearchPaths();
                path.Add("C:\\Users\\User\\source\\repos\\RDDApplication\\RDDApplication\\PyScript\\trackingTest.py");
                engine.SetSearchPaths(path);

                var scope = engine.CreateScope();
                scope.SetVariable("video_path", Video);

                var source = engine.CreateScriptSourceFromFile("C:\\Users\\User\\source\\repos\\RDDApplication\\RDDApplication\\PyScript\\trackingTest.py");
                var compilation = source.Compile();
                var result = compilation.Execute(scope);
                OnPropertyChanged(nameof(Video));
            }
            
        }

        public RelayCommand PauseCommand { get; set; }
        private void PauseVideo()
        {
            
        }

        
    }
}
