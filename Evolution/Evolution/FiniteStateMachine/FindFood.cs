using Evolution.Creatures;
using Evolution.Resources;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class FindFood : State
    {
        private static State instance = null;
        private static bool canCreate = false;

        private FindFood()
        {
            if (!canCreate)
                throw new NotImplementedException();
        }

        public static State Instance()
        {
            if (instance == null)
            {
                canCreate = true;
                instance = new FindFood();
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

            if (c.Carrying > 0)
            {
                c.Carrying--;
                c.Energy++;
            }
            else
            {
                if (c.Group.ResourceManager.InRadius(5, c.Position).Count > 0)
                {
                    Resource res = c.Group.ResourceManager.InRadius(5, c.Position)[0];
                    c.Memory = res;
                    c.FSM.ChangeState(EatFood.Instance());

                }
                else if (c.Memory != null)
                {
                    c.To = c.Memory.Position;
                    c.SteeringBehaviour.Seek(c.Memory.Position);
                }
                c.FSM.ChangeState(Wander.Instance());
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
