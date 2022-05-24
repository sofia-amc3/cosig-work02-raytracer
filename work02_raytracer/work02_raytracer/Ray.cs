﻿using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
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

        public Vector3 pointAtParameter(double t)
        {
            return Vector3.addVectors(origin, Vector3.multiplyVectorByScalar(t, direction));
        }
    }
}