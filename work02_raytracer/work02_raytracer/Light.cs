using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Light
    {
        private double numberOfSegments,
                    indexOfTransformation;

        public Light(double numberOfSegments, double indexOfTransformation)
        {
            this.numberOfSegments = numberOfSegments;
            this.indexOfTransformation = indexOfTransformation;
        }

        public double light_getNumberOfSegments() { return numberOfSegments; }

        public double light_getIndexOfTransformation() { return indexOfTransformation; }

        public void light_setNumberOfSegments(double numberOfSegments) { this.numberOfSegments = numberOfSegments; }

        public void light_setIndexOfTransformation(double indexOfTransformation) { this.indexOfTransformation = indexOfTransformation; }
    }
}
