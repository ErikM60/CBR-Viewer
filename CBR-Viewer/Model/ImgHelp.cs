using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace CBR_Viewer.Model
{
    public static class ImgHelp
    {
        public static void SaveImage(string fileName, BitmapSource bs)
        {
            if (bs != null)
            {
                // Encoding the RenderBitmapTarget as a PNG file.
                System.Windows.Media.Imaging.PngBitmapEncoder png = new System.Windows.Media.Imaging.PngBitmapEncoder();
                png.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bs));

                using (System.IO.Stream stm = System.IO.File.Create(fileName))
                {
                    png.Save(stm);
                    stm.Flush();
                    stm.Close();
                }
            }
        }

        public static string SaveImage(BitmapSource bs)
        {
            //logger = LogManager.GetCurrentClassLogger();

            string s = GetFileName("out");
            //logger.Debug("saving pic: " + s);
            SaveImage(s, bs);
            return s;
        }

        public static string GetFileName(string ending)
        {
            //string tmp = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string tmp = "";
            tmp = ITB(tmp) + "pix\\";
            if (!System.IO.Directory.Exists(tmp))
            {
                System.IO.Directory.CreateDirectory(tmp);
            }
            int i = 0;
            string s;
            do
            {
                s = tmp + i.ToString("D4") + "-" + ending + ".png";
                i++;
            } while (ExistsFileName(s));
            return s;
        }

        public static string ITB(string aString)
        {
            aString = aString.Replace('/', '\\');
            if ((aString.Length > 0) && (aString[aString.Length - 1] != '\\'))
            {
                aString = aString + '\\';
            }
            return aString;
        }

        public static bool ExistsFileName(string name)
        {

            string dir = System.IO.Path.GetDirectoryName(name);
            string file = System.IO.Path.GetFileName(name);
            string num = file.Remove(4);
            string[] files = System.IO.Directory.GetFiles(dir);
            foreach (string longName in files)
            {
                string shortName = System.IO.Path.GetFileName(longName);
                if (shortName.StartsWith(num))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
