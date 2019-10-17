using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FM
{
    public partial class SearchFilesWindow : Form
    {
        SearchController searchController = new SearchController();
        fMain.FileController fileController = new fMain.FileController();
        
        public SearchFilesWindow()
        {
            InitializeComponent();
            MyInit();
        }

        public void MyInit()
        {
            listBox1.HorizontalScrollbar = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            searchController.FindFilesByText(listBox1, textBox1.Text);
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string fileName = listBox1.SelectedItem.ToString();
            if (fileName != null && fileName != "")
            { 
                fileController.OpenFile(fileName);
            }
        }


        public class SearchController
        {
            public void FindFilesByText(ListBox listBox, string text)
            {
                listBox.Items.Clear();
                Find(listBox, new DirectoryInfo("D:\\"), text);
                //Find(listBox, new DirectoryInfo("C:\\"), text);
            }

            public void Find(ListBox listBox, DirectoryInfo folder, string text)
            {

                if (IsFolderAvailable(folder) && !folder.FullName.ToLower().EndsWith("recycle.bin"))
                {
                    
                    //Console.WriteLine(folder.FullName);

                    
                    DirectoryInfo[] dirs = folder.GetDirectories();
                    foreach (DirectoryInfo currDir in dirs)
                    {
                        
                        Find(listBox, currDir, text);
                        
                    }
                    
                    
                    FileInfo[] files = folder.GetFiles();
                    foreach(FileInfo currFile in files)
                    {
                        if (currFile.Extension.Equals(".txt"))
                        {
                            //Console.WriteLine(currFile.FullName);

                            if (ValidateFile(currFile, text))
                            {
                                listBox.Items.Add(currFile.FullName);
                            }

                        }
                    }

                }

            }

            public bool ValidateFile(FileInfo fileInfo, string text)
            {
                try
                {
                    StreamReader sr = new StreamReader(fileInfo.FullName, Encoding.UTF8);
                    string allText = sr.ReadToEnd();
                    sr.Close();

                    if (allText.Contains(text))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (IOException)
                {
                    return false;
                }

            }

            public bool IsFolderAvailable(DirectoryInfo directoryInfo)
            {
                try
                {
                    DirectoryInfo[] children = directoryInfo.GetDirectories();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                return true;
            }


        }

        
    }
}
