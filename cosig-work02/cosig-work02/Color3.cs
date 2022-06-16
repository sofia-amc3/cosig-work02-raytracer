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

        public static Color convertToColor(Color3 color)
        {
            return Color.FromArgb(255, (int) Math.Round(255.0 * color.getR()), (int) Math.Round(255.0 * color.getG()), (int) Math.Round(255.0 * color.getB()));
        }

        public static Color3 convertFromColor(Color color)
        {
            return new Color3(color.R / 255.0, color.G / 255.0, color.B / 255.0);
        }

        public static Color3 addColors(Color3 color1, Color3 color2)
        {
            return new Color3(color1.getR() + color2.getR(), color1.getG() + color2.getG(), color1.getB() + color2.getB());
        }

        public static Color3 multiplyColors(Color3 color1, Color3 color2)
        {
            return new Color3(color1.getR() * color2.getR(), color1.getG() * color2.getG(), color1.getB() * color2.getB());
        }

        public static Color3 multiplyColorByScalar(double scalar, Color3 color)
        {
            return new Color3(scalar * color.getR(), scalar * color.getG(), scalar * color.getB());
        }
    }
}
