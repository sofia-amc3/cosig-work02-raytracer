using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Transformation
    {
        private double[,] transformMatrix = new double[4, 4],
                          inverseTransformMatrix = new double[4, 4],
                          transposeInverseTransformMatrix = new double[4, 4];
        private Vector3 translation = new Vector3(0, 0, 0),
                        rotation = new Vector3(0, 0, 0);

        public Transformation()
        {
            createIdentityMatrix(); // initialization
        }

        public double[,] getTransformationMatrix() { return transformMatrix; }
        public double[,] getInverseTransformationMatrix() { return inverseTransformMatrix; }
        public double[,] getTransposeInverseTransformationMatrix() { return transposeInverseTransformMatrix; }
        public Vector3 getTranslation() { return translation; }
        public Vector3 getRotation() { return rotation; }

        public void setTransformationMatrix(double[,] transformMatrix) { this.transformMatrix = transformMatrix; }

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

        // creates matrix corresponding to the translation
        // and multiplies the composite transformation matrix by the newly created matrix
        public void translate(double x, double y, double z)
        {
            // adds the new translation to the previous obtained one 
            translation.setX(translation.getX() + x);
            translation.setY(translation.getY() + y);
            translation.setZ(translation.getZ() + z);

            double[,] translateMatrix = new double[4, 4];

            translateMatrix[0, 0] = 1.0;
            translateMatrix[0, 1] = 0.0;
            translateMatrix[0, 2] = 0.0;
            translateMatrix[0, 3] = x;
            translateMatrix[1, 0] = 0.0;
            translateMatrix[1, 1] = 1.0;
            translateMatrix[1, 2] = 0.0;
            translateMatrix[1, 3] = y;
            translateMatrix[2, 0] = 0.0;
            translateMatrix[2, 1] = 0.0;
            translateMatrix[2, 2] = 1.0;
            translateMatrix[2, 3] = z;
            translateMatrix[3, 0] = 0.0;
            translateMatrix[3, 1] = 0.0;
            translateMatrix[3, 2] = 0.0;
            translateMatrix[3, 3] = 1.0;

            multiplyByMatrix(translateMatrix);
        }

        // creates matrix corresponding to the rotation in the X axis
        // and multiplies the composite transformation matrix by the newly created matrix
        public void rotateX(double angle)
        {
            // adds the new rotation angle to the previous obtained one 
            rotation.setX(rotation.getX() + angle);

            double[,] rotateXMatrix = new double[4, 4];

            angle *= Math.PI / 180.0;
            rotateXMatrix[0, 0] = 1.0;
            rotateXMatrix[0, 1] = 0.0;
            rotateXMatrix[0, 2] = 0.0;
            rotateXMatrix[0, 3] = 0.0;
            rotateXMatrix[1, 0] = 0.0;
            rotateXMatrix[1, 1] = Math.Cos(angle);
            rotateXMatrix[1, 2] = -Math.Sin(angle);
            rotateXMatrix[1, 3] = 0.0;
            rotateXMatrix[2, 0] = 0.0;
            rotateXMatrix[2, 1] = Math.Sin(angle);
            rotateXMatrix[2, 2] = Math.Cos(angle);
            rotateXMatrix[2, 3] = 0.0;
            rotateXMatrix[3, 0] = 0.0;
            rotateXMatrix[3, 1] = 0.0;
            rotateXMatrix[3, 2] = 0.0;
            rotateXMatrix[3, 3] = 1.0;

            multiplyByMatrix(rotateXMatrix);
        }

        // creates matrix corresponding to the rotation in the Y axis
        // and multiplies the composite transformation matrix by the newly created matrix
        public void rotateY(double angle)
        {
            // adds the new rotation angle to the previous obtained one 
            rotation.setY(rotation.getY() + angle);

            double[,] rotateYMatrix = new double[4, 4];

            angle *= Math.PI / 180.0;
            rotateYMatrix[0, 0] = Math.Cos(angle);
            rotateYMatrix[0, 1] = 0.0;
            rotateYMatrix[0, 2] = Math.Sin(angle);
            rotateYMatrix[0, 3] = 0.0;
            rotateYMatrix[1, 0] = 0.0;
            rotateYMatrix[1, 1] = 1.0;
            rotateYMatrix[1, 2] = 0.0;
            rotateYMatrix[1, 3] = 0.0;
            rotateYMatrix[2, 0] = -Math.Sin(angle);
            rotateYMatrix[2, 1] = 0.0;
            rotateYMatrix[2, 2] = Math.Cos(angle);
            rotateYMatrix[2, 3] = 0.0;
            rotateYMatrix[3, 0] = 0.0;
            rotateYMatrix[3, 1] = 0.0;
            rotateYMatrix[3, 2] = 0.0;
            rotateYMatrix[3, 3] = 1.0;

            multiplyByMatrix(rotateYMatrix);
        }

        // creates matrix corresponding to the rotation in the Z axis
        // and multiplies the composite transformation matrix by the newly created matrix
        public void rotateZ(double angle)
        {
            // adds the new rotation angle to the previous obtained one 
            rotation.setZ(rotation.getZ() + angle);

            double[,] rotateZMatrix = new double[4, 4];

            angle *= Math.PI / 180.0;
            rotateZMatrix[0, 0] = Math.Cos(angle);
            rotateZMatrix[0, 1] = -Math.Sin(angle);
            rotateZMatrix[0, 2] = 0.0;
            rotateZMatrix[0, 3] = 0.0;
            rotateZMatrix[1, 0] = Math.Sin(angle);
            rotateZMatrix[1, 1] = Math.Cos(angle);
            rotateZMatrix[1, 2] = 0.0;
            rotateZMatrix[1, 3] = 0.0;
            rotateZMatrix[2, 0] = 0.0;
            rotateZMatrix[2, 1] = 0.0;
            rotateZMatrix[2, 2] = 1.0;
            rotateZMatrix[2, 3] = 0.0;
            rotateZMatrix[3, 0] = 0.0;
            rotateZMatrix[3, 1] = 0.0;
            rotateZMatrix[3, 2] = 0.0;
            rotateZMatrix[3, 3] = 1.0;

            multiplyByMatrix(rotateZMatrix);
        }

        // creates matrix corresponding to the scale
        // and multiplies the composite transformation matrix by the newly created matrix
        public void scale(double x, double y, double z)
        {
            double[,] scaleMatrix = new double[4, 4];

            scaleMatrix[0, 0] = x;
            scaleMatrix[0, 1] = 0.0;
            scaleMatrix[0, 2] = 0.0;
            scaleMatrix[0, 3] = 0.0;
            scaleMatrix[1, 0] = 0.0;
            scaleMatrix[1, 1] = y;
            scaleMatrix[1, 2] = 0.0;
            scaleMatrix[1, 3] = 0.0;
            scaleMatrix[2, 0] = 0.0;
            scaleMatrix[2, 1] = 0.0;
            scaleMatrix[2, 2] = z;
            scaleMatrix[2, 3] = 0.0;
            scaleMatrix[3, 0] = 0.0;
            scaleMatrix[3, 1] = 0.0;
            scaleMatrix[3, 2] = 0.0;
            scaleMatrix[3, 3] = 1.0;

            multiplyByMatrix(scaleMatrix);
        }

        // we don't want to change the original transformation matrix, so let's create a copy of it
        // in this case, we are cloning the camera's original transformation just so it doens't change and interfer with the 3D objects to create
        public Transformation clone()
        {
            Transformation transformation = new Transformation();
            double[,] transformMatrix = new double[4, 4];

            // creates a new matrix equals to the current transformation matrix
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    transformMatrix[i, j] = this.transformMatrix[i, j];

            transformation.setTransformationMatrix(transformMatrix);
            return transformation;
        }

        // APPLIES AND CALCULATES TRANSFORMATIONS --------------------------------------------------------------------------------------------------------------
        public Vector3 applyTransformationToPoint(Vector3 point)
        {
            // sends the transformMatrix to this method, which is static
            return multiplyMatrixWithPoint(this.transformMatrix, point);
        }

        public Vector3 applyTransformationToVector(Vector3 v1)
        {
            // sends the transformMatrix to this method, which is static
            return multiplyMatrixWithVector(this.transformMatrix, v1);
        }

        public void applyTransformationToRay(Ray ray)
        {
            // sends the inverseTransformMatrix to this method, which is static
            multiplyMatrixWithRay(this.inverseTransformMatrix, ray);
        }

        // static method: gives us the possibility to send any kind of matrix / point
        public static Vector3 multiplyMatrixWithPoint(double[,] matrix, Vector3 point)
        {
            // the matrix received is 4x4 and a point has 3 coordinates, so we need to convert the point to homegenous coordinates
            // just so it has the same number of lines as the matrix (4)
            Vector4 pointV4 = Vector4.convertPointToHomogenousCoordinates(point);
            // next, we convert the point to a matrix and multiply it by the matrix received
            double[] newPointMatrix = multiplyByColumnMatrix(matrix, Vector4.convertToMatrix(pointV4));
            // then, converts the resulted matrix to a new point, which still has 4 coordinates (homogenous)
            Vector4 newPoint = Vector4.convertFromMatrix(newPointMatrix);

            // finally, converts the point to 3 coordinates again (cartesian)
            return Vector4.convertPointToCartesianCoordinates(newPoint);
        }

        // static method: gives us the possibility to send any kind of matrix / vector
        public static Vector3 multiplyMatrixWithVector(double[,] matrix, Vector3 v1)
        {
            // the matrix received is 4x4 and a vector has 3 coordinates, so we need to convert the vector to homegenous coordinates
            // just so it has the same number of lines as the matrix (4)
            Vector4 vectorV4 = Vector4.convertVectorToHomogenousCoordinates(v1);
            // next, we convert the vector to a matrix and multiply it by the matrix received
            double[] newVectorMatrix = multiplyByColumnMatrix(matrix, Vector4.convertToMatrix(vectorV4));
            // then, converts the resulted matrix to a new vector, which still has 4 coordinates (homogenous)
            Vector4 newVector = Vector4.convertFromMatrix(newVectorMatrix);

            // finally, converts the vector to 3 coordinates again (cartesian)
            return Vector4.convertVectorToCartesianCoordinates(newVector);
        }

        // static method: gives us the possibility to send any kind of matrix / ray
        public static void multiplyMatrixWithRay(double[,] matrix, Ray ray)
        {
            // sets the ray's transformed origin and direction
            ray.setOriginTransformed(multiplyMatrixWithPoint(matrix, ray.getOrigin()));
            ray.setDirectionTransformed(Vector3.normalizeVector(multiplyMatrixWithVector(matrix, ray.getDirection())));
        }

        // MATRIX CALCULATIONS -------------------------------------------------------------------------------------------------------------------------------
        // multiplies two 4x4 matrixes
        public void multiplyByMatrix(double[,] matrixA)
        {
            double[,] matrixB = new double[4, 4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    matrixB[i, j] = transformMatrix[i, j];
                    transformMatrix[i, j] = 0.0;
                }

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        transformMatrix[i, j] += matrixB[i, k] * matrixA[k, j];

            // updates the inverse and transposeInverse, as we're changing the transformation matrix
            this.inverseTransformMatrix = calculateInverse(this.transformMatrix);
            this.transposeInverseTransformMatrix = calculateTranspose(this.inverseTransformMatrix);
        }

        // multiplies a 4x4 matrix for a column matrix representative of a point or vector
        public static double[] multiplyByColumnMatrix(double[,] matrix, double[] pointA)
        {
            double[] pointB = new double[4];

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    pointB[i] += matrix[i, j] * pointA[j];

            return pointB;
        }

        // calculates and returns transpose matrix AT
        public static double[,] calculateTranspose(double[,] matrix)
        {
            int w = matrix.GetLength(0),
                h = matrix.GetLength(1);

            double[,] transposeMatrix = new double[h, w];

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    transposeMatrix[j, i] = matrix[i, j];

            return transposeMatrix;
        }

        // in portuguese: menor complementar Dij 
        public static double[,] getMinorMatrix(double[,] matrix, int row, int column)
        {
            int currentColumn = 0;
            double[,] minor = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == column) continue; // skips this iteration

                for (int i = 0; i < matrix.GetLength(1) - 1; i++)
                    minor[i, currentColumn] = matrix[i < row ? i : i + 1, j];

                currentColumn++;
            }

            return minor;
        }

        // calculates det(A) or |A| (must have same number of lines and columns)
        public static double calculateDeterminant(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Can't calculate determinant due to invalid Matrix Dimension: Number of lines is not equal to the number of columns.");
            }
            else
            {
                if (matrix.GetLength(0) == 1)
                    return matrix[0, 0];

                else if (matrix.GetLength(0) == 2)
                    return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);

                else // 3 or > : Laplace Rule
                {
                    double det = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                        det += Math.Pow(-1, i) * matrix[0, i] * calculateDeterminant(getMinorMatrix(matrix, 0, i));
                    return det;
                }
            }
        }

        // calculates and returns inverse matrix A-1 (must have same number of lines and columns && det != 0)
        // formula: (1 / det(A)) * Adj(A)
        public static double[,] calculateInverse(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("Can't calculate inverse due to invalid Matrix Dimension: Number of lines is not equal to the number of columns.");
            }
            else if(calculateDeterminant(matrix) == 0)
            {
                throw new ArgumentOutOfRangeException("Can't calculate inverse due to the determinant being 0.");
            }
            else
            {
                double[,] inverseMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)]; // copy of original matrix

                // in portuguese: matriz adjunta -> Adj(A)
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        inverseMatrix[i, j] = Math.Pow(-1, i + j) * calculateDeterminant(getMinorMatrix(matrix, i, j));

                double inverseDet = 1.0 / calculateDeterminant(matrix);

                for(int i = 0; i < inverseMatrix.GetLength(0); i++)
                    for(int j = 0; j <= i; j++)
                    {
                        double temp = inverseMatrix[i, j];
                        inverseMatrix[i, j] = inverseMatrix[j, i] * inverseDet;
                        inverseMatrix[j, i] = temp * inverseDet;
                    }

                return inverseMatrix;
            }
        }
    }
}
