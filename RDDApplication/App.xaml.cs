using RDDApplication.ViewModels;
using System.Windows;

namespace RDDApplication
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string VideoPath {  get; set; }
        public static string StatisticPath {  get; set; }
        public static string FolderOfVideos = "Results/Videos/";
        public static string FolderOfStatistics = "Results/Statistic/";
    }
}
