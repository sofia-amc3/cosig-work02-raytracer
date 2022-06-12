﻿using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Box : Object3D
    {
        public Box() : base()
        {

        }

        private Vector3 calculateNormal(Vector3 intersectionPoint, double boxSize) // intersection point of ray with box
        {
            double x = 0,
                   y = 0,
                   z = 0,
                   intersectionX = Math.Round(intersectionPoint.getX(), 3),
                   intersectionY = Math.Round(intersectionPoint.getY(), 3),
                   intersectionZ = Math.Round(intersectionPoint.getZ(), 3);
            boxSize = boxSize / 2;

            if (intersectionX == -boxSize) x = -boxSize;
            else if (intersectionX == boxSize) x = boxSize;
            else if (intersectionY == -boxSize) y = -boxSize;
            else if (intersectionY == boxSize) y = boxSize;
            else if (intersectionZ == -boxSize) z = -boxSize;
            else if (intersectionZ == boxSize) z = boxSize;

            return Vector3.normalizeVector(new Vector3(x, y, z));
        }

        public override bool intersect(Ray ray, Hit hit)
        {
            this.transformation.applyTransformationToRay(ray); // Ray's Transformation
            // general
            Vector3 center = new Vector3(0, 0, 0),
                    origin = ray.getOriginTransformed(),
                    direction = ray.getDirectionTransformed();
            double size = 1,
                   tmin = 0,
                   tmax = 0;

            if (direction.getX() == 0 || direction.getY() == 0 || direction.getZ() == 0) return false;

            // test 01: maintain tmin and tmax -----------------------------------
            // x axis ------------------------------------------------------------
            double x1 = center.getX() - size / 2,
                   x2 = center.getX() + size / 2,
                   t1x = (x1 - origin.getX()) / direction.getX(),
                   t2x = (x2 - origin.getX()) / direction.getX();

            if (t1x > t2x) // if t1 > t2, swap
            {
                double tempx = t1x;
                t1x = t2x;
                t2x = tempx;
            }

            tmin = t1x;
            tmax = t2x;

            // y axis ------------------------------------------------------------
            double y1 = center.getY() - size / 2,
                   y2 = center.getY() + size / 2,
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
            double z1 = center.getZ() - size / 2,
                   z2 = center.getZ() + size / 2,
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
            Vector3 p_ = Vector3.addVectors(origin, Vector3.multiplyVectorByScalar(tmin, direction)),
                    p = this.transformation.applyTransformationToPoint(p_),
                    normal_ = calculateNormal(p_, size),
                    normal = Transformation.multiplyMatrixWithVector(this.transformation.getTransposeInverseTransformationMatrix(), normal_),
                    v = Vector3.subtractVectors(p, ray.getOrigin());
            double t = Vector3.calculateVectorLength(v),
                   epsilon = 1.0 * Math.Pow(10, -6);

            if (t > epsilon && t < hit.getTMin())
            {
                hit.setFoundState(true);
                hit.setTMin(t);
                hit.setPoint(p);
                hit.setNormal(Vector3.normalizeVector(normal));
                hit.setMaterial(this.material);
                return true;
            }
            else return false;
        }
    }
}