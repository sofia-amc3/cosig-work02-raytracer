using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Camera
    {
        private int indexOfTransformation;
        protected Transformation transformation;
        private double distance,
                       fieldOfVision;

        public Camera()
        {
            this.indexOfTransformation = 0;
            this.distance = 0.1;
            this.fieldOfVision = 0.1;
        }

        public int getIndexOfTransformation() { return indexOfTransformation; }
        public Transformation getTransformation() { return transformation; }
        public double getDistance() { return distance; }
        public double getFieldOfVision() { return fieldOfVision; }
        public double getFieldOfVisionInRadians() 
        {
            return fieldOfVision * Math.PI / 180.0; 
        }

        public void setIndexOfTransformation(int indexOfTransformation)
        {
            if (indexOfTransformation < 0) this.indexOfTransformation = 0;
            else this.indexOfTransformation = indexOfTransformation;
        }

        public void setTransformation(Transformation transformation)
        {
            this.transformation = transformation;
        }

        public void setDistance(double distance)
        {
            if (distance <= 0) this.distance = 0.1;
            else this.distance = distance;
        }

        public void setFieldOfVision(double fieldOfVision)
        {
            if (fieldOfVision <= 0) this.fieldOfVision = 0.1;
            else this.fieldOfVision = fieldOfVision;
        }
    }
}
