using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql2Excel.Models
{
    //This class responsible for one thing - represent the place
    class Place
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Place()
        {
        }

        public Place (int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
