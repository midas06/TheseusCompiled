using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    class Program
    {
        static void Main(string[] args)
        {
            new Controller(new ConsoleView(), new Game(), new FileHandler(), new LevelBuilder()).Init();



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
