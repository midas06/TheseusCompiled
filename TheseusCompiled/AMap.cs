using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusCompiled
{
    public class AMap
    {
        public string Name { get; set; }
        public string[] Map { get; set; }
        public Tile[,] Tiles { get; set; }
        public Theseus TheTheseus { get; set; }
        public Minotaur TheMinotaur { get; set; }
    }
}
