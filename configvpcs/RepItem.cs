using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace configvpcs
{
    public class RepItem
    {
        public int Algo { get; set; }
        public string RepName { get; set; }
        public string Legend { get; set; }
        public bool Checked { get; set; }
        public int Num{ get; set; }

        public RepItem(int num, int algo, string repname, string legend)
            {
                this.Algo = algo;
                this.RepName = repname;
                this.Legend = legend;
                this.Checked = false;
                this.Num = num;
            }
        }
  
}
