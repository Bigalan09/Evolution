using Evolution.FiniteStateMachine;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creatures
{
    class Vehicle : Entity
    {
        private float mass;
        private float max_speed;
        private float max_force;
        private float rotation = 0.0f;

        private Vector2 velocity = Vector2.Zero;
        private Vector2 to = new Vector2();
        private Vector2 Heading = new Vector2();
        private Vector2 Side = new Vector2();
        private SteeringBehaviour steeringBehaviour;
        private Vector2 steering_force;
        private StateMachine fsm = null;

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 To
        {
            get { return to; }
            set { to = value; }
        }

        public Vector2 Steering_Force
        {
            get { return steering_force; }
            set { steering_force = value; }
        }

        public StateMachine FSM
        {
            get { return fsm; }
        }

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

        public SteeringBehaviour SteeringBehaviour
        {
            get { return steeringBehaviour; }
        }

        public Vehicle(float x, float y)
            : base(x, y)
        {
            steeringBehaviour = new SteeringBehaviour(this);
            steering_force = Vector2.Zero;
            fsm = new StateMachine(this);
            fsm.ChangeState(Wander.Instance());
        }

        public override void Update(GameTime gameTime)
        {
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            if (!RotateToFacePosition())
                return;

            fsm.Update(gameTime);
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
    }
}
