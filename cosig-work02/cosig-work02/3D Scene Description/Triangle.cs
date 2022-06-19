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
            this.normalTransformed = Vector3.normalizeVector(this.transformation.applyTransformationToVector(this.normalVector));
        }

        private double getMatrixADeterminant(Ray ray)
        {
            double[,] matrixA = new double[3, 3];

            matrixA[0, 0] = this.v1.getX() - this.v2.getX();
            matrixA[0, 1] = this.v1.getX() - this.v3.getX();
            matrixA[0, 2] = ray.getDirectionTransformed().getX();
            matrixA[1, 0] = this.v1.getY() - this.v2.getY();
            matrixA[1, 1] = this.v1.getY() - this.v3.getY();
            matrixA[1, 2] = ray.getDirectionTransformed().getY();
            matrixA[2, 0] = this.v1.getZ() - this.v2.getZ();
            matrixA[2, 1] = this.v1.getZ() - this.v3.getZ();
            matrixA[2, 2] = ray.getDirectionTransformed().getZ();

            return Transformation.calculateDeterminant(matrixA);
        }

        private double getBeta(Ray ray, double detA)
        {
            double[,] matrix = new double[3, 3];

            matrix[0, 0] = this.v1.getX() - ray.getOriginTransformed().getX(); 
            matrix[0, 1] = this.v1.getX() - this.v3.getX();
            matrix[0, 2] = ray.getDirectionTransformed().getX();
            matrix[1, 0] = this.v1.getY() - ray.getOriginTransformed().getY();
            matrix[1, 1] = this.v1.getY() - this.v3.getY();
            matrix[1, 2] = ray.getDirectionTransformed().getY();
            matrix[2, 0] = this.v1.getZ() - ray.getOriginTransformed().getZ();
            matrix[2, 1] = this.v1.getZ() - this.v3.getZ();
            matrix[2, 2] = ray.getDirectionTransformed().getZ();

            return Transformation.calculateDeterminant(matrix) / detA;
        }

        private double getGamma(Ray ray, double detA)
        {
            double[,] matrix = new double[3, 3];

            matrix[0, 0] = this.v1.getX() - this.v2.getX();
            matrix[0, 1] = this.v1.getX() - ray.getOriginTransformed().getX();
            matrix[0, 2] = ray.getDirectionTransformed().getX();
            matrix[1, 0] = this.v1.getY() - this.v2.getY();
            matrix[1, 1] = this.v1.getY() - ray.getOriginTransformed().getY();
            matrix[1, 2] = ray.getDirectionTransformed().getY();
            matrix[2, 0] = this.v1.getZ() - this.v2.getZ();
            matrix[2, 1] = this.v1.getZ() - ray.getOriginTransformed().getZ();
            matrix[2, 2] = ray.getDirectionTransformed().getZ();

            return Transformation.calculateDeterminant(matrix) / detA;
        }

        private double getT(Ray ray, double detA)
         {
             double[,] matrix = new double[3, 3];

             matrix[0, 0] = this.v1.getX() - this.v2.getX();
             matrix[0, 1] = this.v1.getX() - this.v3.getX();
             matrix[0, 2] = this.v1.getX() - ray.getOriginTransformed().getX();
             matrix[1, 0] = this.v1.getY() - this.v2.getY();
             matrix[1, 1] = this.v1.getY() - this.v3.getY();
             matrix[1, 2] = this.v1.getY() - ray.getOriginTransformed().getY();
             matrix[2, 0] = this.v1.getZ() - this.v2.getZ();
             matrix[2, 1] = this.v1.getZ() - this.v3.getZ();
             matrix[2, 2] = this.v1.getZ() - ray.getOriginTransformed().getZ();

             return Transformation.calculateDeterminant(matrix) / detA;
         }

        private Vector3 calculateIntersectionPoint(double beta, double gamma)
        {
            // P(t) = a + β(b - a) + γ(c - a)
            Vector3 bminusa = Vector3.subtractVectors(this.v2, this.v1);
            Vector3 cminusa = Vector3.subtractVectors(this.v3, this.v1);
            Vector3 betaMultiplies = Vector3.multiplyVectorByScalar(beta, bminusa);
            Vector3 gammaMultiplies = Vector3.multiplyVectorByScalar(gamma, cminusa);
            Vector3 final = Vector3.addVectors(Vector3.addVectors(this.v1, betaMultiplies), gammaMultiplies);

            return final;
        }

        public override bool intersect(Ray ray, Hit hit)
        {
            // Transform the Ray according to the object's transformation
            this.transformation.applyTransformationToRay(ray); 

            // Barycentric definition of a plane: P(α, β, γ) = αa + βb + γc, with α + β + γ = 1, meaning that 0 < α, β, γ < 1
            // Since α + β + γ = 1, we can write α = 1 - β - γ, and P(β, γ) = (1 - β - γ)a + βb + γc
            // This simplifies to: P(β, γ) = P(t) = a + β(b - a) + γ(c - a)
            // There is an intersection if β + γ < 1, with 0 < β and 0 < γ
            double detA = getMatrixADeterminant(ray),
                   beta = getBeta(ray, detA),
                   epsilon = 1.0 * Math.Pow(10, -6);

            // checks if ray is intersecting the object in analysis
            if (beta <= -epsilon) return false;

            double gamma = getGamma(ray, detA);

            if (gamma <= -epsilon) return false;

            if (beta + gamma < 1.0 + epsilon)
            {
                Vector3 p_ = calculateIntersectionPoint(beta, gamma),
                        p = this.transformation.applyTransformationToPoint(p_);
                        //v = Vector3.subtractVectors(p, ray.getOrigin());
                double t = getT(ray, detA); // Vector3.calculateVectorLength(v);

                hit.setT(t);

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
            else return false;
        }
    }
}
