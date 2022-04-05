﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Sprint0
{
    public class oldMan : IEnemySprite,IBoxCollider
    {

        public Texture2D Texture;

        private int currentFrame;
     
        private SpriteBatch batch;
    
        private int currentX = 400;
        private int currentY = 200;
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;
        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public Vector2 currentPos;
    

        public Vector2 position
        {
            get { return currentPos; }
            set
            {
                currentPos = value;
       

            }
        }
        public Vector2 Destination
        {
            get { return currentPos; }
            set
            {
                currentPos = value;


            }
        }

        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }
        int x = 400;
        int y = 200;
 
        public oldMan(Texture2D texture, SpriteBatch batch, Vector2 location)
        {
            Texture = texture;
            this.batch = batch;
            currentFrame = 0;
            currentX = (int)location.X;
            currentY = (int)location.Y;
            topLeft = new TopLeft((int)currentX, (int)currentY, this);
            bottomRight = new BottomRight((int)currentX, (int)currentY, this);
            isAlive = true;


        }

        public void Update()
        {
            currentPos.X = currentX;
            currentPos.Y = currentY;
        }


        public Vector2 draw()
        {

            Vector2 temp = new Vector2();
            int row = currentFrame;

            Rectangle sourceRectangle = new Rectangle(444, 266, 26, 40);
            Rectangle destinationRectangle = new Rectangle(currentX, currentY, 80, 100);

            batch.Begin();
            batch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

            batch.End();
            temp.X = currentX;
            temp.Y = currentY;
            return temp;
        }


    }
}
