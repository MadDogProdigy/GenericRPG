﻿using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmMap : Form {
    private Character character;
    private Map map;
    private Game game;

    private Random rand;
    private double encounterChance;

    public FrmMap() {
      InitializeComponent();
    }

    private void FrmMap_Load(object sender, EventArgs e) {
      game = Game.GetGame();

      map = new Map();
      character = map.LoadMap("Resources/level.txt", grpMap, 
        str => Resources.ResourceManager.GetObject(str) as Bitmap
      );
      Width = grpMap.Width + 25;
      Height = grpMap.Height + 50;
      game.SetCharacter(character);

      rand = new Random();
      encounterChance = 0.15;
    }

    private void FrmMap_KeyDown(object sender, KeyEventArgs e) {
      // disallow input if we're in the middle of a fight
      if (game.State == GameState.FIGHTING) return;

      MoveDir dir = MoveDir.NO_MOVE;
      switch (e.KeyCode) {
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
      //case Keys.S:
      //    DialogResult result = MessageBox.show("Do you want to save the current game state?","SAVE GAME",MessageBoxButtons.YesNo);
      //    if(result == DialogResult.Yes) {
      //        Game.Save();
      //    }
      //    break;
      //case Keys.Q:
      //    DialogResult result = MessageBox.show("You are about to quit the game. Are you sure?","QUIT GAME",MessageBoxButtons.YesNo);
      //    if(result == DialogResult.Yes) {
      //        Game.Quit();
      //    }
      //    break;
      //case Keys.I:
      //    Character.GetStats();
      //    break;
      }
      if (dir != MoveDir.NO_MOVE) {
        // tell the character to move and check if the move was valid
        bool didValidMove = character.Move(dir);
        if (didValidMove)
        {
          // check for enemy encounter
          if (rand.NextDouble() < encounterChance)
          {
            encounterChance = 0.15;
            Game.GetGame().ChangeState(GameState.FIGHTING);
          }
          else
          {
            encounterChance += 0.10;
          }
        }

        if (game.State == GameState.FIGHTING) {
          FrmArena frmArena = new FrmArena();
          frmArena.Show();//frmArena.Show();
        }
      }
    }

    }
}
