using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolution.Creatures;
using Evolution.Resources;
using Microsoft.Xna.Framework;

namespace Evolution.FiniteStateMachine
{
    class Wander : State
    {
        public Wander()
        {
        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;

            c.To = c.SteeringBehaviour.Wander();

            Vector2 steering_direction = c.SteeringBehaviour.Seek(c.To);
            Vector2 steering_force = truncate(steering_direction, c.Max_Force);
            Vector2 acceleration = steering_force / c.Mass;
            c.Velocity = truncate(c.Velocity + acceleration, c.Speed);
            c.Position = c.Position + c.Velocity;


            if (c.Energy < 75 && !c.FSM.IsInState(typeof(EatFood)))
            {
                if (c is Herbivore)
                {
                    if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource)).Count > 0)
                    {
                        c.FSM.ChangeState(new EatFood());
                    }
                } else if (c is Carnivore)
                {
                    if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Herbivore)).Count > 0 || c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Omnivore)).Count > 0)
                    {
                        c.FSM.ChangeState(new EatFood());
                    }
                } else if (c is Omnivore)
                {
                    if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Herbivore)).Count > 0 || c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Carnivore)).Count > 0 || c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource)).Count > 0)
                    {
                        c.FSM.ChangeState(new EatFood());
                    }
                }
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
