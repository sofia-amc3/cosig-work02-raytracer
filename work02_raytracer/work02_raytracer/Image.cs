using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Image
    {
        private double numberOfSegments;

        public Image(double numberOfSegments)
        {
            this.numberOfSegments = numberOfSegments;
        }

        public double img_getNumberOfSegments() { return numberOfSegments; }

        public void img_setNumberOfSegments(double numberOfSegments) { this.numberOfSegments = numberOfSegments; }
    }
}
