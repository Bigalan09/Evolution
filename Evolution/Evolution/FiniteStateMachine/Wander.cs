﻿using System;
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

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;
            c.Energy -= c.Max_Speed / 100;
            c.To = c.SteeringBehaviour.Wander();

            Vector2 steering_direction = c.SteeringBehaviour.Seek(c.To);
            Vector2 steering_force = truncate(steering_direction, c.Max_Force);
            Vector2 acceleration = steering_force / c.Mass;
            c.Velocity = truncate(c.Velocity + acceleration, c.Max_Speed);
            c.Position = c.Position + c.Velocity;

            if (c.Energy < 20)
            {
                c.FSM.ChangeState(FindFood.Instance());
            }
            if (c.Group.ResourceManager.InRadius(5, c.Position).Count > 0)
            {
                Resource res = c.Group.ResourceManager.InRadius(5, c.Position)[0];
                // Change State
                if (c.Carrying < 10)
                {
                    c.FSM.ChangeState(EatFood.Instance());
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
