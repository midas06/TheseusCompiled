﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace TheseusCompiled
{
    public class FileHandler
    {
        Saver saver;
        Loader loader;
        Decompressor decompressor;
        Compressor compressor;
        Bridger bridger;
        List<AMap>[] allMaps;
        List<AMap> originalMaps, userMaps;
        AMap theMap;
        string rootDirectory, userMapDirectory, originalMapsLocation;
        bool overWriteMap;

        public void Init()
        {
            //SetRootDir(@"H:\2015\semester 2\PR 283 C#\Theseus\FilerTesting");
            //SetRootDir(@"C:\Users\Harry\Documents\2015\sem2\c#\FilerTesting");
            //SetRootDir(@"H:\2015\semester 2\PR 283 C#\Theseus\TheseusCompiled");
            SetRootDir(@"H:\2015\semester 2\PR 283 C#\Theseus\TheseusFormed - Test");
            allMaps = new List<AMap>[2];
            LoadOriginalMaps();
            LoadAllUserMaps();
            allMaps[0] = originalMaps;
            allMaps[1] = userMaps;
            //mapLoader = new MapLoader();
        }

        public void SetRootDir(string newRoot)
        {
            rootDirectory = newRoot;
            userMapDirectory = newRoot + @"\UserMaps";
            originalMapsLocation = newRoot + @"\originalMaps.txt";
        }


        public void SaveMultiple(List<AMap> theList, string newPath, string fileName)
        {
            if (compressor == null)
            {
                compressor = new Compressor();
            }
            if (saver == null)
            {
                saver = new Saver();
            }

            string theString = "";
            string[] toSave;


            foreach (AMap m in theList)
            {
                compressor.LoadMap(m.Map);
                theString += m.Name + "&" + compressor.GetResult() + "*";
            }

            toSave = theString.Split(new string[] { "*" }, StringSplitOptions.None);

            //toSave = theString.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            saver.SetFileName(fileName);
            saver.SaveMultiple(newPath, toSave);

        }

        public void LoadOriginalMaps()
        {
            if (decompressor == null)
            {
                decompressor = new Decompressor();
            }
            originalMaps = new List<AMap> { };
            List<string[]> uncompressedMaps;
            loader = new Loader();

            loader.LoadMultiple(originalMapsLocation);
            uncompressedMaps = loader.ParseMap2();

            foreach (string[] map in uncompressedMaps)
            {
                AMap newEntry = new AMap();

                newEntry.Name = map[0];
                newEntry.Map = decompressor.GetTheMap(map[1]);

                originalMaps.Add(newEntry);
            }

            /*foreach (AMap map in originalMaps)
            {
                Console.WriteLine("name: {0}\n", map.Name);
                foreach (string str in map.Map)
                {
                    Console.WriteLine(str);
                }
            }*/
        }



        public AMap LoadUserMap(string path)
        {
            if (decompressor == null)
            {
                decompressor = new Decompressor();
            }
            AMap newMap = new AMap();
            string compressed;
            newMap.Name = Path.GetFileNameWithoutExtension(path);
            compressed = File.ReadAllText(path);
            //Console.WriteLine("{0}, {1}", newMap.Name, compressed);
            newMap.Map = decompressor.GetTheMap(compressed);
            return newMap;
        }

        public void LoadAllUserMaps()
        {
            userMaps = new List<AMap> { };
            foreach (string file in Directory.EnumerateFiles(userMapDirectory, "*.txt"))
            {
                userMaps.Add(LoadUserMap(file));
            }
            /*foreach (AMap map in userMaps)
            {
                Console.WriteLine(map.Name);
                foreach (string str in map.Map)
                {
                    Console.WriteLine(str);
                }
            }*/
        }

        public bool MapNameUsed(string mapName)
        {
            foreach (AMap map in userMaps)
            {
                //Console.WriteLine("mapName: " + map);
                if (map.Name == mapName)
                {
                    Console.WriteLine("used");
                    return true;
                }
            }
            Console.WriteLine("not used");
            return false;
        }

        public void ConfirmOverwrite(bool input)
        {
            overWriteMap = input;
        }


        public bool NewUserMap(string mapName, string[] newMap)
        {
            if (saver == null)
            {
                saver = new Saver();
            }
            if (compressor == null)
            {
                compressor = new Compressor();
            }
            string compressedMap;



            // check to see if mapname is in use
            
            if (MapNameUsed(mapName))
            {
                if (overWriteMap == false)
                {
                    Console.WriteLine("map name already exists");
                    return false;
                }
                
            }
            /*/ add map to user map list
            userMaps.Add(mapName);
            SaveUserMapsList();*/

            // compress map
            compressor.LoadMap(newMap);
            compressedMap = compressor.GetResult();

            // save compressed map to directory
            saver.SetFileName(mapName);
            //saver.SaveSingle(@"C:\Users\Harry\Documents\2015\sem2\c#\FilerTesting\UserMaps", compressedMap);
            saver.SaveSingle(userMapDirectory, compressedMap);
            //saver.SaveSingle(@"H:\2015\semester 2\PR 283 C#\Theseus\FilerTesting\UserMaps", compressedMap);
            return true;
        }

        public string GetMapList(int theList)
        {
            string output = "";
            foreach (AMap map in allMaps[theList])
            {
                output += map.Name + "\n";
            }
            return output;
        }

        public string[] GetMapListArray(int theList)
        {
            string[] outputList;
            string output = "";
            foreach (AMap map in allMaps[theList])
            {
                output += map.Name + "\n";
            }
            output = output.Remove(output.Length - 1);
            outputList = Regex.Split(output, "\n");
            return outputList;
        }


        public void SetMap(int theList, string mapName)
        {
            var m =
                (from map in allMaps[theList]
                 where map.Name == mapName
                 select map).Single();

            //theMap = m;

            if (bridger == null)
            {
                bridger = new Bridger();
            }

            theMap = bridger.Convert(m);

        }

        public AMap GetMap()
        {
            return theMap;
        }

        public bool GetNextMap()
        {
            string theString = theMap.Name;
            theString = theString.Remove(0, 4);
            int i = int.Parse(theString);

            if (i < 10)
            {
                i = i + 1;
                theString = "Map " + i.ToString();
                SetMap(0, theString);
                return true;
            }
            return false;
        }


      

        public string LoadTextFile(string theFile)
        {
            if (loader == null)
            {
                loader = new Loader();
            }

            loader.SetFilePath(theFile);
            loader.ExtractFileContents();
            return loader.GetFileContents();
        }

        public bool TestUncompressed(string theFile)
        {
            string str = LoadTextFile(theFile);
            string[] strArray;
            if (loader == null)
            {
                loader = new Loader();
            }

            strArray = loader.ToStringArray(str);
            AMap newMap = new AMap();

            if (bridger == null)
            {
                bridger = new Bridger();
            }
            bridger.Init(newMap);

            if (!bridger.IsValid())
            {
                return false;
            }

            try
            {
                bridger.Convert(newMap);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;
        }

        public bool TestCompressedL1(string theFile)
        {
            string newFile = LoadTextFile(theFile);
            string[] strArray;
            if (decompressor == null)
            {
                decompressor = new Decompressor();
            }
            decompressor.SetCompressed(newFile);


            try
            {
                decompressor.SeparateToArrays();
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            try
            {
                decompressor.DecompressLevel1();
            }
            catch (Exception)
            {
                return false;
            }
            try
            {
                decompressor.SetCharacters();
            }
            catch (Exception)
            {
                return false;
            }
            strArray = decompressor.GetLevel1Result();

            AMap newMap = new AMap();

            if (bridger == null)
            {
                bridger = new Bridger();
            }
            bridger.Init(newMap);

            if (!bridger.IsValid())
            {
                return false;
            }

            try
            {
                bridger.Convert(newMap);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;

        }

        public bool TestCompressedLevel2(string theFile)
        {
            string newFile = LoadTextFile(theFile);
            string[] strArray;
            if (decompressor == null)
            {
                decompressor = new Decompressor();
            }

            try
            {
                strArray = decompressor.GetTheMap(newFile);
            }
            catch (Exception)
            {
                return false;
            }
            AMap newMap = new AMap();

            if (bridger == null)
            {
                bridger = new Bridger();
            }

            bridger.Init(newMap);

            if (!bridger.IsValid())
            {
                return false;
            }

            try
            {
                bridger.Convert(newMap);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            return true;



        }






      
        

    }
}
