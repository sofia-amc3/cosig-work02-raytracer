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
            this.transformation.applyTransformationToRay(ray); // Ray's Transformation
            double radius = 1;
            Vector3 center = new Vector3(0, 0, 0),
                    direction = ray.getDirectionTransformed(),
                    distance = Vector3.subtractVectors(ray.getOriginTransformed(), center);

            double a = Vector3.calculateDotProduct(direction, direction),
                   b = 2 * Vector3.calculateDotProduct(direction, distance),
                   c = Vector3.calculateDotProduct(distance, distance) - Math.Pow(radius, 2),
                   delta = Math.Pow(b, 2) - 4 * a * c;

            if (delta >= 0) {
                double t0 = 0;

                if (delta == 0) t0 = -b / (2 * a);
                else if (delta > 0)
                {
                    double q;

                    if (b > 0) q = (-b + Math.Sqrt(delta)) / (2 * a);
                    else q = (-b - Math.Sqrt(delta)) / (2 * a);

                    double t1 = q / a,
                           t2 = c / q;

                    if(t1 > t2)
                    {
                        double temp = t1;
                        t1 = t2;
                        t2 = temp;
                    }

                    if(t1 < 0)
                    {
                        t1 = t2; //if t1 is negative, let's use t2 instead 
                        if (t1 < 0) return false; // both t1 and t2 are negative
                    }

                    t0 = t1;
                }

                Vector3 p_ = Vector3.addVectors(ray.getOriginTransformed(), Vector3.multiplyVectorByScalar(t0, direction)),
                        p = this.transformation.applyTransformationToPoint(p_),
                        normal_ = Vector3.normalizeVector(Vector3.subtractVectors(p_, center)),
                        normal = Transformation.multiplyMatrixWithVector(this.transformation.getTransposeInverseTransformationMatrix(), normal_),
                        v = Vector3.subtractVectors(p, ray.getOrigin());
                double  t = Vector3.calculateVectorLength(v),
                        epsilon = 1.0 * Math.Pow(10, -6);

                hit.setT(t);

                if (t > epsilon && t < hit.getTMin())
                {
                    hit.setFoundState(true);
                    hit.setTMin(t);
                    hit.setPoint(p);
                    hit.setNormal(Vector3.normalizeVector(normal));
                    hit.setMaterial(this.material);
                    return true;
                } else return false;
            }
            else return false;
        }
    }
}
