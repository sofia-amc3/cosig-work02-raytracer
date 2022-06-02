using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Hit
    {
        private bool found; // true if an intersection is found
        private Material material; // part of the intersected object 
        private Vector3 point, // intersection point
                        normal; // normal to the tangent plane to the surface of the object at the intersection point
        private double t, // distance from the ray's origin to the intersection point
                       tmin; // min distance t found at the moment
        private Color3 color;

        public Hit(double t, Color3 color)
        {
            this.t = t;
            this.color = color;
        }

        public bool getFoundState() { return found; }
        public Material getMaterial() { return material; }
        public Vector3 getPoint() { return point; }
        public Vector3 getNormal() { return normal; }
        public double getT() { return t; }
        public double getTMin() { return tmin; }
        public Color3 getColor() { return color; }

        public void setFoundState(bool found) { this.found = found; }
        public void setMaterial(Material material) { this.material = material; }
        public void setPoint(Vector3 point) { this.point = point; }
        public void setNormal(Vector3 normal) { this.normal = normal; }
        public void setT(double t) { this.t = t; }
        public void setTMin(double tmin) { this.tmin = tmin; }
        public void setColor(Color3 color) { this.color = color; }
    }
}
