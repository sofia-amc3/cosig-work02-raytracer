using System;
using System.Collections.Generic;
using System.Text;

namespace work02_raytracer
{
    class Color3
    {
       // can vary between 0.0 and 1.0
       private float r, g, b;

       public Color3(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public float getR() { return r; }
        public float getG() { return g; }
        public float getB() { return b; }

        public void setR(float r) { this.r = r; }
        public void setG(float g) { this.g = g; }
        public void setB(float b) { this.b = b; }
    }
}
