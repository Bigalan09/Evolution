using Evolution.Creatures;
using Evolution.Resources;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class SeekFood : State
    {

        public SeekFood()
        {
        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;
            Console.WriteLine("Seeking: " + c.Memory);
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;

            c.To = c.SteeringBehaviour.Seek(c.Memory);

            Vector2 steering_direction = c.SteeringBehaviour.Seek(c.To);
            Vector2 steering_force = truncate(steering_direction, c.Max_Force);
            Vector2 acceleration = steering_force / c.Mass;
            c.Velocity = truncate(c.Velocity + acceleration, c.Speed);
            c.Position = c.Position + c.Velocity;

            if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource)).Count > 0)
            {
                c.Memory = c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource))[0].Position;
                c.FSM.ChangeState(new EatFood());
            }
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
