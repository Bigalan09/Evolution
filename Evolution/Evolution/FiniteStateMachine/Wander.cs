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
            c.Steering_Force = Vector2.Zero;
            c.Steering_Force += c.SteeringBehaviour.Wander();

            if (c.Energy < 90 && !c.FSM.IsInState(typeof(EatFood)))
            {
                if (c.Carrying >= 5)
                {
                    c.FSM.ChangeState(new EatFood());
                }
                if (c.Group.GameWorld.EntityManager.ResourceInRadius(c.Sight, c) != null)
                {
                    c.FSM.ChangeState(new TravelToResource(c.Group.GameWorld.EntityManager.ResourceInRadius(c.Sight, c)));
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
