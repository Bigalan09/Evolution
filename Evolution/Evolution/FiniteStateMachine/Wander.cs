using Evolution.Creatures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class Wander : State
    {
        private static State instance = null;
        private static bool canCreate = false;

        private Wander()
        {
            if (!canCreate)
                throw new NotImplementedException();
        }

        public static State Instance()
        {
            if (instance == null)
            {
                canCreate = true;
                instance = new Wander();
                canCreate = false;
            }
            return instance;
        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;

        }

        public void Execute(Entity ent)
        {
            Creature c = (Creature)ent;

            Vector2 steering_direction = c.SteeringBehaviour.Seek(new Vector2(350, 300));
            Vector2 steering_force = truncate(steering_direction, c.Max_Force);
            Vector2 acceleration = steering_force / c.Mass;
            c.Velocity = truncate(c.Velocity + acceleration, c.Max_Speed);
            c.Position = c.Position + c.Velocity;

        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;

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
