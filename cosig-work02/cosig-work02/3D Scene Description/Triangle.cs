using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Triangle : Object3D
    {
        private Vector3 v1,
                        v2,
                        v3,
                        normalVector,
                        normalTransformed;
  
        public Triangle() : base()
        {
            this.v1 = new Vector3(0, 0, 0); // vertex a
            this.v2 = new Vector3(0, 0, 0); // vertex b 
            this.v3 = new Vector3(0, 0, 0); // vertex c
        }

        public Vector3 getV1() { return v1; }
        public Vector3 getV2() { return v2; }
        public Vector3 getV3() { return v3; }
        public Vector3 getNormalVector() { return normalVector; }

        public override void setTransformation(Transformation transformation)
        {
            base.setTransformation(transformation);
            calculateNormal();
        }

        public void setV1(Vector3 v1) {
            this.v1 = v1;
        }

        public void setV2(Vector3 v2) {
            this.v2 = v2;
        }

        public void setV3(Vector3 v3) {
            this.v3 = v3;
        }

        // normalize triangles
        private void calculateNormal()
        {
            Vector3 edge12 = Vector3.subtractVectors(v2, v1),
                    edge13 = Vector3.subtractVectors(v3, v1),
                    normal = Vector3.calculateCrossProduct(edge12, edge13);

            this.normalVector = Vector3.normalizeVector(normal);
            this.normalTransformed = Vector3.normalizeVector(Transformation.multiplyMatrixWithVector(this.transformation.getTransposeInverseTransformationMatrix(), this.normalVector));
        }

        public override bool intersect(Ray ray, Hit hit)
        {
            // Transform the Ray according to the object's transformation
            this.transformation.applyTransformationToRay(ray);

            // https://www.scratchapixel.com/lessons/3d-basic-rendering/ray-tracing-rendering-a-triangle/ray-triangle-intersection-geometric-solution
            // Compute plane's normal
            Vector3 origin = ray.getOriginTransformed(),
                    direction = ray.getDirectionTransformed();
            double epsilon = 1.0 * Math.Pow(10, -6);

            // Step 1: Finding P ------------------------------------------------------------------------------------------------
            // check if ray and plane are parallel
            double nDotRayDirection = Vector3.calculateDotProduct(this.normalVector, direction);
            if (Math.Abs(nDotRayDirection) < epsilon) return false; // they are parallel so they don't intersect 

            // compute d parameter (equation 2)
            double d = -Vector3.calculateDotProduct(this.normalVector, this.v1);
            // compute t (equation 3)
            double t = -(Vector3.calculateDotProduct(this.normalVector, origin) + d) / nDotRayDirection;
            // check if the triangle is in behind the ray
            if (t < 0) return false;  // the triangle is behind 

            // compute the intersection point (equation 1)
            Vector3 p_ = Vector3.addVectors(origin, Vector3.multiplyVectorByScalar(t, direction));

            // Step 2: Inside-outside test ---------------------------------------------------------------------------------------
            // edge 1
            Vector3 edge1 = Vector3.subtractVectors(this.v2, this.v1),
                    vp1 = Vector3.subtractVectors(p_, this.v1),
                    c = Vector3.calculateCrossProduct(edge1, vp1); // vector perpendicular to triangle's plane 
            if (Vector3.calculateDotProduct(this.normalVector, c) < 0) return false;  // P is on the right side 

            // edge 2
            Vector3 edge2 = Vector3.subtractVectors(this.v3, this.v2),
                    vp2 = Vector3.subtractVectors(p_, this.v2);
            c = Vector3.calculateCrossProduct(edge2, vp2);
            if (Vector3.calculateDotProduct(this.normalVector, c) < 0) return false;  // P is on the right side 

            // edge 3
            Vector3 edge3 = Vector3.subtractVectors(this.v1, this.v3),
                    vp3 = Vector3.subtractVectors(p_, this.v3);
            c = Vector3.calculateCrossProduct(edge3, vp3);
            if (Vector3.calculateDotProduct(this.normalVector, c) < 0) return false;  // P is on the right side 

            Vector3 p = this.transformation.applyTransformationToPoint(p_),
                    v = Vector3.subtractVectors(p, ray.getOrigin());
            t = Vector3.calculateVectorLength(v);

            hit.setT(t);

            // is it the nearest object? ----------------------------------------------------------------------------------------
            if (t > epsilon && t < hit.getTMin())
            {
                hit.setFoundState(true);
                hit.setTMin(t);
                hit.setPoint(p);
                hit.setNormal(this.normalTransformed);
                hit.setMaterial(this.material);
                return true;
            }
            else return false;
        }
    }
}
