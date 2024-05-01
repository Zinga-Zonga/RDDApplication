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
            MediaPlayerVM = new MediaPlayerVM();
            SelectedViewModel = MediaPlayerVM;
            MediaPlayerVMCommand = new RelayCommand(SetMediaPlayerVM, () => true);
        }
        public object SelectedViewModel { get; set; }
        public MediaPlayerVM MediaPlayerVM { get; set; }
        public RelayCommand MediaPlayerVMCommand { get; set; }
        public void SetMediaPlayerVM()
        {
            SelectedViewModel = MediaPlayerVM;
        }
    }
}
