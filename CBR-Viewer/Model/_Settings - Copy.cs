using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBR_Viewer.Model
{
    public class Settings
    {
        private static Settings settings;
        
        private Settings()
        { 
        }

        private void Load()
        {

        }

        private void Save()
        {
        }

        public static Settings Instance
        {
            get
            {
                if (settings == null)
                {
                    settings = new Settings();
                }
                return settings;
            }
        }

        //public static System.Collections.Specialized.StringCollection GetStringCollection(List<string> inList)
        //{
        //    if (inList == null)
        //    {
        //        return null;
        //    }
        //    //System.Collections.Specialized.StringCollection result = new System.Collections.Specialized.StringCollection();
        //    //foreach (string s in inList)
        //    //{
        //    //    result.Add(s);
        //    //}
        //    //return result;

        //    //return inList.Cast<string>().;
        //    return null;
        //}

        //public static List<string> getStringList(System.Collections.Specialized.StringCollection inCollection)
        //{
        //    return inCollection.Cast<string>().ToList<string>();
        //}

        public void test()
        {
            System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
            List<string> sl = new List<string>();


        }

    }
}
