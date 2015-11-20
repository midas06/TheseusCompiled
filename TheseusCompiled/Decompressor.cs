using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TheseusCompiled
{
    public class Decompressor
    {
        string compressed;
        string[] separatedArray, compressedMap, theMap;
        int[] theseus, minotaur, exit;

        protected void SetCompressed(string newString)
        {
            compressed = newString;
        }

        protected void SeparateToArrays()
        {
            string[] anArray, dummy;
            separatedArray = compressed.Split(',');
            anArray = separatedArray[0].Split(';');
            compressedMap = separatedArray[1].Split('.');

            // separate M T X
            dummy = anArray[0].Split('-');
            theseus = Array.ConvertAll(dummy, int.Parse);

            dummy = anArray[1].Split('-');
            minotaur = Array.ConvertAll(dummy, int.Parse);

            dummy = anArray[2].Split('-');
            exit = Array.ConvertAll(dummy, int.Parse);
        }

        protected string UndoLevel2(string aString)
        {
            string decomp = "";
            while (aString.Length > 1)
            {
                if (!Char.IsLetter(aString[0]))
                {
                    int multiplier = (int)Char.GetNumericValue(aString[0]);
                    string expanded = new String(aString[1], multiplier);
                    decomp += expanded;
                    aString = aString.Remove(0, 2);
                }
                else if (Char.IsLetter(aString[0]))
                {
                    decomp += aString[0];
                    aString = aString.Remove(0, 1);
                }
            }
            if (aString.Length > 0)
            {
                decomp += aString[0];
            }

            // Console.WriteLine(decomp);
            return decomp;
        }

        protected void DecompressLevel2()
        {
            theMap = new string[compressedMap.Length];

            for (int i = 0; i < compressedMap.Length; i++)
            {
                compressedMap[i] = UndoLevel2(compressedMap[i]);
            }

        }

        protected void DecompressLevel1()
        {
            theMap = new string[compressedMap.Length];
            string theString;

            for (int i = 0; i < compressedMap.Length; i++)
            {
                theString = compressedMap[i];

                // even #'ed strings
                if (i % 2 == 0)
                {
                    string decomp = ".";

                    for (int j = 0; j < theString.Length; j++)
                    {
                        switch (theString[j])
                        {
                            case 'U':
                                decomp += "___.";
                                break;
                            case 'S':
                                decomp += "   .";
                                break;
                            default:
                                break;
                        }
                    }
                    theMap[i] = decomp;
                }

                // odd #'ed strings
                if (i % 2 != 0)
                {
                    string decomp = "";

                    for (int j = 0; j < theString.Length; j++)
                    {
                        switch (theString[j])
                        {
                            case 'L':
                                decomp += "|   ";
                                break;
                            case 'S':
                                decomp += "    ";
                                break;
                            default:
                                break;
                        }
                    }
                    theMap[i] = decomp;
                }
            }

            /* foreach (string str in theMap)
             {
                 Console.WriteLine(str);
             }*/
        }

        protected void SetCharacters()
        {
            int x, y;
            StringBuilder theSB;

            // theseus
            x = theseus[0];
            y = theseus[1];
            theSB = new StringBuilder(theMap[y]);
            theSB.Remove(x, 1);
            theSB.Insert(x, 'T');
            theMap[y] = theSB.ToString();

            // minotaur
            x = minotaur[0];
            y = minotaur[1];
            theSB = new StringBuilder(theMap[y]);
            theSB.Remove(x, 1);
            theSB.Insert(x, 'M');
            theMap[y] = theSB.ToString();

            // exit
            x = exit[0];
            y = exit[1];
            theSB = new StringBuilder(theMap[y]);
            theSB.Remove(x, 1);
            theSB.Insert(x, 'X');
            theMap[y] = theSB.ToString();

            /*foreach (string str in theMap)
            {
                Console.WriteLine(str);
            }*/
        }

        public string[] GetTheMap(string newString)
        {
            SetCompressed(newString);
            SeparateToArrays();
            DecompressLevel2();
            DecompressLevel1();
            SetCharacters();

            return theMap;
        }
    }
}

