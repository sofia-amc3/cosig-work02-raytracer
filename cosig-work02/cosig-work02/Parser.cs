﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace cosig_work02
{
    class Parser
    {
        public static void parseFile(String path)
        {
            List<Image> images = new List<Image>();
            List<Transformation> transformations = new List<Transformation>();
            List<Material> materials = new List<Material>();
            List<Camera> cameras = new List<Camera>();
            List<Light> lights = new List<Light>();
            List<Sphere> spheres = new List<Sphere>();
            List<Box> boxes = new List<Box>();

            StreamReader streamReader = new StreamReader(path);
            string line;

            while((line = streamReader.ReadLine()) != null)
            {
                switch(line.Trim())
                {
                    case "Image":
                        images.Add(readImage(streamReader));
                        break;

                    case "Transformation":
                        transformations.Add(readTransformation(streamReader));
                        break;

                    case "Camera":
                        cameras.Add(readCamera(streamReader));
                        break;

                    case "Light":
                        lights.Add(readLight(streamReader));
                        break;

                    case "Material":
                        materials.Add(readMaterial(streamReader));
                        break;

                    case "Triangles":
                        break;

                    case "Sphere":
                        spheres.Add(readSphere(streamReader));
                        break;

                    case "Box":
                        boxes.Add(readBox(streamReader));
                        break;
                }
            }
        }

        private static Image readImage(StreamReader streamReader)
        {
            Image image = new Image();
            string line;
            bool isInsideBrackets = false;

            while((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    if(values.Length == 2)
                    {
                        image.setWidth(Int32.Parse(values[0]));
                        image.setHeight(Int32.Parse(values[1]));
                    } else if(values.Length == 3)
                    {
                        image.setColor(new Color3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                    }
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return image;
        }

        private static Transformation readTransformation(StreamReader streamReader)
        {
            Transformation transformation = new Transformation();
            string line;
            bool isInsideBrackets = false;

            while ((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    switch(values[0].Trim())
                    {
                        case "T":
                            transformation.translate(Double.Parse(values[1]), Double.Parse(values[2]), Double.Parse(values[3]));
                            break;
                        case "Rx":
                            transformation.rotateX(Double.Parse(values[1]));
                            break;
                        case "Ry":
                            transformation.rotateY(Double.Parse(values[1]));
                            break;
                        case "Rz":
                            transformation.rotateZ(Double.Parse(values[1]));
                            break;
                        case "S":
                            transformation.scale(Double.Parse(values[1]), Double.Parse(values[2]), Double.Parse(values[3]));
                            break;
                    }                   
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return transformation;
        }

        private static Material readMaterial(StreamReader streamReader)
        {
            Material material = new Material();
            string line;
            bool isInsideBrackets = false;

            while ((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    if (values.Length == 3)
                    {
                        material.setColor(new Color3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                    }
                    else if (values.Length == 5)
                    {
                        material.setAmbient(Double.Parse(values[0]));
                        material.setDiffuse(Double.Parse(values[1]));
                        material.setSpecular(Double.Parse(values[2]));
                        material.setRefraction(Double.Parse(values[3]));
                        material.setIndexOfRefraction(Double.Parse(values[4]));
                    }
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return material;
        }

        private static Camera readCamera(StreamReader streamReader)
        {
            Camera camera = new Camera();
            string line;
            bool isInsideBrackets = false;
            int lineIndex = 0;

            while ((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    switch(lineIndex)
                    {
                        case 0:
                            camera.setIndexOfTransformation(Int32.Parse(values[0]));
                            break;

                        case 1:
                            camera.setDistance(Double.Parse(values[0]));
                            break;

                        case 2:
                            camera.setFieldOfVision(Double.Parse(values[0]));
                            break;
                    }

                    lineIndex++;
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return camera;
        }

        private static Light readLight(StreamReader streamReader)
        {
            Light light = new Light();
            string line;
            bool isInsideBrackets = false;

            while ((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    if (values.Length == 1)
                    {
                        light.setIndexOfTransformation(Int32.Parse(values[0]));
                    }
                    else if (values.Length == 3)
                    {
                        light.setColor(new Color3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                    }
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return light;
        }

        private static Sphere readSphere(StreamReader streamReader)
        {
            Sphere sphere = new Sphere();
            string line;
            bool isInsideBrackets = false;
            int lineIndex = 0;

            while ((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    switch (lineIndex)
                    {
                        case 0:
                            sphere.setIndexOfTransformation(Int32.Parse(values[0]));
                            break;

                        case 1:
                            sphere.setIndexOfMaterial(Int32.Parse(values[0]));
                            break;
                    }

                    lineIndex++;
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return sphere;
        }

        private static Box readBox(StreamReader streamReader)
        {
            Box box = new Box();
            string line;
            bool isInsideBrackets = false;
            int lineIndex = 0;

            while ((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    switch (lineIndex)
                    {
                        case 0:
                            box.setIndexOfTransformation(Int32.Parse(values[0]));
                            break;

                        case 1:
                            box.setIndexOfMaterial(Int32.Parse(values[0]));
                            break;
                    }

                    lineIndex++;
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return box;
        }
    }
}
