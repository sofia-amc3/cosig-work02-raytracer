using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Light
    {
        private int indexOfTransformation;
        private Color3 color;

        public Light()
        {
            this.indexOfTransformation = 0;
            this.color = new Color3(0, 0, 0);
        }

        public int getIndexOfTransformation() { return indexOfTransformation; }
        public Color3 getColor() { return color; }

        public void setIndexOfTransformation(int indexOfTransformation)
        {
            if (indexOfTransformation < 0) indexOfTransformation = 0;
            else this.indexOfTransformation = indexOfTransformation;
        }

        public void setColor(Color3 color) { this.color = color; }
    }
}
