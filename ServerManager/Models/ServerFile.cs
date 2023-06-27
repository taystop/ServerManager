using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager
{
    public class ServerFile
    {
        //Private incremental counter for id number
        private static int counter = 0;

        //Public constructor
        public ServerFile(string path, string name)
        {
            pathName = path;
            counter++;
            id = counter;
            serverName = name;
        }

        //Private setter and public getter for Path
        private string pathName { get; set; }
        public string Path { get { return pathName; } }

        //Private setter and public getter for ID
        private int id { get; set; }
        public int ID { get { return id; } }

        //Private setter and public getter for Name
        private string serverName { get; set; }
        public string Name { get { return serverName; } }

        public override string ToString()
        {
            string serv = "";
            serv += Name;
            serv += ":";
            serv += Path;

            return serv;
        }
    }
}
