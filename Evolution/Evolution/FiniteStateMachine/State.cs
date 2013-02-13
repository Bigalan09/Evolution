using Evolution.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    interface State
    {
        void Enter(Entity ent);
        void Execute(Entity ent);
        void Exit(Entity ent);
    }
}
