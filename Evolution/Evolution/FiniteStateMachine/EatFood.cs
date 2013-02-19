﻿using Evolution.Creatures;
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

        public EatFood()
        {
        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;
            Console.WriteLine(c.ID + " Eatting!");
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
               Creature c = (Creature)ent;
               c.Energy++;
        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;

        }

    }
}
