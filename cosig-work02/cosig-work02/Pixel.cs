using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace cosig_work02
{
    class Pixel
    {
        private int i, j;
        private Color color;

        public Pixel(int i, int j, Color color)
        {
            this.i = i;
            this.j = j;
            this.color = color;
        }

        public int getI() { return this.i; }
        public int getJ() { return this.j; }
        public Color getColor() { return this.color; }

        public void setI(int i) { this.i = i; }
        public void setJ(int j) { this.j = j; }
        public void setColor(Color color) { this.color = color; }
    }
}
