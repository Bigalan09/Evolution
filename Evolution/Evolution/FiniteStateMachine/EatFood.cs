using Evolution.Creatures;
using Evolution.Resources;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class EatFood : State
    {
        private static State instance = null;
        private static bool canCreate = false;
        private float currentTime = 0;
        private float duration = 1f;

        private EatFood()
        {
            if (!canCreate)
                throw new NotImplementedException();
        }

        public static State Instance()
        {
            if (instance == null)
            {
                canCreate = true;
                instance = new EatFood();
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
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime >= duration)
            {
                currentTime -= duration;
                Creature c = (Creature)ent;
                c.Velocity = Vector2.Zero;
                c.Position = c.Position + c.Velocity;

                if (c.Group.ResourceManager.InRadius(5, c.Position).Count > 0)
                {
                    Resource res = c.Group.ResourceManager.InRadius(5, c.Position)[0];
                    while (c.Energy < 100)
                    {
                        if (res.Amount > 0)
                        {
                            c.Energy++;
                            res.Amount--;
                        }
                        break;
                    }
                    while (c.Carrying < 100)
                    {
                        if (res.Amount > 0)
                        {
                            c.Carrying++;
                            res.Amount--;
                        }
                        break;
                    }
                    c.FSM.ChangeState(FindFood.Instance());
                }
            }
        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;

        }

    }
}
