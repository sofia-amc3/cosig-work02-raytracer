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
            this.r = r;
        }

        public void setG(double g) 
        {
            this.g = g;
        }

        public void setB(double b) 
        {
            this.b = b;
        }

        public static Color convertToColor(Color3 color)
        {
            /*if (r/g/b < 0) r/g/b = 0;
            else if (r/g/b > 1) r/g/b = 1; 
            else r/g/b = r/g/b; */
            double r = Math.Min(Math.Max(color.getR(), 0), 1),
                   g = Math.Min(Math.Max(color.getG(), 0), 1),
                   b = Math.Min(Math.Max(color.getB(), 0), 1);

            return Color.FromArgb(255, (int) Math.Round(255.0 * r), (int) Math.Round(255.0 * g), (int) Math.Round(255.0 * b));
        }

        public static Color3 convertFromColor(Color color)
        {
            /*if (r/g/b < 0) r/g/b = 0;
            else if (r/g/b > 255) r/g/b = 255; 
            else r/g/b = r/g/b; */
            int r = Math.Min(Math.Max((int)color.R, 0), 255),
                g = Math.Min(Math.Max((int)color.G, 0), 255),
                b = Math.Min(Math.Max((int)color.B, 0), 255);

            return new Color3(r / 255.0, g / 255.0, b / 255.0);
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
