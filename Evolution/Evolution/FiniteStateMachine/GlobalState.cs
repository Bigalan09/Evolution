﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolution.Creatures;
using Evolution.Resources;
using Microsoft.Xna.Framework;
using Evolution.Utils;
using Evolution.Genetics;

namespace Evolution.FiniteStateMachine
{
    class GlobalState : State
    {
        private Regulator reg = new Regulator(2, 0);
        private Regulator ageReg = new Regulator(6, 0);
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
            if (!(c.FSM.IsInState(typeof(Dying))) && (c.Energy <= 0 || c.Age > c.Chromosome.GetGene(PropertyType.Age_Death).Value))
            {
                c.FSM.ChangeState(new Dying());
            }
            else
            {
                if (ageReg.IsReady(gameTime))
                {
                    c.Age++;
                }
                if (reg.IsReady(gameTime))
                {
                    if (!c.FSM.IsInState(typeof(EatFood)))
                    {
                        float energy = (float)((c.Max_Speed) + (c.Carrying / 100));
                        c.Energy -= energy;
                    }
                    if ((!c.FSM.IsInState(typeof(EatFood))) && c.Energy < 1)
                    {
                        c.FSM.ChangeState(new Dying());
                    }
                    if (c.Energy > 35 && c.Age > 4 && !c.FSM.IsInState(typeof(Reproduce)) && !c.FSM.IsInState(typeof(FightCreature))) // need fitness function here
                    {
                        List<Entity> partnerList = c.Group.GameWorld.EntityManager.InRadius(20, c.Position, c.GetType());
                        if (partnerList.Count > 0)
                        {
                            foreach (Creature partner in partnerList)
                            {
                                if (partner.Energy > 35 && partner.Age > 4 && !partner.FSM.IsInState(typeof(Reproduce)) && !c.FSM.IsInState(typeof(FightCreature))) // need fitness function here
                                {
                                    partner.FSM.ChangeState(new Reproduce(c));
                                    c.FSM.ChangeState(new Reproduce(partner));
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;
        }

    }
}
