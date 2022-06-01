using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    abstract class Object3D
    {
        protected int indexOfTransformation,
                      indexOfMaterial;

        public Object3D()
        {
            this.indexOfTransformation = 0;
            this.indexOfMaterial = 0;
        }

        public int getIndexOfTransformation() { return indexOfTransformation; }
        public int getIndexOfMaterial() { return indexOfMaterial; }

        public void setIndexOfTransformation(int indexOfTransformation)
        {
            if (indexOfTransformation < 0) indexOfTransformation = 0;
            else this.indexOfTransformation = indexOfTransformation;
        }

        public void setIndexOfMaterial(int indexOfMaterial)
        {
            if (indexOfMaterial < 0) indexOfMaterial = 0;
            else this.indexOfMaterial = indexOfMaterial;
        }

        public abstract bool intersect(Ray ray, Hit hit);
    }
}
