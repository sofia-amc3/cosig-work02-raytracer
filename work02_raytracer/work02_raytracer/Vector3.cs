﻿using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Vector3
    {
        private double x, y, z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double getX() { return x; }
        public double getY() { return y; }
        public double getZ() { return z; }

        public void setX(double x) { this.x = x; }
        public void setY(double y) { this.y = y; }
        public void setZ(double z) { this.z = z; }

        public Vector3 addVectors(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public Vector3 subtractVectors(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public Vector3 multiplyVectorByScalar(int scalar, Vector3 v1)
        {
            return new Vector3(scalar * v1.x, scalar * v1.y, scalar * v1.z);
        }

        public double calculateDotProduct(Vector3 v1, Vector3 v2)
        {
            // in portuguese: produto escalar - resultado é um escalar
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public Vector3 calculateCrossProduct(Vector3 v1, Vector3 v2)
        {
            // in portuguese: produto vetorial - resultado é um vetor
            double newX = (v1.y * v2.z) - (v1.z * v2.y),
                   newY = (v1.z * v2.x) - (v1.x * v2.z),
                   newZ = (v1.x * v2.y) - (v1.y * v2.x);

            return new Vector3(newX, newY, newZ);
        }

        public double calculateVectorLength(Vector3 v1) 
        {
            // the length is equal to the squareroot of the dot product of the vector with itself
            return Math.Sqrt(calculateDotProduct(v1, v1));
        }

        public Vector3 normalizeVector(Vector3 v1) 
        {
            // unit vector: a vector divided by its length
            return new Vector3(v1.x / calculateVectorLength(v1), v1.y / calculateVectorLength(v1), v1.z / calculateVectorLength(v1));
        }
    }
}
