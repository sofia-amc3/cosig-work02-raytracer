using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Sphere : Object3D
    {
        private int indexOfTransformation,
                    indexOfMaterial;

        public Sphere()
        {
            this.indexOfTransformation = 0;
            this.indexOfMaterial = 0;
        }
    }
}
