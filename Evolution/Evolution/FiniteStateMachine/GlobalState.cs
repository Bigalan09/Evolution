using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolution.Creatures;
using Evolution.Resources;
using Microsoft.Xna.Framework;
using Evolution.Utils;

namespace Evolution.FiniteStateMachine
{
    class GlobalState : State
    {
        public GlobalState()
        {

        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;
            if (!c.FSM.IsInState(typeof(EatFood)))
            {
                c.Energy -= 1;
            }
        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;
        }

    }
}
