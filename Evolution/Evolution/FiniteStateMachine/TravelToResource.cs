using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolution.Creatures;
using Microsoft.Xna.Framework;
using Evolution.Resources;

namespace Evolution.FiniteStateMachine
{
    class TravelToResource : State
    {
        private Entity resource;

        public TravelToResource(Entity resource)
        {
            this.resource = resource;
        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            // Seek food position then check bounding radius
            Creature c = (Creature)ent;
            if (resource is Vehicle)
            {
                c.Steering_Force += c.SteeringBehaviour.Pursuit((Vehicle)resource);
                c.Steering_Force += c.SteeringBehaviour.Arrive(this.resource.Position);
            }
            else
            {
                c.Steering_Force += c.SteeringBehaviour.Arrive(this.resource.Position);
            }

            if ((c.Position + c.Origin - resource.Position).Length() < 15) {
                //c.Velocity = Vector2.Zero;
                c.Steering_Force = Vector2.Zero;
            }

            if ((resource is Resource) && ((Resource)resource).Amount < 1)
                c.FSM.ChangeState(new Wander());

            if ((c.Position + c.Origin - resource.Position).Length() > c.Sight || !resource.Alive || resource == null)
            {
                c.FSM.ChangeState(new Wander());
                return;
            }
            else
            {
                if ((c.Position + c.Origin - resource.Position).Length() <= 15)
                {
                    c.FSM.ChangeState(new EatFood());
                }
            }
        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;
        }

    }
}
