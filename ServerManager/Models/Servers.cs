using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Models
{
    public class Servers : INotifyPropertyChanged
    {
        private List<ServerFile> servers = new List<ServerFile>();
        public IEnumerable<ServerFile> ServerList => servers.ToArray();


        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            string comp = "";

            foreach (ServerFile server in servers)
            {
                comp += server.ToString();
                comp += ";";
            }

            return comp;
        }
    }
}
