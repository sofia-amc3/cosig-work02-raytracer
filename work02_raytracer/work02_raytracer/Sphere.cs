using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Sphere
    {
        private double numberOfSegments,
                    indexOfTransformation,
                    indexOfMaterial;

        public Sphere(double numberOfSegments, double indexOfTransformation, double indexOfMaterial)
        {
            this.numberOfSegments = numberOfSegments;
            this.indexOfTransformation = indexOfTransformation;
            this.indexOfMaterial = indexOfMaterial;
        }

        public double sphere_getNumberOfSegments() { return numberOfSegments; }

        public double sphere_getIndexOfTransformation() { return indexOfTransformation; }

        public double sphere_getIndexOfMaterial() { return indexOfMaterial; }

        public void sphere_setNumberOfSegments(double numberOfSegments) { this.numberOfSegments = numberOfSegments; }

        public void sphere_setIndexOfTransformation(double indexOfTransformation) { this.indexOfTransformation = indexOfTransformation; }

        public void sphere_setIndexOfMaterial(double indexOfMaterial) { this.indexOfMaterial = indexOfMaterial; }
    }
}
