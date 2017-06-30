using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modules
{
    public class JQGrid
    {
        public class Row
        {
            public int id { get; set; }
            public List<string> cell { get; set; }

            public Row()
            {
                cell = new List<string>();
            }
        }

        public int page { get; set; }
        public int total { get; set; }
        public int records { get; set; }
        public List<Row> rows { get; set; }

        public JQGrid()
        {
            rows = new List<Row>();
        }
    }
}