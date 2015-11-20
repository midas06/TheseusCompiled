using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheseusCompiled
{
    public class Saver
    {
        String filename, mapName; //, filePath;
        string[] theMap;

        public void SetMap(AMap newMap)
        {
            mapName = newMap.Name;
            theMap = newMap.Map;
        }


        public void SetFileName(string newName)
        {
            filename = newName;
        }



        /* public void SaveFile(string newPath)
         {
             StreamWriter sw = new StreamWriter(newPath + @"\" + filename + ".txt"); //filePath + @"\" + filename);
             foreach (var str in theMap)
             {
                 sw.WriteLine(str);
             }
             sw.Dispose();
         }*/

        public void SaveSingle(string newPath, string theString)
        {
            StreamWriter sw = new StreamWriter(newPath + @"\" + filename + ".txt"); //filePath + @"\" + filename);
            sw.Write(theString);
            sw.Dispose();
        }

        public void SaveMultiple(string newPath, string[] theMultipleMaps)
        {
            StreamWriter sw = new StreamWriter(newPath + @"\" + filename + ".txt"); //filePath + @"\" + filename);
            foreach (var str in theMultipleMaps)
            {
                sw.WriteLine(str);
            }
            sw.Dispose();
        }

    }
}
