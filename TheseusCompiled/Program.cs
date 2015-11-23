using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TheseusCompiled
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Splash());*/
            //new Controller(new ConsoleView(), new Game(), new FileHandler(), new LevelBuilder()).Init();

            FileHandler filer = new FileHandler();
            LevelBuilder builder = new LevelBuilder();
            /*Game theGame = new Game();
            filer.Init();
            filer.SetMap(0, "Map 1.");

            theGame.SetFiler(filer);
            theGame.SetMap();

            foreach (Tile tile in theGame.GetMap())
            {
                Console.WriteLine(tile.Coordinate);
            }
            

            Tile theTile = theGame.GetMap()[3, 2];
            Console.WriteLine(theTile.Coordinate);
            Console.WriteLine(theGame.GetMap().GetLength(0));
            Console.WriteLine(theTile.IsOuter(Direction.Left));

            int i = 105;

            Console.WriteLine(i / 50);*/
            /*
            Point p = new Point(4, 4);
            builder.Init(p);
            p = new Point(3, 0);
            builder.SelectTile(p);
            builder.Exit();
            builder.EastWall();

            p = new Point(0, 3);
            builder.SelectTile(p);
            builder.SetTheseus();
            p = new Point(0, 2);
            builder.SelectTile(p);
            builder.SetMinotaur();

            Console.WriteLine(builder.Test());

            builder.Clear();

            Console.WriteLine(builder.Test());

            
            /*filer.Init();
            filer.SetMap(0, "Map 6");
            filer.GetNextMap();*/

            //Console.WriteLine(MapCreator.ObjectsToString(filer.GetMap().Tiles, filer.GetMap().TheTheseus, filer.GetMap().TheMinotaur));
            Loader loader = new Loader();
            Compressor compressor = new Compressor();
            Decompressor decompressor;

            /*string str = filer.LoadTextFile(@"H:\2015\semester 2\PR 283 C#\Theseus\level1.txt");
            Console.WriteLine(str);

            string[] stra = loader.ToStringArray(str);
            compressor.LoadMap(stra);
            compressor.FindSpecialCharacters();
            compressor.CompressLevel1();
            compressor.SetTheResult();
            Console.WriteLine(compressor.GetLvl1());
            Saver saver = new Saver();
            saver.SetFileName("lvl1c1");
            saver.SaveSingle(@"H:\2015\semester 2\PR 283 C#\Theseus", compressor.GetLvl1());*/

            string newFile = filer.LoadTextFile(@"H:\2015\semester 2\PR 283 C#\Theseus\lvl1c1.txt");
            decompressor = new Decompressor();
            
            decompressor.SetCompressed(newFile);


            //try
            //{
                decompressor.SeparateToArrays();
            //}

                decompressor.DecompressLevel1();
                decompressor.SetCharacters();
            


            /*int x = 0;
            foreach (string st in stra)
            {
                Console.WriteLine(x.ToString() + st);
                Console.WriteLine(st.Length);
                x++;
            }

            Bridger bridger = new Bridger();

            AMap newMap = new AMap();
            newMap.Map = stra;

            newMap = bridger.Convert(newMap);

            Console.WriteLine(newMap.TheMinotaur.Coordinate);
            Console.WriteLine(newMap.TheTheseus.Coordinate);*/



            //filer.IsValid(@"H:\2015\semester 2\PR 283 C#\Theseus\level1.txt");

            Console.ReadKey();



        }
    }
}
/*FileHandler filer = new FileHandler();
            Game game = new Game();

            game.SetFiler(filer);
            

            //AMap theMap;

            filer.Init();
            Console.WriteLine(filer.GetMapList(1));
            filer.SetMap(1, Console.ReadLine());
            //theMap = filer.GetMap();


            // Console.WriteLine(MapCreator.ObjectsToString(theMap.Tiles, theMap.TheTheseus, theMap.TheMinotaur));
            game.SetMap();

            Console.WriteLine(MapCreator.ObjectsToString(game.GetMap(), game.GetTheseus(), game.GetMinotaur()));



            Console.ReadKey();*/
/*LevelBuilder builder = new LevelBuilder();
FileHandler filer = new FileHandler();

Point thePoint = new Point(3, 4);
filer.Init();

builder.Init(thePoint);
builder.SelectTile(0, 2);
//builder.SetTheseus();
builder.SetMinotaur();
builder.NorthWall();

builder.SelectTile(2, 2);
//builder.SetMinotaur();
builder.SetTheseus();

builder.SelectTile(2, 3);
builder.Exit();

filer.NewUserMap("test map 2", builder.Export());


Console.ReadKey();

filer.Init();
Console.WriteLine(filer.GetMapList(1));
filer.SetMap(1, Console.ReadLine());
AMap theMap = filer.GetMap();
Console.WriteLine(MapCreator.ObjectsToString(theMap.Tiles, theMap.TheTheseus, theMap.TheMinotaur));

Console.ReadKey();*/
