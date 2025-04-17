using RDDApplication.Data;
using System.IO;
using System.Text.Json;

namespace RDDApplication.ViewModels
{
    internal class ShowStatisticFilePageVM : ViewModelBase
    {
        public ShowStatisticFilePageVM()
        {
            
            ReadJSON(App.StatisticPath);
            
        }
        public string Alligator { get; set; }
        public string Edge { get; set; }
        public string Patching { get; set; }
        public string Longitudinal { get; set; }
        public string Pothole { get; set; }
        public string Transverse { get; set; }
        public string Rate { get; set; }

        private void ReadJSON(string Path)
        {
            if(App.StatisticPath  != null & File.Exists(Path))
            {
                using (FileStream fs = new FileStream(Path, FileMode.Open))
                {
                    StatisticFileJson file = JsonSerializer.Deserialize<StatisticFileJson>(fs);
                    this.Alligator = $"Сетка: {file.alligator}";
                    OnPropertyChanged(nameof(Alligator));
                    this.Edge = $"Вдоль кромок: {file.edge}";
                    OnPropertyChanged(nameof(Edge));
                    this.Patching = $"Заплатка: {file.patching}";
                    OnPropertyChanged(nameof(Patching));
                    this.Longitudinal = $"Продольная: {file.longitudinal}";
                    OnPropertyChanged(nameof(Longitudinal));
                    this.Pothole = $"Яма: {file.pothole}";
                    OnPropertyChanged(nameof(Pothole));
                    this.Transverse = $"Поперечная: {file.transverse}";
                    OnPropertyChanged(nameof(Transverse));
                    this.Rate = $"Оценка: {file.rate}";
                    OnPropertyChanged(nameof(Rate));
                }
            }
            
        }
    }
}
