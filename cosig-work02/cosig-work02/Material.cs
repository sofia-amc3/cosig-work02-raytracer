using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Material
    {
        private double ambient,
                       diffuse,
                       specular,
                       refraction,
                       indexOfRefraction;
        private Color3 color;

        public Material()
        {
            this.ambient = 0;
            this.diffuse = 0;
            this.specular = 0;
            this.refraction = 0;
            this.indexOfRefraction = 1;
            this.color = new Color3(0, 0, 0);
        }

        public double getAmbient() { return ambient; }
        public double getDiffuse() { return diffuse; }
        public double getSpecular() { return specular; }
        public double getRefraction() { return refraction; }
        public double getIndexOfRefraction() { return indexOfRefraction; }
        public Color3 getColor() { return color; }

        public void setAmbient(Double ambient)
        {
            if (ambient < 0) this.ambient = 0;
            else if (ambient > 1) this.ambient = 1;
            else this.ambient = ambient;
        }

        public void setDiffuse(Double diffuse)
        {
            if (diffuse < 0) this.diffuse = 0;
            else if (diffuse > 1) this.diffuse = 1;
            else this.diffuse = diffuse;
        }

        public void setSpecular(Double specular)
        {
            if (specular < 0) this.specular = 0;
            else if (specular > 1) this.specular = 1;
            else this.specular = specular;
        }

        public void setRefraction(Double refraction)
        {
            if (refraction < 0) this.refraction = 0;
            else if (refraction > 1) this.refraction = 1;
            else this.refraction = refraction;
        }

        public void setIndexOfRefraction(Double indexOfRefraction)
        {
            if (indexOfRefraction < 1) this.indexOfRefraction = 1;
            else this.indexOfRefraction = indexOfRefraction;
        }

        public void setColor(Color3 color) { this.color = color; }
    }
}
