using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace cosig_work02
{
    class Color3
    {
       // can vary between 0.0 and 1.0
       private double r, g, b;

       public Color3(double r, double g, double b)
        {
            setR(r);
            setG(g);
            setB(b);
        }

        public double getR() { return r; }
        public double getG() { return g; }
        public double getB() { return b; }

        public void setR(double r) 
        {
            if (r < 0) this.r = 0;
            else if (r > 1) this.r = 1;
            else this.r = r;
        }

        public void setG(double g) 
        {
            if (g < 0) this.g = 0;
            else if (g > 1) this.g = 1;
            else this.g = g;
        }

        public void setB(double b) 
        {
            if (b < 0) this.b = 0;
            else if (b > 1) this.b = 1;
            else this.b = b;
        }

        public Color convertToColor()
        {
            return Color.FromArgb((int) Math.Round(255.0 * this.r), (int) Math.Round(255.0 * this.g), (int) Math.Round(255.0 * this.b));
        }
    }
}
