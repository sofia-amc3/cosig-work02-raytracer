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
            // sphere's radius is 1 and it's centered at the origin
            double radius = 1;
            Vector3 center = new Vector3(0, 0, 0),
                    direction = ray.getDirection(),
                    distance = Vector3.subtractVectors(ray.getOrigin(), center);

            double a = Vector3.calculateDotProduct(direction, direction),
                   b = 2 * Vector3.calculateDotProduct(direction, distance),
                   c = Vector3.calculateDotProduct(distance, distance) - Math.Pow(radius, 2),
                   delta = Math.Pow(b, 2) - 4 * a * c;

            if (delta >= 0) {
                if (delta == 0)
                {
                    double t0 = -b / 2 * a;

                    hit.setTMin(t0);
                } else if (delta > 0)
                {
                    double t0 = (-b + Math.Sqrt(delta)) / 2 * a,
                           t1 = (-b - Math.Sqrt(delta)) / 2 * a;
                   
                    hit.setTMin(Math.Min(t0, t1));
                }
                Vector3 intersectionPoint = Vector3.addVectors(ray.getOrigin(), Vector3.multiplyVectorByScalar(hit.getTMin(), ray.getDirection())),
                        normal = Vector3.normalizeVector(Vector3.subtractVectors(intersectionPoint, center)),
                        v = Vector3.subtractVectors(intersectionPoint, ray.getOrigin());
                double  t = Vector3.calculateVectorLength(v),
                        epsilon = 1.0 * Math.Pow(10, -6);

                if (t > epsilon && t < hit.getTMin())
                {
                    hit.setTMin(t);
                    hit.setFoundState(true);
                    hit.setPoint(intersectionPoint);
                    hit.setNormal(normal);
                    hit.setT(t);
                    return true;
                } else
                {
                    hit.setFoundState(false);
                    return false;
                }
            }
            else
            {
                hit.setFoundState(false);
                return false;
            }
        }
    }
}
