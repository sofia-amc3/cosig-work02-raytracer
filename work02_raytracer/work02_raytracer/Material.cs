using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Material
    {
        private double numberOfSegments;

        public Material(int numberOfSegments)
        {
            this.numberOfSegments = numberOfSegments;
        }

        public double material_getNumberOfSegments() { return numberOfSegments; }

        public void material_setNumberOfSegments(double numberOfSegments) { this.numberOfSegments = numberOfSegments; }
    }
}
