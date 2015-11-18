using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusCompiled
{
    class Compressor
    {
        string[] theMap, compressedMap;
        string theseus, minotaur, exit;
        string theResult = "";

        public void LoadMap(string[] newMap)
        {
            theMap = newMap;
        }

        public void FindSpecialCharacters()
        {
            int i = 0, j = 0, length = theMap[i].Length;
            string str;
            char c;

            while (i < theMap.Length)
            {
                str = theMap[i];
                for (j = 0; j < length; j++)
                {
                    c = str[j];
                    if (c == 'T')
                    {
                        theseus = j.ToString() + "-" + i.ToString();
                        theMap[i] = str.Replace('T', ' ');
                    }
                    if (c == 'M')
                    {
                        minotaur = j.ToString() + "-" + i.ToString();
                        theMap[i] = str.Replace('M', ' ');
                    }
                    if (c == 'X')
                    {
                        exit = j.ToString() + "-" + i.ToString();
                        theMap[i] = str.Replace('X', ' ');
                    }
                }
                i++;
            }
            //Console.WriteLine("Theseus = {0}, Minotaur = {1}, Exit = {2}", theseus, minotaur, exit);
            /*foreach (string s in theMap)
            {
                Console.WriteLine(s);
            }*/
        }

        public void CompressLevel1()
        {
            compressedMap = new string[theMap.Length];
            string theString;
            int numTiles = (theMap[0].Length - 1) / 4;
            int n;

            for (int i = 0; i < theMap.Length; i++)
            {
                theString = theMap[i];

                // for even #'ed strings
                if (i % 2 == 0)
                {
                    string comp = "";
                    for (int j = 0; j < numTiles; j++)
                    {
                        n = (j * 4) + 2;
                        switch (theString[n])
                        {
                            case '_':
                                comp += "U";
                                break;
                            case ' ':
                                comp += "S";
                                break;
                            default:
                                break;
                        }
                    }
                    compressedMap[i] = comp;
                }

                // for odd #'ed strings
                if (i % 2 != 0)
                {
                    string comp = "";
                    for (int j = 0; j <= numTiles; j++)
                    {
                        n = j * 4;
                        switch (theString[n])
                        {
                            case '|':
                                comp += "L";
                                break;
                            case ' ':
                                comp += "S";
                                break;
                            default:
                                break;
                        }
                    }
                    compressedMap[i] = comp;
                }
            }
            /*foreach (string thestr in compressedMap)
            {
                Console.WriteLine(thestr);
            }*/
            /*for (int i = 0; i < compressedMap.Length; i++)
            {
                Console.WriteLine("Line: {0} : {1}", i, compressedMap[i]);
            }*/
        }

        public string CompressLevel2(string aString)
        {
            string output = "";
            int count = 1;

            while (aString.Length != 1)
            {
                if (aString[0] == aString[1])
                {
                    count++;
                    aString = aString.Remove(0, 1);
                }
                else if (aString[0] != aString[1])
                {
                    if (count == 1)
                    {
                        output += aString[0];
                        aString = aString.Remove(0, 1);
                    }
                    else if (count != 1)
                    {
                        output += count.ToString() + aString[0];
                        aString = aString.Remove(0, 1);
                        count = 1;
                    }
                }
            }

            if (count > 1)
            {
                output += count.ToString() + aString;
            }
            else if (count == 1)
            {
                output += aString;
            }


            //Console.WriteLine(output);
            return output;
        }

        public void ShrinkLevel2()
        {
            int i = 0;
            while (i < compressedMap.Length)
            {
                compressedMap[i] = CompressLevel2(compressedMap[i]);
                i++;
            }

        }



        public void SetTheResult()
        {
            string tmx = "";
            string compped = "";

            // add theseus, minotaur and exit into 1 string
            tmx += theseus + ';' + minotaur + ';' + exit;

            // chuck the compressed strings into one long string
            foreach (string str in compressedMap)
            {
                compped += str + '.';
            }
            compped = compped.TrimEnd('.');
            theResult = tmx + ',' + compped;
            //Console.WriteLine(theResult);
        }

        public string GetResult()
        {
            FindSpecialCharacters();
            CompressLevel1();
            ShrinkLevel2();
            SetTheResult();
            return theResult;
        }
    }
}
