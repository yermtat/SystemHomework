using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using taskHomework.Services;


namespace taskHomework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ReportService _reportService = new();
        public string Result { get; set; }
        public string Source { get; set; }
        public string FullReport { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void WordsCountBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = await _reportService.WordsCount(SourceTextBox.Text);
            ReportIsReady();
        }


        private async void SentenceCountBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = await _reportService.SentenceCount(SourceTextBox.Text);
            ReportIsReady();
        }

        private async void SymbolsCountBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = await _reportService.SymbolsCount(SourceTextBox.Text);
            ReportIsReady();
        }


        private async void QuestionsCountBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = await _reportService.QuestionsCount(SourceTextBox.Text);
            ReportIsReady();
        }


        private async void ExclamationCountBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = await _reportService.ExclamationCount(SourceTextBox.Text);
            ReportIsReady();
        }

        private async void FullReportBtn_Click(object sender, RoutedEventArgs e)
        {

            Result = await _reportService.FullReport(SourceTextBox.Text);
            ReportIsReady();
        }

        private void ReportIsReady()
        {
            ResultTextBlock.Text = "Your report is ready. Click the \"show\" or \"save\" button";
        }

        private void ShowOnScreenBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBlock.Text = Result;
        }

        private void SaveToFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Result = "Source: " + SourceTextBox.Text + "\n\n" + Result;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Report";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt"; 

            if (dlg.ShowDialog() == true)
            {
                using FileStream str = new(dlg.FileName, FileMode.Create);
                using StreamWriter strwriter = new StreamWriter(str);

                strwriter.WriteAsync(Result);
            }
        }
    }
}

// thread.suspend