using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Utils
{
    class Regulator
    {
        private float currentTime = 0f;
        private float currentCoolDownTime = 0f;
        private float updatePeriod = 0f;
        private float coolDownPeriod = 0f;

        public Regulator(float updatePeriod, float coolDownPeriod)
        {
            this.updatePeriod = updatePeriod;
            this.coolDownPeriod = coolDownPeriod;
        }

        public bool IsReady(GameTime gameTime)
        {
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentTime > updatePeriod)
            {
                currentTime = 0;
                currentCoolDownTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (currentCoolDownTime <= 0)
                {
                    currentCoolDownTime = coolDownPeriod;
                    return true;
                }
            }
            return false;
        }
    }
}
