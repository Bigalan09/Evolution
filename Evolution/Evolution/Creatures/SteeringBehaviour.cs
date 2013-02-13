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
        private Vehicle vehicle;

        private float wanderAngle = 0.1f;
        private float wanderJitter = 0.05f;
        private float wanderDistance = 10f;
        private float wanderRadius = 20f;

        public SteeringBehaviour(Vehicle veh)
        {
            vehicle = veh;
        }

        public Vector2 Seek(Vector2 targetPos)
        {
            Vector2 desiredVelocity = Vector2.Normalize(targetPos - vehicle.Position) * vehicle.Max_Speed;
            return (desiredVelocity - vehicle.Velocity);
        }

        public Vector2 Flee(Vector2 targetPos)
        {
            Vector2 desiredVelocity = Vector2.Normalize(vehicle.Position - targetPos) * vehicle.Max_Speed;
            return (desiredVelocity - vehicle.Velocity);
        }

        public Vector2 FleeWithinRadius(Vector2 targetPos, float radius)
        {
            if (Vector2.DistanceSquared(vehicle.Position, targetPos) > radius)
            {
                return Flee(targetPos);
            }
            return Vector2.Zero;
        }

        public Vector2 Wander()
        {
            wanderAngle += RandomClamped() * wanderJitter;

            Vector2 circlePosition = vehicle.Position + (vehicle.Velocity * wanderDistance);
            float x = (float)Math.Cos(wanderAngle);
            float y = (float)Math.Sin(wanderAngle);
            Vector2 circleTarget = new Vector2(x, y) * wanderRadius;
            return circlePosition + circleTarget;
        }

        public static float RandomClamped()
        {
            return (float)(Randomiser.nextDouble() - Randomiser.nextDouble());
        }
        /*
            wanderAngle += RandomClamped() * wanderJitter;

            Vector2 circlePosition = Position + (Velocity * wanderDistance);
            float x = (float)Math.Cos(wanderAngle);
            float y = (float)Math.Sin(wanderAngle);
            Vector2 circleTarget = new Vector2(x, y) * wanderRadius;
            to = circlePosition + circleTarget;

            if (!RotateToFacePosition())
                return;
        */
    }
}
