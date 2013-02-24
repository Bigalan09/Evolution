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
            if (c is Herbivore)
            {
                if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource)).Count > 0)
                {
                    Resource r = (Resource)c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource))[0];
                    r.Amount--;
                    c.Energy++;
                    if (r.Amount <= 0)
                    {
                        r.Alive = false;
                        c.FSM.ChangeState(new Wander());
                    }
                }
            }
            else if (c is Carnivore)
            {
                if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Herbivore)).Count > 0 || c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Omnivore)).Count > 0)
                {
                    List<Entity> enemyList = c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Herbivore));
                    enemyList.AddRange(c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Omnivore)));
                    Creature enemy = (Creature)enemyList[0];
                    enemy.FSM.ChangeState(new FightCreature(c));
                    c.FSM.ChangeState(new FightCreature(enemy));
                }
            }
            else if (c is Omnivore)
            {
                if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Herbivore)).Count > 0 || c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Carnivore)).Count > 0 || c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource)).Count > 0)
                {
                    List<Entity> foodList = c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Herbivore));
                    foodList.AddRange(c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Carnivore)));
                    foodList.AddRange(c.Group.GameWorld.EntityManager.InRadius(10, c.Position, typeof(Resource)));
                    if (foodList[0] is Resource)
                    {
                        Resource r = (Resource)foodList[0];
                        r.Amount--;
                        c.Energy++;
                        if (r.Amount <= 0)
                        {
                            r.Alive = false;
                            c.FSM.ChangeState(new Wander());
                        }
                    }
                    else
                    {
                        Creature enemy = (Creature)foodList[0];
                        enemy.FSM.ChangeState(new FightCreature(c));
                        c.FSM.ChangeState(new FightCreature(enemy));
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
