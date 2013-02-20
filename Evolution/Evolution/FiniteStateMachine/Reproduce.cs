using Evolution.Creatures;
using Evolution.Genetics;
using Evolution.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.FiniteStateMachine
{
    class Reproduce : State
    {
        private Creature partner;
        private Regulator reg = new Regulator(5, 0);

        public Reproduce(Creature partner)
        {
            this.partner = partner;
        }

        public void Enter(Entity ent)
        {
            partner.To = ent.Position;
        }

        public void Execute(Entity ent, GameTime gameTime)
        {
            if (reg.IsReady(gameTime))
            {
                Creature c = (Creature)ent;
                c.Energy--;
                if (Randomiser.nextInt(0, 10) > 8)
                {
                    List<Chromosome> childrenChromosomes = c.Chromosome.Reproduce(partner.Chromosome);
                    c.Group.addCreature(c.Position.X, c.Position.Y, childrenChromosomes[0]);
                    c.FSM.ChangeState(new Wander());
                    partner.FSM.ChangeState(new Wander());
                }
            }
        }

        public void Exit(Entity ent)
        {
        }
    }
}
