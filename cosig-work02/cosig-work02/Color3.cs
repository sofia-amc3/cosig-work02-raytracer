using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Color3
    {
       // can vary between 0.0 and 1.0
       private double r, g, b;

       public Color3(double r, double g, double b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public double getR() { return r; }
        public double getG() { return g; }
        public double getB() { return b; }

        public void setR(double r) { this.r = r; }
        public void setG(double g) { this.g = g; }
        public void setB(double b) { this.b = b; }
    }
}
