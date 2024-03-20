using CheckClonesApp.Services;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CheckClonesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FileService _fileService = new();
        public string SourceFolderPath { get; set; }
        public string DirectionFolderPath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SourceOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            SourceFolderPath = _fileService.GetFolderPath();
            SourceBox.Text = SourceFolderPath;
        }

        private void DirectionOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            DirectionFolderPath = _fileService.GetFolderPath();
            DirectionBox.Text = DirectionFolderPath;
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SourceFolderPath != null && DirectionFolderPath != null) 
            {
                ResultBox.Text = "Processing....";
                var result = Task.Factory.StartNew(() => { return _fileService.CheckClones(SourceFolderPath); }).
                    GetAwaiter().GetResult();
                ResultBox.Text = Task.Factory.StartNew(() => { return _fileService.MoveFiles(result, DirectionFolderPath);
                }).GetAwaiter().GetResult();
            }
        }
    }
}