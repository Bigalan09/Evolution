using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creature
{
    class Vehicle : Entity
    {
        private float mass;
        private float max_speed;
        private float max_force;

        public float Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        
        public float Max_Force
        {
            get { return max_force; }
            set { max_force = value; }
        }
        
        public float Max_Speed
        {
            get { return max_speed; }
            set { max_speed = value; }
        }

        public Vehicle(float x, float y)
            : base(x, y)
        {

        }

    }
}
