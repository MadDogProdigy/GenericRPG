using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenericRPG

{
    public partial class FrmCoinFrenzy : FrmMap
    {
        private Character character;
        private Map map;
        private Game game;
        private Random rand;
        private double encounterChance; //might not need

        public FrmCoinFrenzy()
        {
            InitializeComponent();
        }

        public void FrmCoinFrenzy_Load(object sender, EventArgs e)
        {
            game = Game.GetGame();
            grpCoins.Controls.Clear();
            map = new Map();
            character = map.LoadMap("Resources/coinHunt.txt", grpCoins,
                str => Resources.ResourceManager.GetObject(str) as Bitmap
                );
            Width = grpCoins.Width + 25;
            Height = grpCoins.Height + 50;
            game.SetCharacter(character);
            rand = new Random();

        }
        private void FrmCoinFrenzy_KeyDown(object sender, KeyEventArgs e)
        {
            // disallow input if we're in the middle of a fight
            if (game.State == GameState.FIGHTING) return;

            MoveDir dir = MoveDir.NO_MOVE;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    dir = MoveDir.LEFT;
                    break;
                case Keys.Right:
                    dir = MoveDir.RIGHT;
                    break;
                case Keys.Up:
                    dir = MoveDir.UP;
                    break;
                case Keys.Down:
                    dir = MoveDir.DOWN;
                    break;
                case Keys.I:
                    FrmStats stats = new FrmStats();
                    stats.Show();
                    break;
            }
            if (dir != MoveDir.NO_MOVE)
            {// tell the character to move and check if the move was valid
                if (character.Move(dir) == Task.GRAB_COIN)
                {
                }
            }
            }
    }
}
