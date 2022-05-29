using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Triangles : Object3D
    {
        private int indexOfTransformation,
                    indexOfMaterial;
        private Vector3 v1,
                        v2,
                        v3,
                        normalVector;
  
        public Triangles()
        {
            this.indexOfTransformation = 0;
            this.indexOfMaterial = 0;
            this.v1 = new Vector3(0, 0, 0);
            this.v2 = new Vector3(0, 0, 0);
            this.v3 = new Vector3(0, 0, 0);
        }

        public Vector3 getV1() { return v1; }
        public Vector3 getV2() { return v2; }
        public Vector3 getV3() { return v3; }
        public Vector3 getNormalVector() { return normalVector; }

        public void setV1(Vector3 v1) { this.v1 = v1; }
        public void setV2(Vector3 v2) { this.v2 = v2; }
        public void setV3(Vector3 v3) { this.v3 = v3; }

        // normalize triangles
        public void calculateNormal()
        {
            Vector3 edge12 = Vector3.subtractVectors(v2, v1),
                    edge13 = Vector3.subtractVectors(v3, v1),
                    normal = Vector3.calculateCrossProduct(edge12, edge13);

            this.normalVector = Vector3.normalizeVector(normal);
        }
    }
}
