using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GenericRPG

{
    public partial class FrmCoinFrenzy : Form
    {
        private Character character;
        private Map map;
        private Game game;

        private Random rand;
        private int timeLeft;
        private double encounterChance;


        public FrmCoinFrenzy()
        {
            InitializeComponent();
            timeLeft = 60;
            encounterChance = 0;
            timeLabel.Text = " 60 seconds";
        }

        public void FrmCoinFrenzy_Load(object sender, EventArgs e)
        {
            Game.GetGame().ChangeState(GameState.COIN_HUNT);
            game = Game.GetGame();
            Character charact = game.Character;
            grpCoins.Controls.Clear();
            rand = new Random();
            timer1.Start();

            map = new Map();
            character = map.LoadMap("Resources/coinHunt.txt", grpCoins,
              str => Resources.ResourceManager.GetObject(str) as Bitmap
            );
            Width = grpCoins.Width + 25;
            Height = grpCoins.Height + 50;

            character.SetLevel(charact.Level);
            character.Health = charact.Health;
            character.Mana = charact.Mana;
            character.XP = charact.XP;
            character.GetMoney(charact.Wallet);

            game.SetCharacter(character);

            rand = new Random();

        }


        private void FrmCoinFrenzy_KeyDown(object sender, KeyEventArgs e)
        {// disallow input if we're in the middle of a fight
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
            }
            if (dir != MoveDir.NO_MOVE)
            {
                // tell the character to move and check if the move was valid
                switch (character.Move(dir))
                {
                    case Task.MOVE:
                        // check for enemy encounter
                        if (rand.NextDouble() < encounterChance)
                        {
                            encounterChance = 0.15;
                            character.GetMoney(2);
                        }
                        else
                        {
                            encounterChance += 0.10;
                        }
                        break;
                    case Task.GRAB_COIN:
                        character.GetMoney(5);
                        break;

                }
            }
        }


        private void UpdateStats()
        {
            lblWallet.Text = character.Wallet.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
                UpdateStats();
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                //MessageBox.Show("You didn't finish in time.", "Sorry!");
                Thread.Sleep(1200);
                Close();
            }
        }

        
       
    }
}
