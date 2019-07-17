using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CetMine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Field[,] fields;
        int BombCount = 10;
        int RowSize = 10;
        int ColumnSize = 10;

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Width = Field.MineSize * 12;
            this.Height = Field.MineSize * 14;
            PlaceFields();
            PlaceBombs();
        }

        private void PlaceBombs()
        {
            var random = new Random();
            int[] r = new int[10];
            for (int i = 0; i < BombCount; i++)
            {
                int rr = random.Next(10);
                int rc = random.Next(10);
                Field f = fields[rr, rc];
                if (f.HasBomb) { i--; continue; }

                f.HasBomb = true;
                f.Text = "X";

                var neightbours = FindNeighborhoods(f);
                foreach (var item in neightbours)
                {
                    if (!item.HasBomb)
                    {
                        item.NeighbourhoodBombCount++;
                        item.Text = item.NeighbourhoodBombCount.ToString();
                    }
                }


            }
        }

        void PlaceFields()
        {
            fields = new Field[10, 10];
            for (int r = 0; r < ColumnSize; r++)
            {
                for (int c = 0; c < RowSize; c++)
                {
                    var f = new Field();
                    f.Name = "Btn" + c.ToString() + r.ToString();
                    f.Location = new Point(c * Field.MineSize, r * Field.MineSize);
                    f.Row = r;
                    f.Column = c;
                    fields[r, c] = f;
                    mineArea.Controls.Add(f);
                }
            }
        }

        List<Field> FindNeighborhoods(Field f)
        {
            var neighbours = new List<Field>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (f.Row + i < 0 || f.Column + j < 0 || f.Row + i >= RowSize || f.Column + j >= ColumnSize || (j == 0 && i == 0))
                        continue;

                    Field neighbour = fields[i + f.Row, j + f.Column];
                    neighbours.Add(neighbour);
                }
            }
            return neighbours;

        }

    }
}
