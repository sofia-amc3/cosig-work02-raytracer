using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Transformation
    {
        private double[,] transformMatrix = new double[4, 4];

        public Transformation()
        {
            createIdentityMatrix(); // initialization
            translate(0.0, 0.0, -74.0);
            rotateX(-60.0);
            rotateZ(45.0);
        }

        // creates matrix corresponding to the identity transformation
        public void createIdentityMatrix()
        {
            transformMatrix[0, 0] = 1.0;
            transformMatrix[0, 1] = 0.0;
            transformMatrix[0, 2] = 0.0;
            transformMatrix[0, 3] = 0.0;
            transformMatrix[1, 0] = 0.0;
            transformMatrix[1, 1] = 1.0;
            transformMatrix[1, 2] = 0.0;
            transformMatrix[1, 3] = 0.0;
            transformMatrix[2, 0] = 0.0;
            transformMatrix[2, 1] = 0.0;
            transformMatrix[2, 2] = 1.0;
            transformMatrix[2, 3] = 0.0;
            transformMatrix[3, 0] = 0.0;
            transformMatrix[3, 1] = 0.0;
            transformMatrix[3, 2] = 0.0;
            transformMatrix[3, 3] = 1.0;
        }

        // multiplies a 4x4 matrix for a column matrix representative of a point or vector in homogeneous coordinates
        public void multiplyByColumnMatrix(double[] pointA, double[] pointB)
        {
            for(int i = 0; i < 4; i++)
                pointB[i] = 0.0;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    pointB[i] += transformMatrix[i, j] * pointA[j];
        }

        // multiplies two 4x4 matrixes
        public void multiplyByMatrix(double[,] matrixA)
        {
            double[,] matrixB = new double[4, 4];

            for(int i = 0; i < 4; i++) 
                for(int j = 0; j < 4; j++)
                {
                    matrixB[i, j] = transformMatrix[i, j];
                    transformMatrix[i, j] = 0.0;
                }

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        transformMatrix[i, j] += matrixB[i, k] * matrixA[k, j];
        }

        // creates matrix corresponding to the translation
        // and multiplies the composite transformation matrix by the newly created matrix
        public void translate(double x, double y, double z)
        {
            double[,] translateMatrix = new double[4, 4];

            translateMatrix[0,0] = 1.0;
            translateMatrix[0,1] = 0.0;
            translateMatrix[0,2] = 0.0;
            translateMatrix[0,3] = x;
            translateMatrix[1,0] = 0.0;
            translateMatrix[1,1] = 1.0;
            translateMatrix[1,2] = 0.0;
            translateMatrix[1,3] = y;
            translateMatrix[2,0] = 0.0;
            translateMatrix[2,1] = 0.0;
            translateMatrix[2,2] = 1.0;
            translateMatrix[2,3] = z;
            translateMatrix[3,0] = 0.0;
            translateMatrix[3,1] = 0.0;
            translateMatrix[3,2] = 0.0;
            translateMatrix[3,3] = 1.0;

            multiplyByMatrix(translateMatrix);
        }

        // creates matrix corresponding to the rotation in the X axis
        // and multiplies the composite transformation matrix by the newly created matrix
        public void rotateX(double angle)
        {
            double[,] rotateXMatrix = new double[4, 4];

            angle *= Math.PI / 180.0;
            rotateXMatrix[0,0] = 1.0;
            rotateXMatrix[0,1] = 0.0;
            rotateXMatrix[0,2] = 0.0;
            rotateXMatrix[0,3] = 0.0;
            rotateXMatrix[1,0] = 0.0;
            rotateXMatrix[1,1] = Math.Cos(angle);
            rotateXMatrix[1,2] = -Math.Sin(angle);
            rotateXMatrix[1,3] = 0.0;
            rotateXMatrix[2,0] = 0.0;
            rotateXMatrix[2,1] = Math.Sin(angle);
            rotateXMatrix[2,2] = Math.Cos(angle);
            rotateXMatrix[2,3] = 0.0;
            rotateXMatrix[3,0] = 0.0;
            rotateXMatrix[3,1] = 0.0;
            rotateXMatrix[3,2] = 0.0;
            rotateXMatrix[3,3] = 1.0;

            multiplyByMatrix(rotateXMatrix);
        }

        // creates matrix corresponding to the rotation in the Y axis
        // and multiplies the composite transformation matrix by the newly created matrix
        public void rotateY(double angle)
        {
            double[,] rotateYMatrix = new double[4, 4];

            angle *= Math.PI / 180.0;
            rotateYMatrix[0,0] = Math.Cos(angle);
            rotateYMatrix[0,1] = 0.0;
            rotateYMatrix[0,2] = Math.Sin(angle);
            rotateYMatrix[0,3] = 0.0;
            rotateYMatrix[1,0] = 0.0;
            rotateYMatrix[1,1] = 1.0;
            rotateYMatrix[1,2] = 0.0;
            rotateYMatrix[1,3] = 0.0;
            rotateYMatrix[2,0] = -Math.Sin(angle);
            rotateYMatrix[2,1] = 0.0;
            rotateYMatrix[2,2] = Math.Cos(angle);
            rotateYMatrix[2,3] = 0.0;
            rotateYMatrix[3,0] = 0.0;
            rotateYMatrix[3,1] = 0.0;
            rotateYMatrix[3,2] = 0.0;
            rotateYMatrix[3,3] = 1.0;

            multiplyByMatrix(rotateYMatrix);
        }

        // creates matrix corresponding to the rotation in the Z axis
        // and multiplies the composite transformation matrix by the newly created matrix
        public void rotateZ(double angle)
        {
            double[,] rotateZMatrix = new double[4, 4];

            angle *= Math.PI / 180.0;
            rotateZMatrix[0,0] = Math.Cos(angle);
            rotateZMatrix[0,1] = -Math.Sin(angle);
            rotateZMatrix[0,2] = 0.0;
            rotateZMatrix[0,3] = 0.0;
            rotateZMatrix[1,0] = Math.Sin(angle);
            rotateZMatrix[1,1] = Math.Cos(angle);
            rotateZMatrix[1,2] = 0.0;
            rotateZMatrix[1,3] = 0.0;
            rotateZMatrix[2,0] = 0.0;
            rotateZMatrix[2,1] = 0.0;
            rotateZMatrix[2,2] = 1.0;
            rotateZMatrix[2,3] = 0.0;
            rotateZMatrix[3,0] = 0.0;
            rotateZMatrix[3,1] = 0.0;
            rotateZMatrix[3,2] = 0.0;
            rotateZMatrix[3,3] = 1.0;

            multiplyByMatrix(rotateZMatrix);
        }

        // creates matrix corresponding to the scale
        // and multiplies the composite transformation matrix by the newly created matrix
        public void scale(double x, double y, double z)
        {
            double[,] scaleMatrix = new double[4, 4];

            scaleMatrix[0,0] = x;
            scaleMatrix[0,1] = 0.0;
            scaleMatrix[0,2] = 0.0;
            scaleMatrix[0,3] = 0.0;
            scaleMatrix[1,0] = 0.0;
            scaleMatrix[1,1] = y;
            scaleMatrix[1,2] = 0.0;
            scaleMatrix[1,3] = 0.0;
            scaleMatrix[2,0] = 0.0;
            scaleMatrix[2,1] = 0.0;
            scaleMatrix[2,2] = z;
            scaleMatrix[2,3] = 0.0;
            scaleMatrix[3,0] = 0.0;
            scaleMatrix[3,1] = 0.0;
            scaleMatrix[3,2] = 0.0;
            scaleMatrix[3,3] = 1.0;

            multiplyByMatrix(scaleMatrix);
        }
    }
}
