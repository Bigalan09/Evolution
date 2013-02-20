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
            c.Health--;
            if (c.Health <= 0)
            {
                c.Alive = false;
            }
        }

        public void Exit(Entity ent)
        {
        }

    }
}
