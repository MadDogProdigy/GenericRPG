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
        public float XP { get; set; }
        public bool ShouldLevelUp { get; private set; }
        public int Wallet { get; private set; }

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

        public void GainCoin(int amount)
        {
            Wallet += amount;
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
            if(amount > 0)
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
        {//bool
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
    }


}
