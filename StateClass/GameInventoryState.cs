﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.StateClass
{
    public class GameInventoryState : AState
    {
        private const int WIDTH = 1024;
        private const int HEIGHT = 960;
        private const int MAX_HEART_COUNT = 5;
        private Game1 _game;
        private ContentManager _content;
        private Texture2D screen;
        private LinkInventory _inventory;
        private LevelManager _levelManager;
        private int locationSquareX;
        private int locationSquareY;

        private Rectangle heartSourceRect;
        private Rectangle halfHeartSourceRect;
        private Rectangle emptyHeartSourceRect;
        private Rectangle timesSymbolSourceRect;
        private Rectangle mapSourceRect;
        private Rectangle mapDesignSourceRect;
        private Rectangle compassSourceRect;
        private Rectangle redBoxSourceRect;
        private Rectangle blueBoxSourceRect;
        private Rectangle swordSourceRect;
        private Rectangle boomerangSourceRect;
        private Rectangle bombSourceRect;
        private Rectangle arrowSourceRect;
        private Rectangle bowSourceRect;

        private Rectangle currentHeartNeeded;
        private Rectangle rupeeNumberDestRect;
        private Rectangle bombNumberDestRect;
        private Rectangle keyNumberDestRect;
        private Rectangle levelNumberDestRect;
        private Rectangle slotADestRect;
        private Rectangle slotBDestRect;
        private Rectangle mapDestRect;
        private Rectangle mapDesignDestRect;
        private Rectangle compassDestRect;
        private Rectangle otherMapSourceRect;
        private Rectangle otherMapDestRect;
        private Rectangle locationSquareSourceRect;
        private Rectangle locationSquareDestRect;
        private Rectangle boxDestRect;
        private Rectangle currentB_SlotItem;

        const int heartWidth = 64;
        const int heartHeight = 73;
        const int spaceBetweenHearts = 8;

        const int numberWidth = 33;
        const int numberHeight = 37;
        const int spaceBetweenNumbers = 5;

        const int mapWidth = 39;
        const int mapAndCompassHeight = 83;
        const int compassWidth = 74;
        const int mapDesignHeightAndWidth = 275;
        const int otherMapWidth = 278;
        const int otherMapHeight = 200;

        const int locationSquareSize = 20;

        const int slotWidth = 46;
        const int slotHeight = 85;
        const int inventorySlotsWidth = 78;
        const int inventorySlotsHeight = 65;
        const int spaceBetweenSlots = 10;

        const int colorBoxesWidth = 80;
        const int colorBoxesHeight = 82;

        const int swordWidth = 41;
        const int swordHeight = 85;

        const int boomerangWidth = 40;
        const int boomerangHeight = 60;

        const int bombWidth = 50;
        const int bombHeight = 75;

        const int arrowWidth = 40;
        const int arrowHeight = 85;

        const int bowWidth = 50;
        const int bowHeight = 90;

        const int heartAndNumberYSourceLocation = 1142;
        const int timesSymbolYSourceLocation = 1178;
        const int compassAndMapYSourceLocation = 1059;
        const int mapDesignYSourceLocation = 1215;
        const int numberXSourceLocation = 208;
        const int mapXSourceLocation = 403;
        const int compassXSourceLocation = 457;
        const int otherMapXSourceLocation = 288;
        const int locationSquareXSourceLocation = 395;
        const int locationSquareYSourceLocation = 1440;
        const int itemsRowYSourceLocation = 961;
        const int swordXSourceLocation = 173;
        const int blueSquareXSourceLocation = 82;
        const int boomerangXSourceLocation = 315;
        const int bombXSourceLocation = 173;
        const int arrowXSourceLocation = 475;
        const int bowXSourceLocation = 556;
        const int boomerangYSourceLocation = 972;

        const int heartXDestLocation = 706;
        const int slotA_XDestLocation = 602;
        const int slotB_XDestLocation = 506;
        const int numberXDestLocation = 384;
        const int mapAndCompassXDestLocation = 180;
        const int mapDesignXDestLocation = 500;
        const int levelNumberXDestLocation = 135;
        const int otherMapXDestLocation = 26;
        const int inventorySlotsXDestLocation = 505;

        const int inventorySlotsYDestLocation = 179;
        const int heartYDestLocation = 854;
        const int slotsYDestLocation = 815;
        const int rupeeYDestLocation = 781;
        const int keyYDestLocation = 854;
        const int bombYDestLocation = 890;
        const int mapYDestLocation = 420;
        const int compassYDestLocation = 590;
        const int mapDesignYDestLocation = 370;
        const int levelNumberYDestLocation = 707;
        const int otherMapYDestLocation = 748;



        public GameInventoryState(Game1 game, ContentManager content) : base(game, content)
        {
            _game = game;
            _content = content;
            _levelManager = LevelManager.Instance;
            _inventory = _levelManager.Player.Inventory;
            locationSquareX = _inventory.MapLocationX;
            locationSquareY = _inventory.MapLocationY;

            heartSourceRect = new Rectangle((heartWidth * 2) + (spaceBetweenHearts * 2), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            halfHeartSourceRect = new Rectangle((heartWidth * 1) + (spaceBetweenHearts * 1), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            emptyHeartSourceRect = new Rectangle((heartWidth * 0) + (spaceBetweenHearts * 0), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            timesSymbolSourceRect = new Rectangle(numberXSourceLocation, timesSymbolYSourceLocation, numberWidth, numberHeight);
            mapSourceRect = new Rectangle(mapXSourceLocation, compassAndMapYSourceLocation, mapWidth, mapAndCompassHeight);
            mapDesignSourceRect = new Rectangle(0,mapDesignYSourceLocation, mapDesignHeightAndWidth, mapDesignHeightAndWidth);
            compassSourceRect = new Rectangle(compassXSourceLocation, compassAndMapYSourceLocation, compassWidth, mapAndCompassHeight);
            otherMapSourceRect = new Rectangle(otherMapXSourceLocation, mapDesignYSourceLocation, otherMapWidth, otherMapHeight);
            locationSquareSourceRect = new Rectangle(locationSquareXSourceLocation, locationSquareYSourceLocation, locationSquareSize, locationSquareSize);
            redBoxSourceRect = new Rectangle(0, itemsRowYSourceLocation, colorBoxesWidth, colorBoxesHeight);
            blueBoxSourceRect = new Rectangle(blueSquareXSourceLocation, itemsRowYSourceLocation, colorBoxesWidth, colorBoxesHeight);
            swordSourceRect = new Rectangle(swordXSourceLocation, itemsRowYSourceLocation, swordWidth, swordHeight);
            boomerangSourceRect = new Rectangle(boomerangXSourceLocation, boomerangYSourceLocation, boomerangWidth, boomerangHeight);
            bombSourceRect = new Rectangle(bombXSourceLocation, itemsRowYSourceLocation, bombWidth, bombHeight);
            arrowSourceRect = new Rectangle(arrowXSourceLocation, itemsRowYSourceLocation, arrowWidth, arrowHeight);
            bowSourceRect = new Rectangle(bowXSourceLocation, itemsRowYSourceLocation, bowWidth, bowHeight);

            rupeeNumberDestRect = new Rectangle(numberXDestLocation, rupeeYDestLocation, numberWidth, numberHeight);
            bombNumberDestRect = new Rectangle(numberXDestLocation, bombYDestLocation, numberWidth, numberHeight);
            keyNumberDestRect = new Rectangle(numberXDestLocation, keyYDestLocation, numberWidth, numberHeight);
            levelNumberDestRect = new Rectangle(levelNumberXDestLocation, levelNumberYDestLocation, numberWidth, numberHeight);
            slotADestRect = new Rectangle(slotA_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            slotBDestRect = new Rectangle(slotB_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            mapDestRect = new Rectangle(mapAndCompassXDestLocation, mapYDestLocation, mapWidth, mapAndCompassHeight);
            mapDesignDestRect = new Rectangle(mapDesignXDestLocation, mapDesignYDestLocation, mapDesignHeightAndWidth, mapDesignHeightAndWidth);
            compassDestRect = new Rectangle(mapAndCompassXDestLocation, compassYDestLocation, compassWidth, mapAndCompassHeight);
            otherMapDestRect = new Rectangle(otherMapXDestLocation, otherMapYDestLocation, otherMapWidth, otherMapHeight);
            locationSquareDestRect = new Rectangle(locationSquareX, locationSquareY, locationSquareSize, locationSquareSize);
            currentB_SlotItem = _inventory.CurrentB_Slot;

        }
        public override void loadContent()
        {
            screen = _content.Load<Texture2D>("Inventory");
            isInventory = true;
        }

        public override void update(GameTime gameTime)
        {
            _game.MouseController.handleInput();
            _game.KeyboardController.handleInput();

        }

        public override void Draw(GameTime gameTime)
        {
            _inventory.Update();
            Rectangle screenDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle screenSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);

            _game.SpriteBatch.Begin();

            _game.SpriteBatch.Draw(
                     screen,
                     screenDestRect,
                     screenSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
            _game.SpriteBatch.Draw(screen, rupeeNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, bombNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, keyNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, levelNumberDestRect, new Rectangle(numberXSourceLocation + (_inventory.LevelNumber * numberWidth) + (_inventory.LevelNumber * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            _game.SpriteBatch.Draw(screen, slotADestRect, swordSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, slotBDestRect, currentB_SlotItem, Color.White);


            int remainingNumberSpaces = 2;
            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.RupeeCount / 10) * numberWidth) + ((_inventory.RupeeCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.RupeeCount % 10) * numberWidth) + ((_inventory.RupeeCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.KeyCount / 10) * numberWidth) + ((_inventory.KeyCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.KeyCount % 10) * numberWidth) + ((_inventory.KeyCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.BombCount / 10) * numberWidth) + ((_inventory.BombCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.BombCount % 10) * numberWidth) + ((_inventory.BombCount % 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            int remainingHalfHearts = _inventory.HeartCount;
            for (int i = 0; i < MAX_HEART_COUNT; i++)
            {
                if (i < _inventory.HeartContainerCount)
                {
                    if (remainingHalfHearts >= 2)
                    {
                        currentHeartNeeded = heartSourceRect;
                        remainingHalfHearts -= 2;
                    }
                    else if (remainingHalfHearts == 1)
                    {
                        currentHeartNeeded = halfHeartSourceRect;
                        remainingHalfHearts -= 1;
                    }
                    else
                    {
                        currentHeartNeeded = emptyHeartSourceRect;
                    }
                    _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), currentHeartNeeded, Color.White);
                }
                else
                {
                    _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), new Rectangle(heartWidth, 0, heartWidth, heartHeight), Color.Black);
                }
            }

            if(_inventory.Compass == true)
            {
                _game.SpriteBatch.Draw(screen,compassDestRect, compassSourceRect, Color.White);

            }

            if (_inventory.Map == true)
            {
                _game.SpriteBatch.Draw(screen, mapDestRect, mapSourceRect, Color.White);
                _game.SpriteBatch.Draw(screen, mapDesignDestRect, mapDesignSourceRect, Color.White);
                _game.SpriteBatch.Draw(screen, otherMapDestRect, otherMapSourceRect, Color.White);
            }
            _game.SpriteBatch.Draw(screen, new Rectangle(_inventory.MapLocationX, _inventory.MapLocationY, locationSquareSize, locationSquareSize), locationSquareSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, new Rectangle(_inventory.MapSquareLocationX, _inventory.MapSquareLocationY, locationSquareSize, locationSquareSize), locationSquareSourceRect, Color.White);

            _game.SpriteBatch.End();
        }
    }
}
