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
            Game1.particleEffects["Sword"].Trigger(ent.Position);
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            Creature c = (Creature)ent;
            c.To = enemy.Position;
            if ((c.Position + c.Origin - enemy.Position).Length() <= 15)
            {

                if (!enemy.FSM.IsInState(typeof(FightCreature)))
                    enemy.FSM.ChangeState(new FightCreature(c));

                if (reg.IsReady(gameTime))
                {
                    Game1.particleEffects["Sword"].Trigger(ent.Position);

                    int Attack = Randomiser.nextInt(0, c.Strength) - Randomiser.nextInt(0, enemy.Defence);
                    enemy.Health -= Attack;
                    c.Energy--;
                    if (enemy.Health <= 0)
                    {
                        enemy.FSM.ChangeState(new Dying());
                        if (!(c is Herbivore))
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
