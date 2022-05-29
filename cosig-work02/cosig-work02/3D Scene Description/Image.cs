using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Image
    {
        private int hRes,
                    vRes;
        private Color3 color;

        public Image()
        {
            this.hRes = 0;
            this.vRes = 0;
            this.color = new Color3(0, 0, 0);
        }

        public int getHRes() { return hRes; }
        public int getVRes() { return vRes; }
        public Color3 getColor() { return color; }

        public void setHRes(int hRes) 
        {
            if (hRes < 0) this.hRes = 0;
            this.hRes = hRes; 
        }

        public void setVRes(int vRes) 
        {
            if (vRes < 0) this.vRes = 0;
            this.vRes = vRes; 
        }

        public void setColor(Color3 color) { this.color = color; }
    }
}
