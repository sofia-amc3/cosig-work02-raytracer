using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    abstract class Object3D
    {
        protected int indexOfTransformation,
                      indexOfMaterial;
        protected Material material;
        protected Transformation transformation;

        public Object3D()
        {
            this.indexOfTransformation = 0;
            this.indexOfMaterial = 0;
            this.material = new Material();
            this.transformation = new Transformation();
        }

        public int getIndexOfTransformation() { return indexOfTransformation; }
        public int getIndexOfMaterial() { return indexOfMaterial; }

        public Material getMaterial() { return material; }
        public Transformation getTransformation() { return transformation; }

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

        public void setMaterial(Material material)
        {
            this.material = material;
        }

        public virtual void setTransformation(Transformation transformation) // virtual - means that it can be overridden, in this case, by the triangles
        {
            this.transformation = transformation;
        }

        public abstract bool intersect(Ray ray, Hit hit); // abstract - does nothing here
    }
}
