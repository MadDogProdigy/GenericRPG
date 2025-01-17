﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary {

  public enum GameState {
    LOADING,
    TITLE_SCREEN,
    ON_MAP,
    FIGHTING,
    DEAD,
    BOSS_FIGHT,
    COIN_HUNT,
    }

  public class Game {
    private static Game game;
    private int NumLevels = 5;

    public Character Character { get; private set; }
    public GameState State { get; private set; }

    public int Level { get; private set; }

    private Game() {
      State = GameState.LOADING;
            Level = 1;
    }

    public static Game GetGame() {
      if (game == null)
        game = new Game();
      return game;
    }

    public void ChangeState(GameState newState) {
      State = newState;
    }

    public void SetCharacter(Character character) {
      Character = character;
    }

    public void NextLevel()
        {
            if (Level < NumLevels)
            {
                Level++;

            }
        }

        public void PreviousLevel()
        {
            if (Level > 1)
            {
                Level--;
            }
        }
  }
}
