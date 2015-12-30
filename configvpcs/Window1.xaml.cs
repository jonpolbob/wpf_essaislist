using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Linq;



namespace configvpcs
{
  


    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32")] // scan des sections
        static extern int GetPrivateProfileString(int Section, string Key,
               string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result,
               int Size, string FileName);

        [DllImport("kernel32")] // scan des variables
        static extern int GetPrivateProfileString(string Section, int Key,
               string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result,
               int Size, string FileName);

        ObservableCollection<RepItem> listdir;
        ObservableCollection<VariableItem> LaBase;

        public Window1()
        {
            //this.DataContext = this;
            LaBase = new ObservableCollection<VariableItem>();
            listdir = new System.Collections.ObjectModel.ObservableCollection<RepItem>();
            LoadDir();

            InitializeComponent();
            
            this.ListDir.ItemsSource= listdir;
            
        }


        /// <summary>
        /// 
        /// </summary>
        void LoadDir()
        {

            listdir.Clear();

            //string dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            String dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            List<string> dirs = new List<string>(Directory.GetDirectories(dirPath+@"\viewpointls\viewpointcoresystem".ToString()));
            
            StringBuilder lastring = new StringBuilder(1000);
            int curnum = 0;

            foreach ( string i in dirs)
                {GetPrivateProfileString("app","description","*",lastring,1000, i+"\\viewpointcoresystem.ini");
                string Legend = lastring.ToString();
                GetPrivateProfileString("init", "algo", "0", lastring, 1000, i + "\\viewpointcoresystem.ini");
                string[] listealgos = lastring.ToString().Split(new char[] { ',' });
                int numalgo = 0;
                try
                {
                    numalgo = int.Parse(listealgos[0]);
                }
                catch (Exception e)
                { numalgo = 0;
                }
                
                string dirname = new DirectoryInfo(i).Name;
                listdir.Add(new RepItem(curnum++,numalgo, dirname, Legend));
                }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            InitBase();
            refreshbuttons();
        }

        /// <summary>
        /// scane le dir et remplit la base des variables
        /// </summary>
        /// <param name="nomdir"></param>
        /// <param name="numdir"></param>
        
        private void scandir(string nomdir, int numdir)
        {
            string nomfich = nomdir + "\\viewpointcoresystem.ini";
       
            string[] Sections = listsections(nomfich);

            
            foreach (string section in Sections)
            {
                string[] variables = listvariables(section, nomfich);
                foreach (string variable in variables)
                {
                    StringBuilder lastring = new StringBuilder(1000);
                    GetPrivateProfileString(section, variable, "", lastring, 1000, nomfich);
                    LaBase.Add(new VariableItem(section.ToUpper(), variable.ToUpper(), lastring.ToString(), numdir));
                }
            }

        }


        private string[] listvariables(string section, string nomfich)
        {
            byte[] lastring = new byte[32000];

            int size = GetPrivateProfileString(section, 0, "", lastring, 32000, nomfich);
            if (size < 32000 - 2)
            {
                // Converts the bytes value into an ASCII char.
                // This is one long string.
                string entries = Encoding.ASCII.GetString(lastring, 0,
                                          size - (size > 0 ? 1 : 0));
                // Splits the Long string into an array based on the "\0"
                // or null (Newline) value and returns the value(s) in an array
                string[] result = entries.Split(new char[] { '\0' });
                return result;
            }
            return new string[1] { "" };
        }

        private string [] listsections(string nomfich)
        {
         byte[] lastring = new byte[32000];

         int size = GetPrivateProfileString(0, "", "", lastring, 32000, nomfich);
         if (size < 32000 - 2)
            {
             // Converts the bytes value into an ASCII char.
             // This is one long string.
             string entries = Encoding.ASCII.GetString(lastring, 0,
                                       size - (size > 0 ? 1 : 0));
             // Splits the Long string into an array based on the "\0"
             // or null (Newline) value and returns the value(s) in an array
             string[] result = entries.Split(new char[] { '\0' });
             return result; 
            }

         return new string[1] { "" };
        }

        private void InitBase()
        {
            String dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
          
            LaBase.Clear();
          
            foreach (RepItem item in listdir)
            {
          
                if (item.Checked)
                {
                    scandir(dirPath + @"\viewpointls\viewpointcoresystem\" + item.RepName, item.Num);
                    }
                }
        }

        ///refresh buttons
        ///
        
        void refreshbuttons()
        {

            var query = LaBase.GroupBy(item => item.Section)
                              .ToDictionary(grp => grp.Key, grp => grp.ToList());

            this.Sections.Children.Clear();
            ControlTemplate Butttemplate = this.Sections.FindResource("TopButtonTpl") as ControlTemplate;
            foreach (string value in query.Keys.ToList())
            {
                CheckBox LeButton = new CheckBox();
                LeButton.Template = Butttemplate;
                LeButton.Content = value;
                this.Sections.Children.Add(LeButton);
            }
            
        }


    }

    //classe pour methode d'extension de stringbuilder
    public static class StringBuilderExtension
    {
        public static String[] ZeroSplit(this StringBuilder input)
        {
            List<String> results = new List<String>();

            StringBuilder current = new StringBuilder();
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == '\0')
                {
                    results.Add(current.ToString());
                    current = new StringBuilder();
                }
                else
                    current.Append(input[i].ToString());
            }

            if (current.Length > 0)
                results.Add(current.ToString());

            return results.ToArray();
        }
    }


}
