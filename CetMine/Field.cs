using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CetMine
{
    public class Field : Button
    {
        public static readonly int MineSize = 30;
        public bool HasBomb { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int NeighbourhoodBombCount { get; set; }
        public Field()
        {
            Width = MineSize;
            Height = MineSize;
        }

    }
}
