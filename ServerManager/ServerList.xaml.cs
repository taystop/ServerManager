using ServerManager.Models;
using System;
using System.Collections.Generic;
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

namespace ServerManager
{
    /// <summary>
    /// Interaction logic for ServerList.xaml
    /// </summary>
    public partial class ServerList : UserControl
    {
        //Default Constructor
        public ServerList()
        {
            InitializeComponent();
            this.servers = (List<ServerFile>)this.DataContext;
            if(servers != null)
            {
                setIds();
                setNames();
                setPaths();
            }
            else
            {
                loadServerFiles();
            }
        }

        //Private variable holding all server data
        private List<ServerFile> servers;

        //Adds all server ids to the ID listbox
        private void setIds()
        {
            for(int i = 0; i < servers.Count; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = servers[i].ID;
                IDList.Items.Add(item);
            }
        }

        //Adds all server names to the Name listbox
        private void setNames()
        {
            for(int i =0; i < servers.Count;i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = servers[i].Name;
                NameList.Items.Add(item);
            }
        }

        //Adds all server paths to the Path listbox
        private void setPaths()
        {
            for(int i = 0; i < servers.Count;i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = servers[i].Path;
                PathList.Items.Add(item);
            }
        }

        private void loadServerFiles()
        {
            string temp = "";
            
            if(MessageBox.Show("Would you like to load Server List?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == true)
                {
                    temp = File.ReadAllText(ofd.FileName);
                }

                if (!temp.Equals(""))
                {
                    string[] sep = temp.Split(';');
                    foreach (string s in sep)
                    {
                        string[] serv = s.Split(":");
                        ServerFile file = new ServerFile(serv[1], serv[0]);
                        this.servers.Add(file);
                    }
                }
            }
        }
    }
}
