﻿using Evolution.Creatures;
using Evolution.Genetics;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using ProjectMercury;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class Reproduce : State
    {
        private Creature partner;
        private Regulator reg = new Regulator(3, 0);

        public Reproduce(Creature partner)
        {
            this.partner = partner;
        }

        public void Enter(Entity ent)
        {
            partner.To = ent.Position;
            Game1.particleEffects["Heart"].Trigger(ent.Position);
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            if (reg.IsReady(gameTime))
            {
                Creature c = (Creature)ent;
                c.Energy--;
                partner.Energy--;
                if (Randomiser.nextDouble() < Game1.Parameters.Reproduction)
                {
                    Game1.particleEffects["Heart"].Trigger(ent.Position);
                    List<Chromosome> childrenChromosomes = c.Chromosome.Reproduce(partner.Chromosome);
                    if (Randomiser.nextDouble() < Game1.Parameters.Mutation)
                    {
                        childrenChromosomes[0].Mutate();
                    }
                    c.Group.addCreature(c.Position.X, c.Position.Y, childrenChromosomes[0], ((partner.Energy + c.Energy) / 2));
                    if (Randomiser.nextDouble() < 0.5)
                    {
                        if (Randomiser.nextDouble() < Game1.Parameters.Mutation)
                        {
                            childrenChromosomes[1].Mutate();
                        }
                        c.Group.addCreature(c.Position.X, c.Position.Y, childrenChromosomes[1]);
                    }
                    c.Energy = (c.Energy / 2) - 5;
                    partner.Energy = (partner.Energy / 2) - 5;
                }
                c.FSM.ChangeState(new Wander());
                partner.FSM.ChangeState(new Wander());
            }
        }

        public void Exit(Entity ent)
        {
        }
    }
}
