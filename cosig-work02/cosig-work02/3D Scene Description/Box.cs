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
            // calculate intersection distance t1 and t2
            Vector3 origin = ray.getOrigin(), // R
                    direction = ray.getDirection(), // D
                    x1 = new Vector3(0, 0, 0),
                    x2 = new Vector3(1, 1, 1),
                    invertedDirection = new Vector3(1 / direction.getX(), 1 / direction.getY(), 1 / direction.getZ()),
                    t1 = Vector3.multiplyVectorByVector(Vector3.subtractVectors(x1, origin), invertedDirection),
                    t2 = Vector3.multiplyVectorByVector(Vector3.subtractVectors(x2, origin), invertedDirection);

            double t1Length = Vector3.calculateVectorLength(t1),
                   t2Length = Vector3.calculateVectorLength(t2);

            if(t1Length > t2Length) // if t1 > t2, swap
            {
                Vector3 temp = t1;
                t1 = t2;
                t2 = temp;
            }

            // if tnear > tfar, box is missed
            // if tfar < 0, box is behind
            // if box survived tests, report intersection at tnear
            return false;
        }
    }
}
