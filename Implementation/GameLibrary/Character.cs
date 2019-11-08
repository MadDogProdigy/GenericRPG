using System;
using System.Windows.Forms;

namespace GameLibrary
{
    public struct Position
    {
        public int row;
        public int col;

        /// <summary>
        /// Construct a new 2D position
        /// </summary>
        /// <param name="row">Given row or y value</param>
        /// <param name="col">Given col or x value</param>
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    /// <summary>
    /// This represents our player in our game
    /// </summary>
    public class Character : Mortal
    {
        public PictureBox Pic { get; private set; }
        private Position pos;
        public Map map;
        public bool HasWeapon { get; set; }
        public float XP { get; set; }
        public bool ShouldLevelUp { get; private set; }
        public int Wallet { get; private set; }
        public int WeaponStr=0;
        public int WeaponDef=0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="pos"></param>
        /// <param name="map"></param>
        public Character(PictureBox pb, Position pos, Map map) : base("Player 1", 1)
        {
            Pic = pb;
            this.pos = pos;
            this.map = map;
            ShouldLevelUp = false;
        }

        public void GainCoin(int coins)
        {
            Wallet += coins;

        }

        public void GainXP(float amount)
        {
            XP += amount;

            // every 100 experience points you gain a level
            if ((int)XP / 100 >= Level)
            {
                ShouldLevelUp = true;
            }
        }
        public void GetMoney(int amount)
        {
            if (amount > 0)
            {
                Wallet += amount;
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();
            ShouldLevelUp = false;
        }

        public void BackToStart()
        {
            pos.row = map.CharacterStartRow;
            pos.col = map.CharacterStartCol;
            Position topleft = map.RowColToTopLeft(pos);
            Pic.Left = topleft.col;
            Pic.Top = topleft.row;
        }

        public override void ResetStats()
        {
            base.ResetStats();
            XP = 0;
            //should not empty wallet, should just lose what gained
        }

        public Task Move(MoveDir dir)
        {
            Position newPos = pos;
            switch (dir)
            {
                case MoveDir.UP:
                    newPos.row--;
                    break;
                case MoveDir.DOWN:
                    newPos.row++;
                    break;
                case MoveDir.LEFT:
                    newPos.col--;
                    break;
                case MoveDir.RIGHT:
                    newPos.col++;
                    break;
            }
            if (map.IsValidPos(newPos))
            {
                pos = newPos;
                Position topleft = map.RowColToTopLeft(pos);
                Pic.Left = topleft.col;
                Pic.Top = topleft.row;
                return Task.MOVE;//true
            }
            else if (map.IsBossFightTime(newPos))
            {
                return Task.FIGHT_BOSS;
            }
            else if (map.IsNextLevel(newPos))
            {
                return Task.LEAVE_LEVEL;
            }
            else if (map.TryingToExit(newPos))
            {
                return Task.EXIT_GAME;
            }
            return Task.NO_TASK;//false
        }
    


        public bool DidDrop()
        {
            int result1 = 0;
            Random rnd = new Random();
            result1 = rnd.Next(30);
            if (result1 == 27)
            {
                
                return true;
            }
            else
            {
                return false;
            }

        }

        public void WeaponAttack(Mortal reciever)
        {
            Character character = Game.GetGame().Character;
            reciever.Health = reciever.Health - (character.Str *2);
        }
    }
}
