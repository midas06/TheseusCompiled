using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace TheseusCompiled
{



    public class Loader
    {
        String filePath, fileContents;
        //String[] theMap;
        List<AMap> originalMaps = new List<AMap> { };

        public void SetFilePath(string newPath)
        {
            filePath = newPath;
        }

        public void ExtractFileContents()
        {
            fileContents = File.ReadAllText(filePath);
        }

        public string GetFileContents()
        {
            return fileContents;
        }

        public string[] ToStringArray(string newMap)
        {
            // reminder - need to remove string -> strArray code from Filer2
            string[] theMap = newMap.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return theMap;
        }



        public void LoadMultiple(string thePath)
        {
            SetFilePath(thePath);
            ExtractFileContents();
        }

        public List<String[]> ParseMap2()
        {
            string[] newMap, temp;
            List<string[]> tempMapArray = new List<string[]> { };
            temp = fileContents.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in temp)
            {
                newMap = str.Split(new char[] { '&' });

                //newEntry.Map = ToStringArray(newMap[1]);
                tempMapArray.Add(newMap);
            }




            return tempMapArray;
        }
        public void ParseMap()//string allMaps)
        {
            string[] newMap, temp;

            temp = fileContents.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in temp)
            {
                AMap newEntry = new AMap();
                newMap = str.Split(new char[] { '%' });
                newEntry.Name = newMap[0];
                newEntry.Map = ToStringArray(newMap[1]);
                originalMaps.Add(newEntry);
            }


        }

    

        public string[] GetOriginalMap(List<AMap> theList, string mapName)
        {
            var m =
                (from map in originalMaps
                 where map.Name == mapName
                 select map).Single();

            return m.Map;
        }

        public List<AMap> GetOriginalMaps()
        {
            return originalMaps;
        }


    }
}
