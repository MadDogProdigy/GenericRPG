using System.IO;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Collections.Generic;

namespace GameLibrary
{
    public class CoinHunt
    {
        private int[,] layout;
        private Random rand;
        private const int TOP_PAD = 10;
        private const int BOUNDARY_PAD = 5;
        private const int BLOCK_SIZE = 50;

        public int CharacterStartRow { get; private set; }
        public int CharacterStartCol { get; private set; }
        private int NumRows { get { return layout.GetLength(0); } }
        private int NumCols { get { return layout.GetLength(1); } }

        public string LevelName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapFile"></param>
        /// <param name="grpMap"></param>
        /// <param name="LoadImg"></param>
        /// <returns></returns>
        public void LoadMap(GroupBox grpMap, Func<string, Bitmap> LoadImg)
        {
            rand = new Random();
            LevelName = "Resources/coinHunt.txt";

            // declare and initialize locals
            int top = TOP_PAD;
            int left = BOUNDARY_PAD;
            Character character = Game.GetGame().Character;
            List<string> mapLines = new List<string>();

            // read from map file
            using (FileStream fs = new FileStream(LevelName, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        mapLines.Add(line);
                        line = sr.ReadLine();
                    }
                }
            }

            // load map file into layout and create PictureBox objects
            layout = new int[mapLines.Count, mapLines[0].Length];
            int chance = (int)Math.Round(rand.NextDouble() * (mapLines.Count * mapLines[0].Length));
            int i = 0;
            foreach (string mapLine in mapLines)
            {
                int j = 0;
                foreach (char c in mapLine)
                {
                    int val = c - '0';
                    if (chance == (i*mapLines.Count+j) && val==0)
                    {
                        val = 6;
                        chance = (int)Math.Round(rand.NextDouble() * (mapLines.Count * mapLines[0].Length));
                    }
                    layout[i, j] = val;
                    PictureBox pb = CreateMapCell(val, LoadImg);
                    if (pb != null)
                    {
                        pb.Top = top;
                        pb.Left = left;
                        grpMap.Controls.Add(pb);
                    }
                    if (val == 2)
                    {
                        //CharacterStartRow = i;
                        //CharacterStartCol = j;
                        character.BackToStart();
                    }
                    left += BLOCK_SIZE;
                    j++;
                }
                left = BOUNDARY_PAD;
                top += BLOCK_SIZE;
                i++;
            }

            // resize Group
            grpMap.Width = NumCols * BLOCK_SIZE + BOUNDARY_PAD * 2;
            grpMap.Height = NumRows * BLOCK_SIZE + TOP_PAD + BOUNDARY_PAD;
            grpMap.Top = 5;
            grpMap.Left = 5;

            // initialize for game
            Game.GetGame().ChangeState(GameState.COIN_HUNT);
        }

        private PictureBox CreateMapCell(int legendValue, Func<string, Bitmap> LoadImg)
        {
            PictureBox result = null;
            switch (legendValue)
            {
                // walkable
                case 0:
                    break;

                // wall
                case 1:
                    result = new PictureBox()
                    {
                        BackgroundImage = LoadImg("wall"),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Width = BLOCK_SIZE,
                        Height = BLOCK_SIZE
                    };
                    break;

                // character
                case 2:
                    result = new PictureBox()
                    {
                        BackgroundImage = LoadImg("character"),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Width = BLOCK_SIZE,
                        Height = BLOCK_SIZE
                    };
                    break;
                case 6:
                    result = new PictureBox()
                    {
                        BackgroundImage = LoadImg("money"),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Width = BLOCK_SIZE,
                        Height = BLOCK_SIZE
                    };
                    break;
            }
            return result;
        }

        public bool IsCoin(Position pos)
        {
            return (layout[pos.row, pos.col] == 6);
        }

        private void addCoin()
        {
            
        }

        private void removeCoin() { 
        }
    }
}
