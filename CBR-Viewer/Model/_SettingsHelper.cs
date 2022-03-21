#region Header
// *******************************************************************************************
// Copyright   : ©2013 Erik Molenaar
// Authors     : Erik Molenaar
// Date        : 16-01-2013
// Revision    : $Rev:  $
// RevDate     : $Date:  $
// Rep./File   : $URL:  $
// Worker      : $Author:  $
// Description : remove from final version, only for internal use ...
// *******************************************************************************************
#endregion // Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO.IsolatedStorage;
using System.IO;

namespace CBR_Viewer.Model
{
    public static class SettingsHelper
    {
        #region Xml
        public static XmlDocument GetXmlDocument(string filename)
        {
            XmlDocument doc = new XmlDocument();
            if (System.IO.File.Exists(filename))
            {

                XmlTextReader reader = new XmlTextReader(filename);
                try
                {
                    doc.Load(reader);

                    reader.Close();
                }
                catch (XmlException exception)
                {
                    throw exception;
                }
            }
            return doc;
        }

        public static XmlTextWriter GetXmlWriter(string filename)
        {
            if (System.IO.File.Exists(filename) == true)
            {
                System.IO.File.Delete(filename);
            }
            // xml
            XmlTextWriter writer = new XmlTextWriter(filename, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 3;

            writer.WriteStartDocument();
            writer.WriteStartElement("settings");

            writer.WriteComment(" ©2013, Erik Molenaar; All rights reserved");
            writer.WriteComment(" Automatically Generated File. Do Not Modify! ");
            return writer;
        }

        public static void CloseXmlWriter(XmlWriter writer)
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }

        static public void SaveXmlDocument(string fileName, XmlDocument doc)
        {
            if ((fileName != "") && (doc != null))
            {
                XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                doc.Save(writer);
                writer.Flush();
                writer.Close();
            }
        }
        #endregion Xml

        #region ReadXml
        public static T ReadEnum<T>(XmlNode node, T def)
        {
            Type enumType = typeof(T);
            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be of type System.Enum");
            }
            if (node == null)
            {
                return def;
            } 
            try
            {
                return (T)Enum.Parse(enumType, node.InnerText);
            }
            catch (ArgumentException)
            {
                return def;
            }
            catch (FormatException)
            {
                return def;
            }
            catch (OverflowException)
            {
                return def;
            }
        }

        public static double ReadDouble(XmlNode node, double def)
        {
            if (node == null)
            {
                return def;
            }
            try
            {
                return Convert.ToDouble(node.InnerText);
            }
            catch (ArgumentException)
            {
                return def;
            }
            catch (FormatException)
            {
                return def;
            }
            catch (OverflowException)
            {
                return def;
            }
        }

        public static bool ReadBool(XmlNode node, bool def)
        {
            if (node == null)
            {
                return def;
            }
            try
            {
                if (node.InnerText.ToLower() == "true")
                {
                    return true;
                }
                else if (node.InnerText.ToLower() == "false")
                {
                    return false;
                }
                else
                {
                    return def;
                }
            }
            catch (ArgumentException)
            {
                return def;
            }
            catch (FormatException)
            {
                return def;
            }
            catch (OverflowException)
            {
                return def;
            }
        }

        public static int ReadInt(XmlNode node, int def)
        {
            if (node == null)
            {
                return def;
            }
            try
            {
                return Convert.ToInt32(node.InnerText);
            }
            catch (ArgumentException)
            {
                return def;
            }
            catch (FormatException)
            {
                return def;
            }
            catch (OverflowException)
            {
                return def;
            }
        }

        public static string ReadString(XmlNode node, string def)
        {
            if (node == null)
            {
                return def;
            }
            return node.InnerText;
        }
        #endregion ReadXml

        #region Path
        public static string GetConfigFileName(string appName, bool useLocalPath)
        {
            string result = ITB(GetConfigPath(appName, useLocalPath));

            result += appName + ".config";
            return result;
        }

        public static string GetConfigPath(string appName, bool useLocalPath)
        {
            string result;
            if (useLocalPath == true)
            {
                result = SettingsHelper.ITB(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            }
            else
            {
                result = SettingsHelper.ITB(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            }
            System.IO.Directory.CreateDirectory(result + @"Gazillion-Bytes");
            result += SettingsHelper.ITB("Gazillion-Bytes");
            System.IO.Directory.CreateDirectory(result + appName);
            result += SettingsHelper.ITB(appName);

            return result;
        }

        public static string ITB(string path)
        {
            string result = path.Replace('/', '\\');
            if ((result.Length > 0) && (result[result.Length - 1] != '\\'))
            {
                result += '\\';
            }
            return result;
        }
        #endregion Path

        #region Settings
        public static void SaveSettings()
        {
            string path = GetSettingsPath();
            XmlWriter writer = GetXmlWriter(path);
            global::CBR_Viewer.Properties.Settings.Default.MainWindowLeft = 123;
            foreach (System.Configuration.SettingsProperty sp in global::CBR_Viewer.Properties.Settings.Default.Properties)
            {
                //sp.Name;
                //sp.
                string s = sp.Name;
                writer.WriteStartElement(s);
                writer.WriteAttributeString("type", sp.PropertyType.Name);
                //writer.WriteValue
                if (global::CBR_Viewer.Properties.Settings.Default[s].GetType().BaseType == typeof(Enum))
                {
                    writer.WriteValue(((int)global::CBR_Viewer.Properties.Settings.Default[s]).ToString());
                }
                else
                {
                    writer.WriteValue(global::CBR_Viewer.Properties.Settings.Default[s].ToString());
                }
                    writer.WriteEndElement();
            }

            CloseXmlWriter(writer);
        }

        public static void LoadSettings()
        {
            string path = GetSettingsPath();
            XmlDocument doc = GetXmlDocument(path);
            if (doc == null)
            {
                return;
            }
            XmlNodeList nl = doc.SelectNodes("/settings//*");

            foreach (XmlNode node in nl)
            {
                string type = (node as XmlElement).GetAttribute("type");
                string name = node.Name;
                object o = null;

                switch (type)
                {
                    case "Int32":
                        {
                            o = ReadInt(node, (int)global::CBR_Viewer.Properties.Settings.Default[name]);
                            break;
                        }
                    case "String":
                        {
                            o = ReadString(node, (string)global::CBR_Viewer.Properties.Settings.Default[name]);
                            break;
                        }
                    default:
                        {

                            object o2 = global::CBR_Viewer.Properties.Settings.Default[name];

                            Type enumType = o2.GetType();
                            
                            if (enumType.BaseType == typeof(Enum))
                            {
                                o = ReadInt(node, (int)global::CBR_Viewer.Properties.Settings.Default[name]);
                                //object tmp = new object();
                                //object t = Activator.CreateInstance(enumType);

                                //System.Windows.WindowState ws= (enumType(o));

                                //System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(enumType);
                                //xs.Deserialize()
                                //System.Xml.Serialization.D
                                return;
                                //global::CBR_Viewer.Properties.Settings.Default[name] = typeof(enumType.ToString())o;
                            }

                            break;
                        }
                }
                global::CBR_Viewer.Properties.Settings.Default[name] = o;
            }
        }

        private static string GetSettingsPath()
        {
            return GetConfigPath("CBReader", true) + "settings.xml";
        }

        public static void WriteSettings()
        {
            string path = GetSettingsPath();

            Properties.Settings settings = global::CBR_Viewer.Properties.Settings.Default;
            // toDo = global::CBR_Viewer.Properties.Settings;

            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Properties.Settings));
            using (System.IO.TextWriter writer = new System.IO.StreamWriter(path))
            {
                ser.Serialize(writer, settings);
                writer.Flush();
            //    foreach (System.Configuration.SettingsProperty sp in toDo)
            //    {
            //        ser.Serialize(writer, sp);
            //    }
            }
            
            
            //IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForDomain();
            //IsolatedStorageFileStream stream = new IsolatedStorageFileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);

            //XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
            //writer.Formatting = Formatting.Indented;
            //writer.WriteStartDocument();

            //(new System.Xml.Serialization.XmlSerializer(typeof(Settings))).Serialize(writer, this);

            //writer.Flush();
            //stream.Close();
            //file.Close();



        }
        #endregion Settings



        /*
        /// <summary>
        /// Load the list of recent files from disk.
        /// </summary>
        public static void LoadRecentFiles()
        {
            if (File.Exists(RecentFilesFilePath))
            {
                // Load the Recent Files from disk
                XmlSerializer ser = new XmlSerializer(typeof(StringCollection));
                using (TextReader reader = new StreamReader(RecentFilesFilePath))
                {
                    recentFiles = (StringCollection)ser.Deserialize(reader);
                }

                // Remove files from the Recent Files list that no longer exists.
                for (int i = 0; i < recentFiles.Count; i++)
                {
                    if (!File.Exists(recentFiles[i]))
                        recentFiles.RemoveAt(i);
                }

                // Only keep the 5 most recent files, trim the rest.
                while (recentFiles.Count > NumberOfRecentFiles)
                    recentFiles.RemoveAt(NumberOfRecentFiles);
            }
        }

        /// <summary>
        /// Save the list of recent files to disk.
        /// </summary>
        public static void SaveRecentFiles()
        {
            XmlSerializer ser = new XmlSerializer(typeof(StringCollection));
            using (TextWriter writer = new StreamWriter(RecentFilesFilePath))
            {
                ser.Serialize(writer, recentFiles);
            }
        }
          
        */
    }
}
