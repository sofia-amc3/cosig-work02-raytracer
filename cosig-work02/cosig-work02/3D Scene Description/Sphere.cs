using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Sphere : Object3D
    {
        public Sphere() : base()
        {

        }

        public override bool intersect(Ray ray, Hit hit)
        {
            // sphere's radius is 1 and is centered on origin
            Vector3 center = new Vector3(0, 0, 0),
                    direction = ray.getDirection(),
                    distance = Vector3.subtractVectors(ray.getOrigin(), center);

            double a = Math.Pow(direction.getX(), 2) + Math.Pow(direction.getY(), 2) + Math.Pow(direction.getZ(), 2),
                   b = 2 * ((direction.getX() * distance.getX()) + (direction.getY() * distance.getY()) + (direction.getZ() * distance.getZ())),
                   c = Math.Pow(distance.getX(), 2) + Math.Pow(distance.getY(), 2) + Math.Pow(distance.getZ(), 2) - 1,
                   delta = Math.Pow(b, 2) - 4 * a * c;

            if (delta >= 0) return true;
            else return false;
        }
    }
}
