using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

namespace AsyncAwaitBlog1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Text = "";
            var content = await AccessTheWebAsync();
            resultsTextBox.Text = content;

        }

        public async Task<string> AccessTheWebAsync()
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("http://msdn.microsoft.com");
            return content;
        }

        private void SyncButton_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Text = "";
            var content = AccessTheWeb();
            resultsTextBox.Text = content;
        }

        public string AccessTheWeb()
        {
            var httpClient = new WebClient();
            var content = httpClient.DownloadString("http://msdn.microsoft.com");
            return content;
        }
    }
}
