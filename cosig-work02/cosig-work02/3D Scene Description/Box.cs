using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Box : Object3D
    {
        public Box() : base()
        {

        }

        public override bool intersect(Ray ray, Hit hit)
        {
            // general
            Vector3 center = new Vector3(0, 0, 0), // box is centered at origin
                    origin = ray.getOrigin(),
                    direction = ray.getDirection();
            double width = 1,  // box x
                   height = 1, // box y
                   length = 1; // box z

            // x axis ------------------------------------------------------------
            double x1 = center.getX() - width / 2,
                   x2 = center.getX() + width / 2,
                   t1x = (x1 - origin.getX()) / direction.getX(),
                   t2x = (x2 - origin.getX()) / direction.getX();

            if(t1x > t2x) // if t1 > t2, swap
            {
                double tempx = t1x;
                t1x = t2x;
                t2x = tempx;
            }

            // y axis ------------------------------------------------------------
            double y1 = center.getY() - height / 2,
                   y2 = center.getY() + height / 2,
                   t1y = (y1 - origin.getY()) / direction.getY(),
                   t2y = (y2 - origin.getY()) / direction.getY();

            if (t1y > t2y) // if t1 > t2, swap
            {
                double tempy = t1y;
                t1y = t2y;
                t2y = tempy;
            }

            // z axis ------------------------------------------------------------
            double z1 = center.getZ() - length / 2,
                   z2 = center.getZ() + length / 2,
                   t1z = (z1 - origin.getZ()) / direction.getZ(),
                   t2z = (z2 - origin.getZ()) / direction.getZ();

            if (t1z > t2z) // if t1 > t2, swap
            {
                double tempz = t1z;
                t1z = t2z;
                t2z = tempz;
            }

            return false;
        }
    }
}
