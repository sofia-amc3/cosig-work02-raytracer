using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Triangles
    {
        private double numberOfSegments,
                   indexOfTransformation,
                   indexOfMaterial,
                   numberOfTriangles;

        public Triangles(double numberOfSegments, double indexOfTransformation, double indexOfMaterial, double numberOfTriangles)
        {
            this.numberOfSegments = numberOfSegments;
            this.indexOfTransformation = indexOfTransformation;
            this.indexOfMaterial = indexOfMaterial;
            this.numberOfTriangles = numberOfTriangles;
        }

        public double triangles_getNumberOfSegments() { return numberOfSegments; }

        public double triangles_getIndexOfTransformation() { return indexOfTransformation; }

        public double triangles_getIndexOfMaterial() { return indexOfMaterial; }

        public void triangles_setNumberOfSegments(double numberOfSegments) { this.numberOfSegments = numberOfSegments; }

        public void triangles_setIndexOfTransformation(double indexOfTransformation) { this.indexOfTransformation = indexOfTransformation; }

        public void triangles_setIndexOfMaterial(double indexOfMaterial) { this.indexOfMaterial = indexOfMaterial; }

        public void triangles_setNumberOfTriangles(double numberOfTriangles) { this.numberOfTriangles = numberOfTriangles; }
    }
}
