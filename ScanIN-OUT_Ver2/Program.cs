using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ScanINOUTVer2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AnotherInstanceExists())
            {
                MessageBox.Show("You cannot run more than one instance of this application.", "Only one instance allowed to run", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DirectoryInfo dis = new DirectoryInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//SIO//");
            if (!dis.Exists)
            {
                DirectoryInfo dd = new DirectoryInfo("SIO");
                dis.Create();

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(dd.FullName, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(dd.FullName, dis.FullName));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(dd.FullName, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(dd.FullName, dis.FullName), true);

                //Directory.Move(dd.FullName, dis.FullName);
                FileInfo ff = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//sio_version3.sio");
                ff.Create();
            }
            else
            {
                FileInfo ff = new FileInfo(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//sio_version3.sio");
                if (!ff.Exists)
                {
                    dis.Delete(true);
                    dis.Create();
                    DirectoryInfo dd = new DirectoryInfo("SIO");
                    //Now Create all of the directories
                    foreach (string dirPath in Directory.GetDirectories(dd.FullName, "*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(dd.FullName, dis.FullName));

                    //Copy all the files & Replaces any files with the same name
                    foreach (string newPath in Directory.GetFiles(dd.FullName, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(dd.FullName, dis.FullName), true);
                    ff.Create();
                }
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
        public static bool AnotherInstanceExists()
        {
            Process currentRunningProcess = Process.GetCurrentProcess();
            Process[] listOfProcs = Process.GetProcessesByName(currentRunningProcess.ProcessName);

            foreach (Process proc in listOfProcs)
            {
                if ((proc.MainModule.FileName == currentRunningProcess.MainModule.FileName) && (proc.Id != currentRunningProcess.Id))
                    return true;
            }
            return false;
        }
    }
}
