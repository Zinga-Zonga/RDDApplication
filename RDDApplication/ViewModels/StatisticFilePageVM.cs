using RDDApplication.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDDApplication.ViewModels
{
    internal class StatisticFilePageVM : ViewModelBase
    {
        public delegate void SelectedIndexChangedHandler(string path);
        public static event SelectedIndexChangedHandler SelectedIndexChanged;


        public StatisticFilePageVM() 
        {
            OpenOrCreateFolder();
            StatisticFiles = new ObservableCollection<ShowedFile>();
            FillObsCollection(statisticsPaths);

            SelectedIndex = -1;
        }

        private string[] statisticsPaths {  get; set; }

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
                    SelectedIndexPath = StatisticFiles[SelectedIndex].Path;
                    if (SelectedIndexChanged != null)
                    {
                        SelectedIndexChanged(SelectedIndexPath);
                    }

                }

            }
        }


        public string SelectedIndexPath { get; set; }

        public ObservableCollection<ShowedFile> StatisticFiles { get; set; }

        private void FillObsCollection(string[] videoPaths)
        {
            StatisticFiles.Clear();
            foreach (string videoFile in videoPaths)
            {
                StatisticFiles.Add(new ShowedFile(videoFile, Path.GetFileName(videoFile)));
            }
            OnPropertyChanged(nameof(StatisticFiles));
        }

        private void OpenOrCreateFolder()
        {
            if (!Directory.Exists(App.FolderOfStatistics))
            {
                Directory.CreateDirectory(App.FolderOfStatistics);
            }

            statisticsPaths = Directory.GetFiles(App.FolderOfStatistics);
        }
    }
}
