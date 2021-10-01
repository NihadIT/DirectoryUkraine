using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryUkraine.Models
{
    public class District
    {
        public Int64 id { get; private set; }
        public Int64 region_id { get; set; }
        public string name { get; set; }
    }
}
