using RDDApplication.Data;
using System.Collections.ObjectModel;
using System.IO;



namespace RDDApplication.ViewModels
{
    internal class VideoFilePageVM : ViewModelBase
    {
        public delegate void SelectedIndexChangedHandler(string Path);
        public static event SelectedIndexChangedHandler SelectedIndexChanged;
        

        public VideoFilePageVM()
        {
            OpenOrCreateFolder();
            VideoFiles = new ObservableCollection<ShowedFile>();
            FillObsCollection(videosPaths);
            
            SelectedIndex = -1;
        }


        private string[] videosPaths { get; set; }

        private int _selectedIndex;
        public int SelectedIndex 
        {
            get { return _selectedIndex; }
            set 
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
                if (SelectedIndex >= 0)
                {
                    SelectedIndexVideoPath = VideoFiles[SelectedIndex].Path;
                    if(SelectedIndexChanged != null)
                    {
                        SelectedIndexChanged(SelectedIndexVideoPath);
                    }
                    
                }
                
            }
        }

        
        public string SelectedIndexVideoPath {  get; set; }
        public ObservableCollection<ShowedFile> VideoFiles { get; set; }

        private void FillObsCollection(string[] videoPaths)
        {
            VideoFiles.Clear();
            foreach (string videoFile in videoPaths)
            {
                VideoFiles.Add(new ShowedFile(videoFile, Path.GetFileName(videoFile)));
            }
            OnPropertyChanged(nameof(VideoFiles));
        }

        private void OpenOrCreateFolder()
        {
            if (!Directory.Exists(App.FolderOfVideos))
            {
                Directory.CreateDirectory(App.FolderOfVideos);
            }

            videosPaths = Directory.GetFiles(App.FolderOfVideos);
        }
    }
}
