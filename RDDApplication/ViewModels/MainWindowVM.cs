using RDDApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDDApplication.ViewModels
{
    internal class MainWindowVM : ViewModelBase
    {
        public MainWindowVM() 
        {
            if (SelectedViewModel == null)
            {
                MediaPlayerVM = new MediaPlayerVM();
                SelectedViewModel = MediaPlayerVM;
            }

            VideoFilePageViewModel = new VideoFilePageVM();
            StatisticFilePageVM = new StatisticFilePageVM();
            ShowStatisticFilePageVM = new ShowStatisticFilePageVM();

            MediaPlayerVMCommand = new RelayCommand(SetMediaPlayerVM, () => true);
            VideoFilePageVMCommand = new RelayCommand(SetVideoFilePageVM, () => true);
            StatisticFilePageVMCommand = new RelayCommand(SetStatisticFilePageVM, () => true);

            VideoFilePageVM.SelectedIndexChanged += SetMediaPlayerVM;
            VideoFilePageVM.SelectedIndexChanged += SetSourcePathToMediaPlayerVM;

            StatisticFilePageVM.SelectedIndexChanged += SetShowStatisticFilePageVM;
            StatisticFilePageVM.SelectedIndexChanged += SetSourcePathToStatisticFilePageVM;
            
            

        }

       

        public object SelectedViewModel { get; set; }
        public MediaPlayerVM MediaPlayerVM { get; set; }
        public RelayCommand MediaPlayerVMCommand { get; set; }

        public void SetSourcePathToMediaPlayerVM(string Path)
        {
            App.VideoPath = Path;
        }


        public void SetMediaPlayerVM()
        {
            SelectedViewModel = MediaPlayerVM;
            OnPropertyChanged("SelectedViewModel");
        }


        public void SetMediaPlayerVM(string Path)
        {
            SelectedViewModel = MediaPlayerVM;
            OnPropertyChanged(nameof(SelectedViewModel));
        }

        

        public VideoFilePageVM VideoFilePageViewModel { get; set; }
        public RelayCommand VideoFilePageVMCommand { get; set;}
        public void SetVideoFilePageVM()
        {
            SelectedViewModel = VideoFilePageViewModel;
            OnPropertyChanged("SelectedViewModel");
        }

        #region Страница с файлами статистики
        public StatisticFilePageVM StatisticFilePageVM { get; set;}
        public RelayCommand StatisticFilePageVMCommand { get; set; }

        public void SetStatisticFilePageVM(string Path)
        {
            SelectedViewModel = StatisticFilePageVM;
            OnPropertyChanged("SelectedViewModel");
        }
        public void SetStatisticFilePageVM()
        {
            SelectedViewModel = StatisticFilePageVM;
            OnPropertyChanged("SelectedViewModel");
        }
        public void SetSourcePathToStatisticFilePageVM(string Path)
        {
            App.StatisticPath = Path;
        }
        #endregion
        #region Страница показа статистики из файла
        public ShowStatisticFilePageVM ShowStatisticFilePageVM { get; set;}
        public RelayCommand ShowStatisticFilePageVMCommand { get; set; }

        public void SetShowStatisticFilePageVM(string Path)
        {
            SelectedViewModel = ShowStatisticFilePageVM;
            OnPropertyChanged("SelectedViewModel");
        }
        public void SetShowStatisticFilePageVM()
        {
            SelectedViewModel = ShowStatisticFilePageVM;
            OnPropertyChanged("SelectedViewModel");
        }
        

        #endregion
    }
}
