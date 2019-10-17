using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

namespace FM
{
    public partial class fMain : Form
    {

        public FileController fileController = new FileController();
       

        WorkWindow leftWorkWindow;
        WorkWindow rightWorkWindow;


        public fMain()
        {
            InitializeComponent();
            MyInit();
        }

        private void MyInit()
        {
            leftWorkWindow = new WorkWindow(leftDirs, leftFiles, leftSelectDrive, leftSelectExtension, "C:\\");
            rightWorkWindow = new WorkWindow(rightDirs, rightFiles, rightSelectDrive, rightSelectExtension, "D:\\");
            fileController.OpenDirectory(leftWorkWindow);
            fileController.OpenDirectory(rightWorkWindow);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            //hread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");

            StreamWriter file = new StreamWriter(@"C:\Users\Acer\Desktop\LogsFM.txt");
            file.Flush();
            file.Close();

        }


        private void DirMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
      
            if (listBox.Name == "leftDirs")
            {
                rightWorkWindow.dirs.ClearSelected();
                rightWorkWindow.files.ClearSelected();
                leftWorkWindow.activePath = fileController.NextPath(leftWorkWindow.activePath, listBox.Text);    
                fileController.OpenDirectory(leftWorkWindow);
            }
            else
            if (listBox.Name == "rightDirs")
            {
                leftWorkWindow.dirs.ClearSelected();
                leftWorkWindow.files.ClearSelected();
                rightWorkWindow.activePath = fileController.NextPath(rightWorkWindow.activePath, listBox.Text);
                fileController.OpenDirectory(rightWorkWindow);
            }
           
        }



     

        private void SelectedDriveChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Name == "leftSelectDrive")
            {
                leftWorkWindow.activePath = comboBox.Text.ToString();
                fileController.OpenDirectory(leftWorkWindow);
            }
            else
            if (comboBox.Name == "rightSelectDrive")
            {
                rightWorkWindow.activePath = comboBox.Text.ToString();
                fileController.OpenDirectory(rightWorkWindow);
            }
            
        }

        private void SelectExtensionChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Name == "leftSelectExtension")
            {
                leftWorkWindow.FilterFiles();
            }
            else
            if (comboBox.Name == "rightSelectExtension")
            {
                rightWorkWindow.FilterFiles();
            }
        }



        private void FileMouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            FileInfo fileInfo = (FileInfo)(listBox.SelectedItem);
            if (fileInfo != null)
            {
                string activePath = fileInfo.FullName;
                fileController.OpenFile(activePath);
            }
            
        }


        private void ItemMouseClick(object sender, MouseEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Point pt = new Point(e.X, e.Y);
            int index = listBox.IndexFromPoint(pt);

            fileController.ClearAllSelected(leftWorkWindow, rightWorkWindow);

            if (index <= -1)
            {
                listBox.SelectedItems.Clear();
            }
            else
            {
                listBox.SetSelected(index, true);
            }
        }

        private void DelMouseClick(object sender, MouseEventArgs e)
        {
            fileController.DeleteSelectedFile(leftWorkWindow, rightWorkWindow);   
        }

        private void RenameMouseClick(object sender, MouseEventArgs e)
        {
            fileController.RenameSelectedFile(leftWorkWindow, rightWorkWindow);
        }

        private void BtnMove_MouseClick(object sender, MouseEventArgs e)
        {
            fileController.MoveSelectedFile(leftWorkWindow, rightWorkWindow);
        }

        private void FMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                fileController.DeleteSelectedFile(leftWorkWindow, rightWorkWindow);
            }
            else
            if (e.KeyCode == Keys.F2)
            {
                fileController.RenameSelectedFile(leftWorkWindow, rightWorkWindow);
            }
            else
            if (e.KeyCode == Keys.F6)
            {
                fileController.MoveSelectedFile(leftWorkWindow, rightWorkWindow);
            }
        }
        
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileController.DeleteSelectedFile(leftWorkWindow, rightWorkWindow);
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileController.RenameSelectedFile(leftWorkWindow, rightWorkWindow);
        }

        private void MoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileController.MoveSelectedFile(leftWorkWindow, rightWorkWindow);
        }



        private void BtnNewFile_Click(object sender, EventArgs e)
        {
            fileController.createNewFile(leftWorkWindow, rightWorkWindow);
        }

        private void BtnNewDirectory_Click(object sender, EventArgs e)
        {
            fileController.createNewDirectory(leftWorkWindow, rightWorkWindow);
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            fileController.showHelp();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            fileController.SerchFiles();
        }


        public class FileController
        {
            public string pathLogs = @"C:\Users\Acer\Desktop\LogsFM.txt";

            public void OpenFile(string activePath)
            {
                try
                {

                    FileInfo fi = new FileInfo(activePath);
                    
                    Director director = new Director();
                    EventManagerBuilder movingEventManagerBuilder = new MovingEventManagerBuilder();
                    director.SetEventManagerBuilder(movingEventManagerBuilder);
                    director.ConstructEventManager("Was opened " + activePath);
                    EventManager eventManager = director.GetEventManager();
                    AddEventManager(eventManager.ToString());

                    TextEditor te = new TextEditor(fi);
                    te.ShowDialog();

                    movingEventManagerBuilder = new MovingEventManagerBuilder();
                    director.SetEventManagerBuilder(movingEventManagerBuilder);
                    director.ConstructEventManager("Was  " + activePath);
                    eventManager = director.GetEventManager();
                    AddEventManager(eventManager.ToString());

                }
                catch(Exception e)
                {
                    Director director = new Director();
                    EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                    director.SetEventManagerBuilder(errorEventManagerBuilder);
                    director.ConstructEventManager(e.Message);
                    EventManager eventManager = director.GetEventManager();
                    AddEventManager(eventManager.ToString());

                    ErrorMessage errorMessage = new ErrorMessage(e.Message);
                    errorMessage.ShowDialog();
                }
                
 
            }

            public void OpenDirectory(WorkWindow workWindow)
            {
                string backPath = null;
                if (!IsDrive(workWindow.activePath))
                    backPath = "...";

                DirectoryInfo children = new DirectoryInfo(workWindow.activePath);

                DirectoryInfo[] childrenDirs = children.GetDirectories();
                
                workWindow.dirs.Items.Clear();
                if (backPath != null)
                    workWindow.dirs.Items.Add(backPath);
                workWindow.dirs.Items.AddRange(childrenDirs);

                workWindow.FilterFiles();

                Director director = new Director();
                EventManagerBuilder movingEventManagerBuilder = new MovingEventManagerBuilder();
                director.SetEventManagerBuilder(movingEventManagerBuilder);
                director.ConstructEventManager("Was opened " + workWindow.activePath);
                EventManager eventManager = director.GetEventManager();
                AddEventManager(eventManager.ToString());

            }

            public string NextPath(string activePath, string nextPath)
            {
                if (nextPath == null || nextPath == "")
                {
                    return activePath;
                }
                else
                if (nextPath == "...")
                {
                    return PrevPath(activePath);
                }
                else
                {
                    string answerPath = activePath + nextPath + "\\";
                    if (IsFolderAvailable(new DirectoryInfo(answerPath)))
                    {
                        return answerPath;
                    }
                    else
                    {
                    
                        Director director = new Director();
                        EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                        director.SetEventManagerBuilder(errorEventManagerBuilder);
                        director.ConstructEventManager("Directory " + answerPath + " is not available");
                        EventManager eventManager = director.GetEventManager();
                        AddEventManager(eventManager.ToString());
                        
                        ErrorMessage errorMessage = new ErrorMessage("This directory is not available");
                        errorMessage.ShowDialog();
                        return activePath;
                    
                    }
                }
            }


            public void AddEventManager(string eventText)
            {

                StreamWriter file = new StreamWriter(pathLogs, true, Encoding.UTF8);
                file.WriteLine(eventText);
                file.Close();
                
            }
            public string PrevPath(string activePath)
            {
                if (activePath[activePath.Length - 1] == '\\')
                {
                    activePath = activePath.Remove(activePath.Length - 1, 1);
                }
                while (activePath[activePath.Length - 1] != '\\')
                {
                    activePath = activePath.Remove(activePath.Length - 1, 1);
                }
                return activePath;
            }


            public bool IsDrive(string activePath)
            {
                return (activePath == "C:\\" || activePath == "D:\\");
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


            public void ClearAllSelected(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                leftWorkWindow.dirs.ClearSelected();
                leftWorkWindow.files.ClearSelected();
                rightWorkWindow.dirs.ClearSelected();
                rightWorkWindow.files.ClearSelected();
            }


            public void DeleteFolder(DirectoryInfo folder)
            {
                if (!IsFolderAvailable(folder))
                {
                    Director director = new Director();
                    EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                    director.SetEventManagerBuilder(errorEventManagerBuilder);
                    director.ConstructEventManager("Directory " + folder.FullName + " is not available for deleting");
                    EventManager eventManager = director.GetEventManager();
                    AddEventManager(eventManager.ToString());

                    ErrorMessage errorMessage = new ErrorMessage("This directory is not available");
                    errorMessage.ShowDialog();
                    return;
                }
                else
                {

                    FileInfo[] childerFile = folder.GetFiles();
                    for (int i = childerFile.Length - 1; i >= 0; i--)
                    {
                        childerFile[i].Delete();
                    }
                    
                    DirectoryInfo[] childrenDirectory = folder.GetDirectories();
                    for (int i = childrenDirectory.Length - 1; i >= 0; i--)
                    {
                        DeleteFolder(childrenDirectory[i]);
                    }

                    
                    folder.Delete();
                }
            }

            public void DeleteSelectedFile(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                FileSystemInfo selectedFile = GetSelectedFile(leftWorkWindow, rightWorkWindow);
                if (selectedFile == null)
                {
                    ErrorMessage errorMessage = new ErrorMessage("No files selected");
                    errorMessage.ShowDialog();
                    Console.WriteLine("Was not selected files");
                    return;
                }


                if (File.Exists(selectedFile.FullName))
                {

                    var dlgRes = MessageBox.Show("Delete this item : " + selectedFile.Name, "", MessageBoxButtons.YesNo);
                    
                    if (dlgRes == DialogResult.Yes)
                    {
                        try
                        {
                            selectedFile.Delete();
                        }
                        catch (Exception e)
                        {
                            Director director = new Director();
                            EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                            director.SetEventManagerBuilder(errorEventManagerBuilder);
                            director.ConstructEventManager(e.Message);
                            EventManager eventManager = director.GetEventManager();
                            AddEventManager(eventManager.ToString());

                            ErrorMessage errorMessage = new ErrorMessage(e.Message);
                            errorMessage.ShowDialog();
                        }
                        OpenDirectory(leftWorkWindow);
                        OpenDirectory(rightWorkWindow);
                    }
                }
                else
                {
                    var dlgRes = MessageBox.Show("Delete this item : " + selectedFile.Name, "", MessageBoxButtons.YesNo);

                    if (dlgRes == DialogResult.Yes)
                    {

                        if (IsOpenNow(leftWorkWindow, (DirectoryInfo)selectedFile) || IsOpenNow(rightWorkWindow, (DirectoryInfo)selectedFile))
                        {
                            Director director = new Director();
                            EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                            director.SetEventManagerBuilder(errorEventManagerBuilder);
                            director.ConstructEventManager("This folder or children for it is opened in one of the part in FileManager");
                            EventManager eventManager = director.GetEventManager();
                            AddEventManager(eventManager.ToString());

                            ErrorMessage errorMessage = new ErrorMessage("This folder or children for it is opened in one of the part in FileManager");
                            errorMessage.ShowDialog();
                        }
                        else
                        {
                            DeleteFolder((DirectoryInfo)(selectedFile));
                            OpenDirectory(leftWorkWindow);
                            OpenDirectory(rightWorkWindow);
                        }

                        
                    }

                        
                }

            }

            public bool IsOpenNow(WorkWindow  workWindow, DirectoryInfo directoryInfo)
            {
                string activePath = workWindow.activePath;
                string delDirectoryPath = directoryInfo.FullName;

                return activePath.StartsWith(delDirectoryPath);
               
            }

            public void RenameSelectedFile(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                FileSystemInfo selectedFile = GetSelectedFile(leftWorkWindow, rightWorkWindow);
                if (selectedFile != null)
                {

                    Console.WriteLine("Was found file : " + selectedFile.Name);
                    // input new name for file or directory

                    InputDataMessage inputDataMessage = new InputDataMessage("Input new name for file " + selectedFile.Name);
                    inputDataMessage.ShowDialog();
                    string inputData = inputDataMessage.answer;

                    
                    if (inputData == selectedFile.Name || inputData == "" || inputData == null)
                    {
                        return;
                    }


                    try
                    {

                        if (Directory.Exists(selectedFile.FullName))
                        {
                            ((DirectoryInfo)(selectedFile)).MoveTo(Directory.GetParent(selectedFile.FullName) + "\\" + inputData);
                        }
                        else
                        if (File.Exists(selectedFile.FullName))
                        {
                            ((FileInfo)(selectedFile)).MoveTo(Directory.GetParent(selectedFile.FullName) + "\\" + inputData);
                        }

                        Director director = new Director();
                        EventManagerBuilder changeEventManagerBuilder = new ChangeEventManagerBuilder();
                        director.SetEventManagerBuilder(changeEventManagerBuilder);
                        director.ConstructEventManager("Was rename " + selectedFile.FullName + " to " + Directory.GetParent(selectedFile.FullName) + "\\" + inputData);
                        EventManager eventManager = director.GetEventManager();
                        AddEventManager(eventManager.ToString());

                    }
                    catch(Exception e)
                    {
                        Director director = new Director();
                        EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                        director.SetEventManagerBuilder(errorEventManagerBuilder);
                        director.ConstructEventManager(e.Message);
                        EventManager eventManager = director.GetEventManager();
                        AddEventManager(eventManager.ToString());

                        ErrorMessage errorMessage = new ErrorMessage(e.Message);
                        errorMessage.ShowDialog();
                    }

                    OpenDirectory(leftWorkWindow);
                    OpenDirectory(rightWorkWindow);


                    
                }
                else
                {
                    ErrorMessage errorMessage = new ErrorMessage("No files selected");
                    errorMessage.ShowDialog();
                    Console.WriteLine("Was not selected files");
                }
                return;
            }
            

            public void MoveSelectedFile(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                FileSystemInfo selectedFile = GetSelectedFile(leftWorkWindow, rightWorkWindow);

                if (selectedFile != null)
                {

                    Console.WriteLine("Was found file : " + selectedFile.Name);
                    // input new name for file or directory

                    InputDataMessage inputDataMessage = new InputDataMessage("Input new path for " + selectedFile.Name);
                    inputDataMessage.ShowDialog();
                    string inputData = inputDataMessage.answer;

                    if (inputData == selectedFile.Name || inputData == "" || inputData == null)
                    {
                        return;
                    }


                    if (inputData.StartsWith(selectedFile.FullName))
                    {
                        Director director = new Director();
                        EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                        director.SetEventManagerBuilder(errorEventManagerBuilder);
                        director.ConstructEventManager(selectedFile.FullName + " doesn't move to " + inputData + ". The final folder is the source or child folder for it");
                        EventManager eventManager = director.GetEventManager();
                        AddEventManager(eventManager.ToString());

                        ErrorMessage errorMessage = new ErrorMessage("The final folder is the source or child folder for it");
                        errorMessage.ShowDialog();
                        return;
                    }
                    try
                    {
                        if (Directory.Exists(selectedFile.FullName))
                        {
                            Directory.Move(selectedFile.FullName, inputData + "\\" + selectedFile.Name);
                        }
                        else
                        if (File.Exists(selectedFile.FullName))
                        {
                            File.Move(selectedFile.FullName, inputData + "\\" + selectedFile.Name);
                        }
                        
                        Director director = new Director();
                        EventManagerBuilder changeEventManagerBuilder = new ChangeEventManagerBuilder();
                        director.SetEventManagerBuilder(changeEventManagerBuilder);
                        director.ConstructEventManager("Was moved " + selectedFile.FullName + " to " + inputData + "\\" + selectedFile.Name);
                        EventManager eventManager = director.GetEventManager();
                        AddEventManager(eventManager.ToString());

                    }
                    catch (Exception e)
                    {
                        Director director = new Director();
                        EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                        director.SetEventManagerBuilder(errorEventManagerBuilder);
                        director.ConstructEventManager(e.Message);
                        EventManager eventManager = director.GetEventManager();
                        AddEventManager(eventManager.ToString());
                        ErrorMessage errorMessage = new ErrorMessage(e.Message);
                        errorMessage.ShowDialog();
                    }

                    OpenDirectory(leftWorkWindow);
                    OpenDirectory(rightWorkWindow);



                }
                else
                {
                    ErrorMessage errorMessage = new ErrorMessage("No files selected");
                    errorMessage.ShowDialog();
                    Console.WriteLine("Was not selected files");
                }
                return;
            }

            public FileSystemInfo GetSelectedFile(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                if (leftWorkWindow.dirs.SelectedItem != null)
                    return (FileSystemInfo)leftWorkWindow.dirs.SelectedItem;
                else
                if (leftWorkWindow.files.SelectedItem != null)
                    return (FileSystemInfo)leftWorkWindow.files.SelectedItem;
                if (rightWorkWindow.dirs.SelectedItem != null)
                    return (FileSystemInfo)rightWorkWindow.dirs.SelectedItem;
                else
                if (rightWorkWindow.files.SelectedItem != null)
                    return (FileSystemInfo)rightWorkWindow.files.SelectedItem;
                else
                    return null;   
            }


            public WorkWindow GetPartForNewFile(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                SystemFileCreator systemFileCreator = new SystemFileCreator();
                systemFileCreator.ShowDialog();
                if (systemFileCreator.answer == "Left part")
                {
                    return leftWorkWindow;
                }
                else
                if (systemFileCreator.answer == "Right part")
                {
                    return rightWorkWindow;
                }
                else
                {
                    return null;
                }
            }

            public void createNewFile(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                WorkWindow workWindow = GetPartForNewFile(leftWorkWindow, rightWorkWindow);
                if (workWindow == null)
                {
                    return;
                }
                for (int i = 1; ; i++)
                {
                    string newFileName = workWindow.activePath + "NewFile" + i.ToString() + ".txt";
                    
                    if (File.Exists(newFileName))
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            
                            FileStream fs = File.Create(newFileName);
                            fs.Close();

                            Director director = new Director();
                            EventManagerBuilder changeEventManagerBuilder = new ChangeEventManagerBuilder();
                            director.SetEventManagerBuilder(changeEventManagerBuilder);
                            director.ConstructEventManager("Was created file " + newFileName);
                            EventManager eventManager = director.GetEventManager();
                            AddEventManager(eventManager.ToString());

                        }
                        catch(Exception e)
                        {
                            Director director = new Director();
                            EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                            director.SetEventManagerBuilder(errorEventManagerBuilder);
                            director.ConstructEventManager(e.Message);
                            EventManager eventManager = director.GetEventManager();
                            AddEventManager(eventManager.ToString());

                            ErrorMessage errorMessage = new ErrorMessage(e.Message);
                            errorMessage.ShowDialog();
                        }
                        break;
                    }
                }

                OpenDirectory(leftWorkWindow);
                OpenDirectory(rightWorkWindow);
            }

        

            public void createNewDirectory(WorkWindow leftWorkWindow, WorkWindow rightWorkWindow)
            {
                WorkWindow workWindow = GetPartForNewFile(leftWorkWindow, rightWorkWindow);
                if (workWindow == null)
                {
                    return;
                }
                for (int i = 1; ; i ++)
                {
                    string newFileName = workWindow.activePath + "NewDirectory" + i.ToString();
                    
                    
                    if (Directory.Exists(newFileName))
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                           
                            DirectoryInfo di = Directory.CreateDirectory(newFileName);
                            Director director = new Director();
                            EventManagerBuilder changeEventManagerBuilder = new ChangeEventManagerBuilder();
                            director.SetEventManagerBuilder(changeEventManagerBuilder);
                            director.ConstructEventManager("Was created directory " + newFileName);
                            EventManager eventManager = director.GetEventManager();

                            AddEventManager(eventManager.ToString());
                        }
                        catch (Exception e)
                        {
                            

                            ErrorMessage errorMessage = new ErrorMessage(e.Message);
                            errorMessage.ShowDialog();

                            Director director = new Director();
                            EventManagerBuilder errorEventManagerBuilder = new ErrorEventManagerBuilder();
                            director.SetEventManagerBuilder(errorEventManagerBuilder);
                            director.ConstructEventManager(e.Message);
                            EventManager eventManager = director.GetEventManager();
                            AddEventManager(eventManager.ToString());
                        }
                        
                        break;
                    }
                }

                OpenDirectory(leftWorkWindow);
                OpenDirectory(rightWorkWindow);
            }


            public void showHelp()
            {
                HelpForm helpForm = new HelpForm();
                helpForm.ShowDialog();
            }

            public void SerchFiles()
            {
                SearchFilesWindow searchFilesWindow = new SearchFilesWindow();
                searchFilesWindow.ShowDialog();
            }
        }


        public class WorkWindow
        {
            public ListBox dirs;
            public ListBox files;
            public ComboBox selectDrive;
            public ComboBox selectExtencion;
            public string activePath;

            public WorkWindow(ListBox dirs, ListBox files, ComboBox selectDrive, ComboBox selectExtencion, string activePath)
            {
                this.dirs = dirs;
                this.files = files;
                this.selectDrive = selectDrive;
                this.selectExtencion = selectExtencion;
                this.activePath = activePath;
            }
            
            public void FilterFiles()
            {
                string filter = selectExtencion.Text.ToString();
                files.Items.Clear();
                DirectoryInfo dir = new DirectoryInfo(activePath);
                FileInfo[] allFiles = dir.GetFiles();
                foreach (FileInfo crrFile in allFiles)
                {
                    if (CheckFilter(crrFile, filter))
                    {
                        files.Items.Add(crrFile);
                    }
                }
            }

            public static bool CheckFilter(FileInfo file, string filter)
            {
                return (filter == "All files" || file.Extension.Equals(filter));
            }

            
        }

        
    }
}
