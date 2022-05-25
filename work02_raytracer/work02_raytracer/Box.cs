using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Box
    {
        private double numberOfSegments,
                   indexOfTransformation,
                   indexOfMaterial;

        public Box(double numberOfSegments, double indexOfTransformation, double indexOfMaterial)
        {
            this.numberOfSegments = numberOfSegments;
            this.indexOfTransformation = indexOfTransformation;
            this.indexOfMaterial = indexOfMaterial;
        }

        public double box_getNumberOfSegments() { return numberOfSegments; }

        public double box_getIndexOfTransformation() { return indexOfTransformation; }

        public double box_getIndexOfMaterial() { return indexOfMaterial; }

        public void box_setNumberOfSegments(double numberOfSegments) { this.numberOfSegments = numberOfSegments; }

        public void box_setIndexOfTransformation(double indexOfTransformation) { this.indexOfTransformation = indexOfTransformation; }

        public void box_setIndexOfMaterial(double indexOfMaterial) { this.indexOfMaterial = indexOfMaterial; }
    }
}
