using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.IO;
using ServerManager.Models;

namespace ServerManager
{
    /// <summary>
    /// Interaction logic for AddServer.xaml
    /// </summary>
    public partial class AddServer : UserControl
    {
        public AddServer(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private MainWindow window;

        private void FindPathBtn_Click(object sender, RoutedEventArgs e)
        {
            string temp = "";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\tmp";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if(openFileDialog.ShowDialog() == true)
            {
                temp += openFileDialog.FileName;
            }

            PathTextBox.Text = temp;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string temp1 = NameTextBox.Text;
            string temp2 = PathTextBox.Text;
            ServerFile tempFile = new ServerFile(temp2, temp1);
            ((Servers)this.DataContext).AddServer(tempFile);
            window.StartPage();
        }

        private void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            window.StartPage();
        }
    }
}
