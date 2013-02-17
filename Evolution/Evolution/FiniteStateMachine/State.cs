using Evolution.Creatures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    interface State
    {
        void Enter(Entity ent);
        void Execute(Entity ent, GameTime gameTime);
        void Exit(Entity ent);
    }
}
