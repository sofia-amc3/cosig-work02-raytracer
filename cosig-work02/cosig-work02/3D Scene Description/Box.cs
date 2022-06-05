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
            double[,] transformationMatrix = this.transformation.getTransformationMatrix();
            Vector3 oobPosition = new Vector3(transformationMatrix[3, 0], transformationMatrix[3, 1], transformationMatrix[3, 2]);
            Vector3 delta = Vector3.subtractVectors(oobPosition, ray.getOrigin());

            // general
            Vector3 center = this.transformation.getTranslate(),
                    origin = ray.getOrigin(),
                    direction = ray.getDirection(),
                    scale = this.transformation.getScale();
            double width = scale.getX(),
                   height = scale.getY(),
                   length = scale.getZ(),
                   tmin = 0,
                   tmax = 0;

            if (direction.getX() == 0 || direction.getY() == 0 || direction.getZ() == 0) return false;

            // test 01: maintain tmin and tmax -----------------------------------
            // x axis ------------------------------------------------------------
            Vector3 xAxis =  new Vector3(transformationMatrix[0, 0], transformationMatrix[0, 1], transformationMatrix[0, 2]);
            double e = Vector3.calculateDotProduct(xAxis, delta),
                   f = Vector3.calculateDotProduct(direction, xAxis);

            double x1 = (e - 1) / f, // center.getX() - width / 2,
                   x2 = (e + 1) / f, // center.getX() + width / 2,
                   t1x = (x1 - origin.getX()) / direction.getX(),
                   t2x = (x2 - origin.getX()) / direction.getX();

            if(t1x > t2x) // if t1 > t2, swap
            {
                double tempx = t1x;
                t1x = t2x;
                t2x = tempx;
            }

            tmin = t1x;
            tmax = t2x;

            // y axis ------------------------------------------------------------
            Vector3 yAxis = new Vector3(transformationMatrix[1, 0], transformationMatrix[1, 1], transformationMatrix[1, 2]);
            e = Vector3.calculateDotProduct(yAxis, delta);
            f = Vector3.calculateDotProduct(direction, yAxis);

            double y1 = (e - 1) / f, // center.getX() - width / 2,
                   y2 = (e + 1) / f, // center.getX() + width / 2,
                   t1y = (y1 - origin.getY()) / direction.getY(),
                   t2y = (y2 - origin.getY()) / direction.getY();

            if (t1y > t2y) // if t1 > t2, swap
            {
                double tempy = t1y;
                t1y = t2y;
                t2y = tempy;
            }

            // compare distances
            if (tmin > t2y || t1y > tmax) return false;

            // assign new tmin and tmax
            if (t1y > tmin) tmin = t1y;
            if (t2y < tmax) tmax = t2y;

            // z axis ------------------------------------------------------------
            Vector3 zAxis = new Vector3(transformationMatrix[2, 0], transformationMatrix[2, 1], transformationMatrix[2, 2]);
            e = Vector3.calculateDotProduct(zAxis, delta);
            f = Vector3.calculateDotProduct(direction, zAxis);

            double z1 = (e - 1) / f, // center.getX() - width / 2,
                   z2 = (e + 1) / f, // center.getX() + width / 2,
                   t1z = (z1 - origin.getZ()) / direction.getZ(),
                   t2z = (z2 - origin.getZ()) / direction.getZ();

            if (t1z > t2z) // if t1 > t2, swap
            {
                double tempz = t1z;
                t1z = t2z;
                t2z = tempz;
            }

            // compare distances
            if (tmin > t2z || t1z > tmax) return false;

            // assign new tmin and tmax
            if (t1z > tmin) tmin = t1z;
            if (t2z < tmax) tmax = t2z;

            // test 02 -----------------------------------------------------------
            if (tmin > tmax) return false; // box is missed
            if (tmax < 0) return false; // box is behind ray's origin

            // is it the nearest object? -----------------------------------------
            Vector3 p = Vector3.addVectors(ray.getOrigin(), Vector3.multiplyVectorByScalar(tmin, ray.getDirection())),
                   // normal = Vector3.normalizeVector(Vector3.subtractVectors(p, center)),
                    v = Vector3.subtractVectors(p, ray.getOrigin());
            double t = Vector3.calculateVectorLength(v);

            // normal calculation
            //if(Math.Abs())

            if (t < hit.getTMin())
            {
                hit.setFoundState(true);
                hit.setTMin(t);
                hit.setPoint(p);
                //hit.setNormal(Vector3.normalizeVector(normal));
                hit.setMaterial(this.material);
                return true;
            }
            else return false;
        }
    }
}
