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

        public EatFood()
        {
        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;
            if (c.Group.GameWorld.EntityManager.ResourceInRadius(15, c) == null)
            {
                c.FSM.ChangeState(new Wander());
                return;
            }
            if (c.Carrying >= 5)
            {
                float amount = Math.Min(0, (c.Carrying - (100 - c.Energy)));
                c.Carrying -= (int)amount;
                c.Energy += amount;
                if (c.Energy >= 100 || c.Carrying <= 5)
                {
                    c.FSM.ChangeState(new Wander());
                }
            }
            else
            {

                if (c is Herbivore)
                {
                    if (c.Group.GameWorld.EntityManager.ResourceInRadius(15, c) != null)
                    {
                        Resource r = (Resource) c.Group.GameWorld.EntityManager.ResourceInRadius(15, c);
                        r.Amount--;
                        c.Energy++;
                        if (c.Energy >= 100)
                            c.Carrying++;

                        if (r.Amount <= 0 || !r.Alive || r != null || c.Carrying >= c.CarryingCapacity)
                        {
                            r.Alive = false;
                            c.FSM.ChangeState(new Wander());
                        }
                    }
                }
                else if (c is Carnivore)
                {
                    if (c.Group.GameWorld.EntityManager.ResourceInRadius(15, c) != null)
                    {
                        Creature enemy = (Creature)c.Group.GameWorld.EntityManager.ResourceInRadius(15, c);
                        enemy.FSM.ChangeState(new FightCreature(c));
                        c.FSM.ChangeState(new FightCreature(enemy));
                    }
                }
                else if (c is Omnivore)
                {
                    if (c.Group.GameWorld.EntityManager.ResourceInRadius(15, c) != null)
                    {
                        if (c.Group.GameWorld.EntityManager.ResourceInRadius(15, c) is Resource)
                        {
                            Resource r = (Resource) c.Group.GameWorld.EntityManager.ResourceInRadius(15, c);
                            r.Amount--;
                            c.Energy++;
                            if (c.Energy >= 100)
                                c.Carrying++;
                            if (r.Amount <= 0 || !r.Alive || r != null || c.Carrying >= c.CarryingCapacity)
                            {
                                //r.Alive = false;
                                c.FSM.ChangeState(new Wander());
                            }
                        }
                        else
                        {
                            Creature enemy = (Creature)c.Group.GameWorld.EntityManager.ResourceInRadius(15, c);
                            enemy.FSM.ChangeState(new FightCreature(c));
                            c.FSM.ChangeState(new FightCreature(enemy));
                        }
                    }
                }
            }
            if (c.Energy >= 100)
            {
                c.FSM.ChangeState(new Wander());
            }
        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;

        }

    }
}
