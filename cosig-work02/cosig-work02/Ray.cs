using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Ray 
    {
        private Vector3 origin, direction;
        private Ray ray;

        // Must contain a 3D point (ray's origin) and a 3D vector (ray's direction)
        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        public Ray(Ray ray)
        {
            this.ray = ray;
        }

        public Vector3 getOrigin() { return origin; }
        public Vector3 getDirection() { return direction; }

        // if t > 0.0, P(t) is after the radius' origin
        // if t < 0.0, P(t) is behind the radius' origin
        public Vector3 pointAtParameter(double t)
        {
            return Vector3.addVectors(origin, Vector3.multiplyVectorByScalar(t, direction));
        }
    }
}
