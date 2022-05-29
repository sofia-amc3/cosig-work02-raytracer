using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Box : Object3D
    {
        private int indexOfTransformation,
                    indexOfMaterial;

        public Box()
        {
            this.indexOfTransformation = 0;
            this.indexOfMaterial = 0;
        }
    }
}
