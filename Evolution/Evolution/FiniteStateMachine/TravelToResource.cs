﻿using System;
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
            c.To = this.resource.Position - this.resource.Origin;
            
            Vector2 steering_direction = c.SteeringBehaviour.Seek(c.To);
            Vector2 steering_force = truncate(steering_direction, c.Max_Force);
            Vector2 acceleration = steering_force / c.Mass;
            c.Velocity = truncate(c.Velocity + acceleration, c.Speed);

            if ((c.Position + c.Origin - resource.Position + resource.Origin).Length() < 10)
                c.Velocity = Vector2.Zero;

            c.Position = c.Position + c.Velocity;

            if ((resource is Resource) && ((Resource)resource).Amount < 1)
                c.FSM.ChangeState(new Wander());

            if ((c.Position + c.Origin - resource.Position + resource.Origin).Length() >= c.Sight || !resource.Alive || resource == null)
            {
                c.FSM.ChangeState(new Wander());
                return;
            }
            else
            {
                if ((c.Position + c.Origin - resource.Position).Length() <= 10)
                {
                    c.FSM.ChangeState(new EatFood());
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
