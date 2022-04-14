﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprint0.LevelClass;

namespace Sprint0
{
    public class ProjectilePlayerBoomerang : IProjectile,IBoxCollider
    {
        private Vector2 position;
        private Vector2 direction;

        private Texture2D texture;
        private SpriteBatch batch;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private const int RETURN_FRAMES = 15;

        private int frame;
        private float rotation;
        // Used by the Player class to know if the projectile is still in animation
        private Boolean isRunning;
        private readonly TopLeft topLeft;
        private readonly BottomRight bottomRight;


        public Boolean IsRunning
        {
            get { return isRunning; }
            set { isRunning = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; UpdateCollisionBox(); }
        }
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; }
        }


        public TopLeft TopLeft
        {
            get { return topLeft; }
        }
        public BottomRight BottomRight
        {
            get { return bottomRight; }
        }

        public ProjectilePlayerBoomerang(Texture2D texture, SpriteBatch batch, Vector2 position, Vector2 direction)
        {
            this.texture = texture;
            this.batch = batch;
            this.position = position;
            this.direction = direction;

            topLeft = new TopLeft((int)position.X, (int)position.Y, this);
            bottomRight = new BottomRight((int)position.X + 25, (int)position.Y + 25, this);

            sourceRect = new Rectangle(97, 280, 12, 19);

            isRunning = true;
            rotation = 0f;
            frame = 0;
        }

        public int GetSign(int distance)
        {
            if (distance < 0) return 1;
            return -1;
        }

        public void GetRotation(Vector2 direction)
        {
            if (direction.X == 0 && direction.Y > 0)
            {
                rotation = (float)Math.PI / 2f;
            }
            else if (direction.X == 0 && direction.Y < 0)
            {
                rotation = (float)Math.PI * 3f / 2f;
            }
            else if (direction.X > 0 && direction.Y == 0)
            {
                rotation = 0f;
            }
            else if (direction.X < 0 && direction.Y == 0)
            {
                rotation = (float)Math.PI;
            }
        }

        public void Update()
        {
            GetRotation(direction);
            Console.WriteLine("Projectile: "+position.X + " player:" + LevelManager.Instance.Player.Position.X);
            int PlayerProjectileDistanceX = (int) (LevelManager.Instance.Player.Position.X - position.X);
            int PlayerProjectileDistanceY = (int)(LevelManager.Instance.Player.Position.Y - position.Y);

            if (IsRunning)
            {
                destinationRect = new Rectangle((int)position.X, (int)position.Y, 24, 38);
                frame++;

                if (frame < 10)
                {
                    IsRunning = true;
                    position.X += direction.X * 5f;
                    position.Y += direction.Y * 5f;
                }
                else if (frame >= 10 && frame < 20)
                {
                    position.X += direction.X * 5f;
                    position.Y += direction.Y * 5f;
                    sourceRect = new Rectangle(107, 280, 12, 19);
                }
                else if (frame >= 20 && frame < 30)
                {
                    position.X += direction.X * 3f;
                    position.Y += direction.Y * 3f;
                    sourceRect = new Rectangle(124, 280, 12, 19);
                }
                else if (frame >= 30 && frame < 35)
                {
                    position.X += direction.X * 0f;
                    position.Y += direction.Y * 0f;
                    sourceRect = new Rectangle(97, 280, 12, 19);
                }
                else if (frame >= 35 && frame < 45)
                {
                    position.X += GetSign(PlayerProjectileDistanceX) * -5f;
                    position.Y += GetSign(PlayerProjectileDistanceY) * -5f;
                    sourceRect = new Rectangle(107, 280, 12, 19);
                }
                else if (frame >= 45 && frame < 55)
                {
                    position.X += GetSign(PlayerProjectileDistanceX) * -5f;
                    position.Y += GetSign(PlayerProjectileDistanceY) * -5f;
                    sourceRect = new Rectangle(122, 280, 12, 19);
                }
                else if (frame > 55 & frame < 65)
                {
                    position.X += GetSign(PlayerProjectileDistanceX) * -5f;
                    position.Y += GetSign(PlayerProjectileDistanceY) * -5f;
                    sourceRect = new Rectangle(97, 280, 12, 19);
                }

                if (frame > 65)
                {
                    frame = 35;
                }
            }
            else
            {
                sourceRect = new Rectangle(400, 400, 0, 0);
            }
            UpdateCollisionBox();

        }

        public void Draw() 
        {
            Draw(0, 0);
        }

        public void Draw(int xOffset, int yOffset)
        {

            Rectangle destination = new Rectangle(destinationRect.X + xOffset, destinationRect.Y + yOffset, destinationRect.Width, destinationRect.Height);

            batch.Begin();

            batch.Draw(
                 texture,
                 destination,
                 sourceRect,
                Color.White,
                rotation,
                new Vector2(sourceRect.Width / 2, sourceRect.Height / 2),
                SpriteEffects.None,
                0f
                );
            batch.End();
        }

        private void UpdateCollisionBox()
        {
            topLeft.X = (int)position.X;
            topLeft.Y = (int)position.Y;
            bottomRight.X = (int)position.X + 24;
            BottomRight.Y = (int)position.Y + 28;
        }

    }



}


