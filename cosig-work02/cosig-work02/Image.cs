using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Image
    {
        private int w,
                    h;
        private Color3 color;

        public Image()
        {
            this.w = 0;
            this.h = 0;
            this.color = new Color3(0, 0, 0);
        }

        public int getWidth() { return w; }
        public int getHeight() { return h; }
        public Color3 getColor() { return color; }

        public void setWidth(int w) 
        {
            if (w < 0) this.w = 0;
            this.w = w; 
        }

        public void setHeight(int h) 
        {
            if (h < 0) this.w = 0;
            this.h = h; 
        }

        public void setColor(Color3 color) { this.color = color; }
    }
}
