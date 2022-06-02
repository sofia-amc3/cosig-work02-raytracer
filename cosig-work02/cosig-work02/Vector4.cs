using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Vector4
    {
        // conversion of cartesian coordinates in homogeneous 
        // vectors are normally expressed in (x, y, z, w), w <> 0.0
        // normally, for points w = 1.0 and for vectors w = 0.0

        private double x, y, z, w;

        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public double getX() { return x; }
        public double getY() { return y; }
        public double getZ() { return z; }
        public double getW() { return w; }

        public void setX(double x) { this.x = x; }
        public void setY(double y) { this.y = y; }
        public void setZ(double z) { this.z = z; }
        public void setW(double w) { this.w = w; }

        public static Vector4 convertPointToHomogenousCoordinates(Vector3 point)
        {
            return new Vector4(point.getX(), point.getY(), point.getZ(), 1.0);
        }

        public static Vector4 convertVectorToHomogenousCoordinates(Vector3 v1)
        {
            return new Vector4(v1.getX(), v1.getY(), v1.getZ(), 0.0);
        }

        public static Ray convertRayToHomogenousCoordinates(Ray ray)
        {
            Vector4 origin = convertPointToHomogenousCoordinates(ray.getOrigin()),
                    direction = convertVectorToHomogenousCoordinates(ray.getDirection());

            ray.setOrigin_v4(origin);
            ray.setDirection_v4(direction);

            return ray;
        }

        public static Vector3 convertPointToCartesianCoordinates(Vector4 point)
        {
            double w = point.getW();
            return new Vector3(point.getX()/w, point.getY()/w, point.getZ()/w);
        }

        public static Vector3 convertVectorToCartesianCoordinates(Vector4 v1)
        {
            return new Vector3(v1.getX(), v1.getY(), v1.getZ());
        }

        public static Ray convertRayToCartesianCoordinates(Ray ray)
        {
            Vector3 origin = convertPointToCartesianCoordinates(ray.getOrigin_v4()),
                    direction = convertVectorToCartesianCoordinates(ray.getDirection_v4());

            ray.setOrigin(origin);
            ray.setDirection(direction);

            return ray;
        }
    }
}
