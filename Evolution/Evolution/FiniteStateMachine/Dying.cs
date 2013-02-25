using Evolution.Creatures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class Dying : State
    {

        public Dying()
        {
        }

        public void Enter(Entity ent)
        {
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;
            c.To = c.SteeringBehaviour.Wander();

            Vector2 steering_direction = c.SteeringBehaviour.Seek(c.To);
            Vector2 steering_force = truncate(steering_direction, c.Max_Force);
            Vector2 acceleration = steering_force / c.Mass;
            c.Velocity = truncate(c.Velocity + acceleration, 0.01f);
            c.Position = c.Position + c.Velocity;

            c.Health --;
            if (c.Health <= 0)
            {
                Game1.particleEffects["Death"].Trigger(ent.Position);
                c.Alive = false;
            }
        }

        public void Exit(Entity ent)
        {
            Game1.particleEffects["Death"].Trigger(ent.Position);
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
