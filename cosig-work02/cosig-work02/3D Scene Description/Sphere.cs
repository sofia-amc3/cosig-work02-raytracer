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
                double t0 = 0;

                if (delta == 0) t0 = -b / 2 * a;
                else if (delta > 0)
                {
                    double t1 = (-b + Math.Sqrt(delta)) / 2 * a,
                           t2 = (-b - Math.Sqrt(delta)) / 2 * a;
                   
                    t0 = Math.Min(t1, t2);
                }
                Vector3 intersectionPoint = Vector3.addVectors(ray.getOrigin(), Vector3.multiplyVectorByScalar(t0, ray.getDirection())),
                        normal = Vector3.normalizeVector(Vector3.subtractVectors(intersectionPoint, center)),
                        v = Vector3.subtractVectors(intersectionPoint, ray.getOrigin());
                double  t = Vector3.calculateVectorLength(v),
                        epsilon = 1.0 * Math.Pow(10, -6);

                hit.setT(t);
                if (t > epsilon && t < hit.getTMin())
                {
                    hit.setTMin(t);
                    hit.setFoundState(true);
                    hit.setPoint(intersectionPoint);
                    hit.setNormal(normal);
                    hit.setMaterial(this.material);
                    return true;
                } else return false;
            }
            else return false;
        }
    }
}
