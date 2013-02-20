using Evolution.Creatures;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class FightCreature : State
    {
        private Creature enemy;
        private Regulator reg = new Regulator(3, 0);

        public FightCreature(Creature enemy)
        {
            this.enemy = enemy;
        }

        public void Enter(Entity ent)
        {
            Creature c = (Creature)ent;
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;
            c.To = enemy.Position;
            if (c.Group.GameWorld.EntityManager.InRadius(10, c.Position, enemy.GetType()).Count > 0)
            {
                if (reg.IsReady(gameTime))
                {
                    int Attack = Randomiser.nextInt(0, c.Strength) - Randomiser.nextInt(0, enemy.Defence);
                    enemy.Health -= Attack;
                    c.Energy--;
                    if (enemy.Health <= 1)
                    {
                        enemy.FSM.ChangeState(new Dying());
                        c.Energy = enemy.Energy + 10;
                        c.FSM.ChangeState(new Wander());
                    }
                }
            }
            else
            {
                c.FSM.ChangeState(new Wander());
                enemy.FSM.ChangeState(new Wander());
            }
        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;
        }
    }
}
