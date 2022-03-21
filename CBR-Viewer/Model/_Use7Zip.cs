using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SevenZip;
using System.IO;

namespace CBR_Viewer.Model
{
    public static class Use7Zip 
    {
        public static bool UnRar(string inFile, string outPath)
        {
            SevenZipExtractor extractor;

            if (!DeleteDir(outPath))
            {
                return false;
            }


            try
            {
                if (!Directory.Exists(outPath))
                {
                    Directory.CreateDirectory(outPath);
                }

                extractor = new SevenZipExtractor(inFile);
                extractor.ExtractArchive(outPath);
            }
            catch (Exception)
            {

            }
            finally
            {
                extractor = null;
            }
            return true;
        }

        
        public static string GetTempDirPath()
        {
            string both;
            do
            {
                string temp = Path.GetTempPath();

                System.Diagnostics.Debug.WriteLine(temp);

                string random = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
                //string random = Path.GetRandomFileName();
                System.Diagnostics.Debug.WriteLine(random);

                both = Path.Combine(temp, random);
                System.Diagnostics.Debug.WriteLine(both);
            } while (Directory.Exists(both));
            return both;
        }

        public static bool DeleteDir(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch (System.IO.IOException exp)
                {
                    System.Diagnostics.Debug.WriteLine(exp.Message); 
                    return false;
                }
            }

            return true;
        }

        public static List<NamePath> GetFileList(string path)
        {
            IterItems ii = new IterItems();
            ii.Walk(path);
            return ii.Items;
        }
        /*
        private ReadOnlyCollection<string> ExtractArchive(string varPathToFile, string varDestinationDirectory)
        {
            ReadOnlyCollection<string> readOnlyArchiveFilenames;
            ReadOnlyCollection<string> readOnlyVolumeFilenames;
            varExtractionFinished = false;
            varExtractionFailed = false;
            SevenZipExtractor.SetLibraryPath(sevenZipDll);
            string fileName = "";
            string directory = "";
            Invoke(new SetNoArgsDelegate(() =>
            {
                fileName = varPathToFile;
                directory = varDestinationDirectory;
            }));
            using (SevenZipExtractor extr = new SevenZipExtractor(fileName))
            {
                //string[] test = extr.ArchiveFileNames.

                readOnlyArchiveFilenames = extr.ArchiveFileNames;
                readOnlyVolumeFilenames = extr.VolumeFileNames;
                //foreach (string dinosaur in readOnlyDinosaurs) {
                //MessageBox.Show(dinosaur);
                // }
                //foreach (string dinosaur in readOnlyDinosaurs1) {
                // // MessageBox.Show(dinosaur);
                // }
                try
                {
                    extr.Extracting += extr_Extracting;
                    extr.FileExtractionStarted += extr_FileExtractionStarted;
                    extr.FileExists += extr_FileExists;
                    extr.ExtractionFinished += extr_ExtractionFinished;

                    extr.ExtractArchive(directory);
                }
                catch (FileNotFoundException error)
                {
                    if (varExtractionCancel)
                    {
                        LogBoxTextAdd("[EXTRACTION WAS CANCELED]");
                    }
                    else
                    {
                        MessageBox.Show(error.ToString(), "Error with extraction");
                        varExtractionFailed = true;
                    }
                }
            }
            varExtractionFinished = true;
            return readOnlyVolumeFilenames;
        }

        private void extr_FileExists(object sender, FileOverwriteEventArgs e)
        {
            listViewLogFile.Invoke(new SetOverwriteDelegate((args) => LogBoxTextAdd(String.Format("Warning: \"{0}\" already exists; overwritten\r\n", args.FileName))), e);
        }
        private void extr_FileExtractionStarted(object sender, FileInfoEventArgs e)
        {
            listViewLogFile.Invoke(new SetInfoDelegate((args) => LogBoxTextAdd(String.Format("Extracting \"{0}\"", args.FileInfo.FileName))), e);
        }
        private void extr_Extracting(object sender, ProgressEventArgs e)
        {
            progressBarCurrentExtract.Invoke(new SetProgressDelegate((args) => progressBarCurrentExtract.Increment(args.PercentDelta)), e);
        }
        private void extr_ExtractionFinished(object sender, EventArgs e)
        {
            Invoke(new SetNoArgsDelegate(() =>
            {
                //pb_ExtractWork.Style = ProgressBarStyle.Blocks;
                progressBarCurrentExtract.Value = 0;
                varExtractionFinished = true;
                //l_ExtractProgress.Text = "Finished";
            }));
        }
        */


        // UnRar("C:\\Download\\sampleextractfolder\\", filepath2);
        /*
        private static void UnRar(string WorkingDirectory, string filepath)
        {

            // Microsoft.Win32 and System.Diagnostics namespaces are imported

            //Dim objRegKey As RegistryKey
            RegistryKey objRegKey;
            objRegKey = Registry.ClassesRoot.OpenSubKey("WinRAR\\Shell\\Open\\Command");
            // Windows 7 Registry entry for WinRAR Open Command

            // Dim obj As Object = objRegKey.GetValue("");
            Object obj = objRegKey.GetValue("");

            //Dim objRarPath As String = obj.ToString()
            string objRarPath = obj.ToString();
            objRarPath = objRarPath.Substring(1, objRarPath.Length - 7);

            objRegKey.Close();

            //Dim objArguments As String
            string objArguments;
            // in the following format
            // " X G:\Downloads\samplefile.rar G:\Downloads\sampleextractfolder\"
            objArguments = " X " + " " + filepath + " " + " " + WorkingDirectory;

            // Dim objStartInfo As New ProcessStartInfo()
            ProcessStartInfo objStartInfo = new ProcessStartInfo();

            // Set the UseShellExecute property of StartInfo object to FALSE
            //Otherwise the we can get the following error message
            //The Process object must have the UseShellExecute property set to false in order to use environment variables.
            objStartInfo.UseShellExecute = false;
            objStartInfo.FileName = objRarPath;
            objStartInfo.Arguments = objArguments;
            objStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            objStartInfo.WorkingDirectory = WorkingDirectory + "\\";

            //   Dim objProcess As New Process()
            Process objProcess = new Process();
            objProcess.StartInfo = objStartInfo;
            objProcess.Start();
            objProcess.WaitForExit();


            try
            {
                FileInfo file = new FileInfo(filepath);
                file.Delete();
            }
            catch (FileNotFoundException e)
            {
                throw e;
            }
        }
*/        


    }


 }
