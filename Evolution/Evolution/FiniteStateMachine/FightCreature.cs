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
            if (c.Alive && enemy.Alive)
            {
                if (!enemy.FSM.IsInState(typeof(FightCreature)))
                    enemy.FSM.ChangeState(new FightCreature(c));

                c.To = enemy.Position;

                if (reg.IsReady(gameTime))
                {
                    Game1.particleEffects["Sword"].Trigger(ent.Position);
                    int Attack = Randomiser.nextInt(0, c.Strength) - Randomiser.nextInt(0, enemy.Defence);
                    Attack = Math.Max(0, Math.Min(Attack, 100));
                    enemy.Health -= Attack;
                    c.Energy -= 5;
                }
            }
            if (c.Health <= 0)
            {
                c.FSM.ChangeState(new Dying());
                enemy.FSM.ChangeState(new Wander());
            }
            if (enemy.Health <= 0)
            {
                if (!(c is Herbivore))
                {
                    float remainingEnergy = 100 - c.Energy;
                    float eat = (enemy.Energy + enemy.Carrying + 50);
                    float remainingFood = eat - remainingEnergy;

                    if (eat > remainingEnergy && remainingFood > 0)
                    {
                        c.Carrying += (int)remainingFood;
                    }
                }
                enemy.FSM.ChangeState(new Dying());
                c.FSM.ChangeState(new Wander());
            }

        }

        public void Exit(Entity ent)
        {
            Creature c = (Creature)ent;
        }
    }
}
