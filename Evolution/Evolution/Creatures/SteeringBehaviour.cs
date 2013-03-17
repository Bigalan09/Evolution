using Evolution.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolution.Creatures
{
    class SteeringBehaviour
    {
        private Vehicle entity;
        private float slowingRadius = 150;
        private float CIRCLE_DISTANCE = 500f;
        private float CIRCLE_RADIUS = 100f;
        private float ANGLE_CHANGE = 1f;
        public float wanderAngle = 0;

        private Vehicle Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        public SteeringBehaviour(Vehicle entity)
        {
            Entity = entity;
        }

        public Vector2 Seek(Vector2 target)
        {
            Vector2 desiredVelocity = Vector2.Normalize(target - entity.Position) * Entity.Max_Speed;
            return (desiredVelocity - Entity.Velocity);
        }

        public Vector2 Flee(Vector2 target)
        {
            Vector2 desiredVelocity = Vector2.Normalize(entity.Position - target) * Entity.Max_Speed;
            return (desiredVelocity - Entity.Velocity);
        }

        public Vector2 Pursuit(Vehicle target)
        {
            Vector2 distance = target.Position - Entity.Position;
            int T = (int)(distance.Length() / Entity.Max_Speed);
            Vector2 futurePosition = target.Position + target.Velocity * T;
            return Seek(futurePosition);
        }

        public Vector2 Evade(Vehicle target)
        {
            Vector2 distance = target.Position - Entity.Position;
            int T = (int)(distance.Length() / Entity.Max_Speed);
            Vector2 futurePosition = target.Position + target.Velocity * T;
            return Flee(futurePosition);
        }

        public Vector2 Arrive(Vector2 target)
        {
            Vector2 desiredVelocity = (target - Entity.Position);
            desiredVelocity.Normalize();
            float distance = Vector2.Distance(target, Entity.Position);
            if (distance > slowingRadius)
            {
                desiredVelocity = desiredVelocity * Entity.Max_Speed;
            }
            else
            {
                desiredVelocity = desiredVelocity * Entity.Max_Speed * (distance / slowingRadius);
            }

            return (desiredVelocity - Entity.Velocity);
        }

        public Vector2 Wander()
        {
            Vector2 circleCenter = Entity.Velocity;
            circleCenter.Normalize();
            circleCenter = circleCenter * (CIRCLE_DISTANCE);

            Vector2 displacement = new Vector2(0, -1);
            displacement = displacement * (CIRCLE_RADIUS);
            displacement = setAngle(displacement, wanderAngle);

            wanderAngle += (float)(Randomiser.nextDouble() * ANGLE_CHANGE - ANGLE_CHANGE * .5);

            return (circleCenter + displacement);
        }

        public Vector2 Truncate(Vector2 original, float max)
        {
            if (original.Length() > max)
            {
                original.Normalize();

                original *= max;
            }
            return original;
        }

        public Vector2 setAngle(Vector2 original, float value)
        {
            float len = original.Length();
            original.X = (float)(Math.Cos(value) * len);
            original.Y = (float)(Math.Sin(value) * len);
            return original;
        }

        public float getAngle(Vector2 original)
        {
            return (float)Math.Atan2(original.Y, original.X);
        }
    }
}
