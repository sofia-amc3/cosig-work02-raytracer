using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Camera
    {
        private double numberOfSegments,
                    indexOfTransformation;

        public Camera(double numberOfSegments, double indexOfTransformation)
        {
            this.numberOfSegments = numberOfSegments;
            this.indexOfTransformation = indexOfTransformation;
        }

        public double cam_getNumberOfSegments() { return numberOfSegments; }

        public double cam_getIndexOfTransformation() { return indexOfTransformation; }

        public void cam_setNumberOfSegments(double numberOfSegments) { this.numberOfSegments = numberOfSegments; }

        public void cam_setIndexOfTransformation(double indexOfTransformation) { this.indexOfTransformation = indexOfTransformation; }
    }
}
