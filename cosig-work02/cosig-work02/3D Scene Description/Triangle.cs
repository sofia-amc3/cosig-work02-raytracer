using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Triangle : Object3D
    {
        private int indexOfTransformation,
                    indexOfMaterial;
        private Vector3 v1,
                        v2,
                        v3,
                        normalVector;
  
        public Triangle() 
        {
            this.indexOfTransformation = 0;
            this.indexOfMaterial = 0;
            this.v1 = new Vector3(0, 0, 0);
            this.v2 = new Vector3(0, 0, 0);
            this.v3 = new Vector3(0, 0, 0);
        }

        public Vector3 getV1() { return v1; }
        public Vector3 getV2() { return v2; }
        public Vector3 getV3() { return v3; }
        public Vector3 getNormalVector() { return normalVector; }

        public void setV1(Vector3 v1) { this.v1 = v1; }
        public void setV2(Vector3 v2) { this.v2 = v2; }
        public void setV3(Vector3 v3) { this.v3 = v3; }

        // normalize triangles
        public void calculateNormal()
        {
            Vector3 edge12 = Vector3.subtractVectors(v2, v1),
                    edge13 = Vector3.subtractVectors(v3, v1),
                    normal = Vector3.calculateCrossProduct(edge12, edge13);

            this.normalVector = Vector3.normalizeVector(normal);
        }

        public void calculateBarycentricCoordinates()
        {
            // Barycentric definition of a plane: P(α, β, γ) = αa + βb + γc, with α + β + γ = 1, meaning that 0 < α, β, γ < 1
            // Since α + β + γ = 1, we can write α = 1 - β - γ, and P(β, γ) = (1 - β - γ)a + βb + γc
            // This simplifies to: P(β, γ) = P(t) = a + β(b - a) + γ(c - a)
            // There is an intersection if β + γ < 1, with 0 < β and 0 < γ
           /* double[,] matrixA = new double[3, 3];

            matrixA[0, 0] = (ax - bx);
            matrixA[0, 1] = 0.0;
            matrixA[0, 2] = 0.0;

            matrixA[1, 0] = 0.0;
            matrixA[1, 1] = 1.0;
            matrixA[1, 2] = 0.0;

            matrixA[2, 0] = 0.0;
            matrixA[2, 1] = 0.0;
            matrixA[2, 2] = 1.0;*/
        }

        public bool intersect(Ray ray, Hit hit)
        {
            // checks if ray is intersecting the object in analysis


            // checks if distance hit.t from the intersection point to the ray's origin is > 0.0
            // and if hit.t < hit.tmin


            return true; // if intersection is found
        }
    }
}
