using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.IO;
using Microsoft.Win32;
using ServerManager.Models;

namespace ServerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Public constructor
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            var data = new Servers();
            this.DataContext = data;
            this.Content = new ServerList();
        }

        //Handles the main window closing
        public void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if(MessageBox.Show("Would you like to save the Server List?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (sv.ShowDialog() == true)
                {
                    File.WriteAllText(sv.FileName, this.DataContext.ToString());
                }
            }
        }
    }
}
