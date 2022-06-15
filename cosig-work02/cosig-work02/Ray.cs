using System;
using System.Collections.Generic;
using System.Text;

namespace cosig_work02
{
    class Ray 
    {
        private Vector3 origin, direction, originTransformed, directionTransformed;
        private Vector4 origin_v4, direction_v4;

        // Must contain a 3D point (ray's origin) and a 3D vector (ray's direction)
        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        public Ray(Vector4 origin_v4, Vector4 direction_v4)
        {
            this.origin_v4 = origin_v4;
            this.direction_v4 = direction_v4;
        }

        public Vector3 getOrigin() { return origin; }
        public Vector3 getDirection() { return direction; }
        public Vector3 getOriginTransformed() { return originTransformed; }
        public Vector3 getDirectionTransformed() { return directionTransformed; }
        public Vector4 getOrigin_v4() { return origin_v4; }
        public Vector4 getDirection_v4() { return direction_v4; }

        public void setOrigin(Vector3 origin) { this.origin = origin; }
        public void setDirection(Vector3 direction) { this.direction = direction; }
        public void setOriginTransformed(Vector3 originTransformed) { this.originTransformed = originTransformed; }
        public void setDirectionTransformed(Vector3 directionTransformed) { this.directionTransformed = directionTransformed; }
        public void setOrigin_v4(Vector4 origin_v4) { this.origin_v4 = origin_v4; }
        public void setDirection_v4(Vector4 direction_v4) { this.direction_v4 = direction_v4; }

        // if t > 0.0, P(t) is after the radius' origin
        // if t < 0.0, P(t) is behind the radius' origin
        public Vector3 pointAtParameter(double t)
        {
            return Vector3.addVectors(origin, Vector3.multiplyVectorByScalar(t, direction));
        }

        private static double calculateImageHeight(Camera camera)
        {
            double fov = camera.getFieldOfVisionInRadians(),
                   distance = camera.getDistance(),
                   imgHeight;

            // Math.Tan(fov / 2.0) = (height / 2.0) / distance
            imgHeight = 2.0 * distance * Math.Tan(fov / 2.0);

            return imgHeight;
        }

        private static double calculateImageWidth(Camera camera, Image image)
        {
            int hRes = image.getHRes(),
                vRes = image.getVRes();

            double imgWidth = calculateImageHeight(camera) * hRes / vRes;

            return imgWidth;
        }

        private static double calculatePixelDimension(Camera camera, Image image)
        {
            int vRes = image.getVRes();
            double s = calculateImageHeight(camera) / vRes;
            return s;
        }

        public static Ray[,] createRays(Camera camera, Image image)
        {
            int hRes = image.getHRes(),
                vRes = image.getVRes();
            double distance = camera.getDistance(),
                   s = calculatePixelDimension(camera, image),
                   width = calculateImageWidth(camera, image),
                   height = calculateImageHeight(camera);
            Vector3 origin = new Vector3(0.0, 0.0, distance); // camera's position
            Ray[,] rays = new Ray[hRes, vRes];

            for (int i = 0; i < hRes; i++) // goes through image's columns (pixels)
            {
                for (int j = 0; j < vRes; j++) // goes through image's lines
                {
                    double x = (i + 0.5) * s - width / 2.0,
                           y = -(j + 0.5) * s + height / 2.0;

                    // calculates P.x and P.y of pixelCenter, Pz = 0.0
                    Vector3 direction = new Vector3(x, y, -distance);
                    Vector3 normalizedDirection = Vector3.normalizeVector(direction);

                    rays[i, j] = new Ray(origin, normalizedDirection);
                }
            }

            return rays;
        }
    }
}
