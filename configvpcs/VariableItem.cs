using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace configvpcs
{
    class VariableItem
    {
        public string Section{ get; set; }
        public string Variable { get; set; }
        public string Valeur{ get; set; }
        public int    Numdir{ get; set; }
        public VariableItem(string section, string variable, string valeur, int numdir)
        {
            this.Section = section;
            this.Variable = variable;
            this.Valeur = valeur;
            this.Numdir = numdir;
        }
    }
}
