using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql2Excel.Models
{
    //This class responsible for one thing - represent the server
    class Server
    {
        public string SysName { get; set; }
        public string Name { get; set; }

        public Server()
        {
        }

        public Server (string SysName, string Name)
        {
            this.SysName = SysName;
            this.Name = Name;
        }
    }
}
