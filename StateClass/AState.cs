﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.TileClass;
using Sprint0.ItemClass;
using Sprint0.Collision;
using Sprint0.PlayerClass;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Sprint0.enemy;
using Sprint0.DoorClass;
using Sprint0.LevelClass;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public abstract class AState
    {

        protected Game1 _game;
        protected ContentManager _content;
        protected Room _currentRoom;
        protected bool isInventory = false;
        protected bool isGameOver = false;
        protected bool isVictory = false;
        protected bool isGameState = false;
        protected bool animate = false;
        protected const int inventorySlotsWidth = 90;
        protected const int inventorySlotsHeight = 65;
        protected Vector2 boxPosition;


        public Vector2 InventoryBoxPosition
        {
            get { return boxPosition; }
            set { boxPosition = value; }
        }
        public Room CurrentRoom
        {
            get { return _currentRoom;  }
            set { _currentRoom = value; }
        }

        public bool IsInventory
        {
            get { return isInventory; }
            set { isInventory = value; }
        }

        public bool IsGameOver
        {
            get { return isGameOver; }
            set { isGameOver = value; }
        }

        public bool IsVictory
        {
            get { return isVictory; }
            set { isVictory = value; }
        }

        public bool IsGameState
        {
            get { return isGameState; }
            set { isGameOver = value; }
        }

        public AState(Game1 game, ContentManager content)
        {
            _game = game;
            _content = content;
            boxPosition = new Vector2(505, 179);
        }
        public void MoveBox(int x, int y)
        {
            //x and y are directional vectors and should only be 0, 1, or -1
            boxPosition.X += x * inventorySlotsWidth;
            boxPosition.Y += y * inventorySlotsHeight;
        }
        public abstract void loadContent();
        public abstract void update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

    }
}
