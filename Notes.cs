using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4_Notes
{
    internal class Notes
    {
        public string Name;
        public string Description;
        public DateTime Date;
        public Notes(string name, string description, DateTime date)
        {
            Name = name;
            Description = description;
            Date = date;
        }
    }
}
