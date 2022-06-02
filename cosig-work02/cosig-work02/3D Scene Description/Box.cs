using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Box : Object3D
    {
        public Box() : base()
        {
        }

        public override bool intersect(Ray ray, Hit hit)
        {
            return false;
        }
    }
}
