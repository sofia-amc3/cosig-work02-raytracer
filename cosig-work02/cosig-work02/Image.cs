using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Image
    {
        private int imageResWidth,
                    imageResHeight;
        private Color3 imageColor;

        public Image()
        {
            this.imageResWidth = 0;
            this.imageResHeight = 0;
            this.imageColor = new Color3(0, 0, 0);
        }

        public int getImageResWidth() { return imageResWidth; }
        public int getImageResHeight() { return imageResHeight; }
        public Color3 getImageColor() { return imageColor; }

        public void setImageResWidth(int imageResWidth) { this.imageResWidth = imageResWidth; }
        public void setImageResHeight(int imageResHeight) { this.imageResHeight = imageResHeight; }
        public void setImageColor(Color3 imageColor) { this.imageColor = imageColor; }
    }
}
