using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creature
{
    class Vehicle : Entity
    {
        private float mass;
        private float max_force;
        private float max_speed;

        public Vehicle(float x, float y, float mass, float max_force = .3f, float max_speed = .93f)
            : base(x, y)
        {
            this.mass = mass;
            this.max_force = max_force;
            this.max_speed = max_speed;
        }

    }
}
