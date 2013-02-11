using Evolution.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creature
{
    class Vehicle : Entity
    {
        private float mass;
        private float max_speed;
        private float max_force;
        private float wanderAngle = 0;
        private float wanderJitter = 0.05f;
        private float wanderDistance = 10f;
        private float wanderRadius = 20f;
        private float rotation = 0.0f;

        private Vector2 velocity = Vector2.Zero;

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        private Vector2 to = new Vector2();
        private Vector2 Heading = new Vector2();
        private Vector2 Side = new Vector2();

        public float Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        
        public float Max_Force
        {
            get { return max_force; }
            set { max_force = value; }
        }
        
        public float Max_Speed
        {
            get { return max_speed; }
            set { max_speed = value; }
        }

        public Vehicle(float x, float y)
            : base(x, y)
        {
            wanderAngle = (float)((RandomClamped() + 1.2) * 2f);
        }

        public override void Update(GameTime gameTime)
        {
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            wanderAngle += RandomClamped() * wanderJitter;

            Vector2 circlePosition = Position + (Velocity * wanderDistance);
            float x = (float)Math.Cos(wanderAngle);
            float y = (float)Math.Sin(wanderAngle);
            Vector2 circleTarget = new Vector2(x, y) * wanderRadius;
            to = circlePosition + circleTarget;

            if (!RotateToFacePosition())
                return;

            Vector2 steering_direction = Seek(to);
            Vector2 steering_force = truncate(steering_direction, max_force);
            Vector2 acceleration = steering_force / mass;
            Velocity = truncate(Velocity + acceleration, max_speed);
            Position = Position + Velocity;

            if (Velocity.LengthSquared() > 0.00000001)
            {
                Heading = new Vector2((float)Math.Cos(rotation),
                                        (float)Math.Sin(rotation));
                Side = new Vector2(-Heading.Y, Heading.X);
            }
            Wrap();
            base.Update(gameTime);
        }

        private bool RotateToFacePosition()
        {
            // current bot position
            Vector2 from = Position;
            // current position the bot is steering towards
            // grab the max turn speed in radians
            float maxRate = MathHelper.ToRadians((float)0.2f);

            if (to != Position)
            {
                float x = to.X - from.X;
                float y = to.Y - from.Y;
                rotation = -((float)Math.Atan2(x, y) + MathHelper.Pi);
            }

            return true;
        }

        public Vector2 Seek(Vector2 targetPos)
        {
            Vector2 DesiredVel = Vector2.Normalize(targetPos - Position) * Max_Speed;

            return (DesiredVel - Velocity);
        }

        public static float RandomClamped()
        {
            return (float)(Randomiser.nextDouble() - Randomiser.nextDouble());
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, rotation - 1.5f, Origin, 1.0f, SpriteEffects.None, 0f);
            base.Draw(spriteBatch, gameTime);
        }

        private void Wrap()
        {
            float x = Position.X;
            float y = Position.Y;

            if (Position.X < 0 - Texture.Width)
            {
                x = Game1.ScreenBounds.Width;
            }
            else if (Position.X > Game1.ScreenBounds.Width)
            {
                x = 0 - Texture.Width;
            }

            if (Position.Y < 0 - Texture.Height)
            {
                y = Game1.ScreenBounds.Height;
            }
            else if (Position.Y > Game1.ScreenBounds.Height)
            {
                y = 0 - Texture.Height;
            }
            Position = new Vector2(x, y);
        }

        private Vector2 truncate(Vector2 v, float max_value)
        {
            float s = 0f;
            s = max_value / v.Length();
            s = (s < 1.0f) ? 1.0f : s;
            return new Vector2(v.X * s, v.Y * s);
        }
    }
}
