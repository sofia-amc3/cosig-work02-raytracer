using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace cosig_work02
{
    class Parser
    {
        private string path;
        public List<Image> images = new List<Image>();
        public List<Transformation> transformations = new List<Transformation>();
        public List<Material> materials = new List<Material>();
        public List<Camera> cameras = new List<Camera>();
        public List<Light> lights = new List<Light>();
        public List<Sphere> spheres = new List<Sphere>();
        public List<Box> boxes = new List<Box>();
        public List<Triangle> triangles = new List<Triangle>();

        public Parser(String path)
        {
            this.path = path;
        }

        public void parseFromFile()
        {
            StreamReader streamReader = new StreamReader(this.path);
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
                        triangles.AddRange(readTriangles(streamReader));
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

        public void parseToFile(List<Image> images, List<Transformation> transformations, List<Material> materials, List<Camera> cameras, List<Light> lights, List<Object3D> objects)
        {
            StreamWriter sw = File.CreateText(this.path);
            foreach(Image image in images) sw.WriteLine(writeImage(image));
            foreach (Transformation transformation in transformations) sw.WriteLine(writeTransformation(transformation));
            foreach (Material material in materials) sw.WriteLine(writeMaterial(material));
            foreach (Camera camera in cameras) sw.WriteLine(writeCamera(camera));
            foreach (Light light in lights) sw.WriteLine(writeLight(light));

            // 3D Objects 
            List<Sphere> spheres = new List<Sphere>();
            List<Box> boxes = new List<Box>();
            List<List<Triangle>> triangles = new List<List<Triangle>>();
            // separates 3D objects according to their types
            foreach (Object3D object3D in objects)
            {
                if (object3D.GetType() == typeof(Sphere)) spheres.Add(object3D as Sphere);
                if (object3D.GetType() == typeof(Box)) boxes.Add(object3D as Box);
                if (object3D.GetType() == typeof(Triangle))
                {
                    int indexOfTransformation = object3D.getIndexOfTransformation();
                    bool addedTriangle = false;

                    // group triangles with the same index of transformation
                    foreach(List<Triangle> triangleSublist in triangles) 
                    {

                        if(triangleSublist[0].getIndexOfTransformation() == indexOfTransformation)
                        {
                            triangleSublist.Add(object3D as Triangle);
                            addedTriangle = true;
                            break;
                        }
                    }

                    // creates a new sublist if the triangle wasn't added to any previous one
                    if(!addedTriangle)
                    {
                        List<Triangle> triangleSublist = new List<Triangle>();
                        triangleSublist.Add(object3D as Triangle);
                        triangles.Add(triangleSublist);
                    }
                }
            }
            foreach (Sphere sphere in spheres) sw.WriteLine(writeSphere(sphere));
            foreach (Box box in boxes) sw.WriteLine(writeBox(box));
            foreach (List<Triangle> triangleSublist in triangles) sw.WriteLine(writeTriangles(triangleSublist));

            sw.Close();
        }

        private Image readImage(StreamReader streamReader)
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
                        image.setHRes(Int32.Parse(values[0]));
                        image.setVRes(Int32.Parse(values[1]));
                    } else if(values.Length == 3)
                    {
                        image.setColor(new Color3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                    }
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return image;
        }

       private string writeImage(Image image)
       {
            string text = "Image\n{\n";
            text += "\t" + image.getHRes() + " " + image.getVRes() + "\n";
            text += "\t" + Math.Round(image.getColor().getR(), 2) + " " + Math.Round(image.getColor().getG(), 2) + " " + Math.Round(image.getColor().getB(), 2) + "\n"; 
            text += "}\n";

            return text;
       }

        private Transformation readTransformation(StreamReader streamReader)
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

        private string writeTransformation(Transformation transformation)
        {
            string text = "Transformation\n{\n";
            text += "\tT " + transformation.getTranslation().getX() + " " + transformation.getTranslation().getY() + " " + transformation.getTranslation().getZ() + "\n"; 
            text += "\tRx " + transformation.getRotation().getX() + "\n";
            text += "\tRy " + transformation.getRotation().getY() + "\n";
            text += "\tRz " + transformation.getRotation().getZ() + "\n";
            text += "\tS " + transformation.getScale().getX() + " " + transformation.getScale().getY() + " " + transformation.getScale().getZ() + "\n";
            text += "}\n";

            return text;
        }

        private Material readMaterial(StreamReader streamReader)
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

        private string writeMaterial(Material material)
        {
            string text = "Material\n{\n";
            text += "\t" + material.getColor().getR() + " " + material.getColor().getG() + " " + material.getColor().getB() + "\n";
            text += "\t" + material.getAmbient() + " " + material.getDiffuse() + " " + material.getSpecular() + " " + material.getRefraction() + " " + material.getIndexOfRefraction() + "\n";
            text += "}\n";

            return text;
        }

        private Camera readCamera(StreamReader streamReader)
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
                            camera.setTransformation(this.transformations[Int32.Parse(values[0])]);
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

        private string writeCamera(Camera camera)
        {
            string text = "Camera\n{\n";
            text += "\t" + camera.getIndexOfTransformation() + "\n";
            text += "\t" + camera.getDistance() + "\n";
            text += "\t" + camera.getFieldOfVision() + "\n";
            text += "}\n";

            return text;
        }

        private Light readLight(StreamReader streamReader)
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

        private string writeLight(Light light)
        {
            string text = "Light\n{\n";
            text += "\t" + light.getIndexOfTransformation() + "\n";
            text += "\t" + light.getColor().getR() + " " + light.getColor().getG() + " " + light.getColor().getB() + "\n";
            text += "}\n";

            return text;
        }

        private Sphere readSphere(StreamReader streamReader)
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
                            sphere.setMaterial(this.materials[Int32.Parse(values[0])]);
                            break;
                    }

                    lineIndex++;
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return sphere;
        }

        private string writeSphere(Sphere sphere)
        {
            string text = "Sphere\n{\n";
            text += "\t" + sphere.getIndexOfTransformation() + "\n";
            text += "\t" + sphere.getIndexOfMaterial() + "\n";
            text += "}\n";

            return text;
        }

        private Box readBox(StreamReader streamReader)
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
                            box.setMaterial(this.materials[Int32.Parse(values[0])]);
                            break;
                    }

                    lineIndex++;
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return box;
        }

        private string writeBox(Box box)
        {
            string text = "Box\n{\n";
            text += "\t" + box.getIndexOfTransformation() + "\n";
            text += "\t" + box.getIndexOfMaterial() + "\n";
            text += "}\n";

            return text;
        }

        private List<Triangle> readTriangles(StreamReader streamReader)
        {
            List<Triangle> triangles = new List<Triangle>();
            Triangle triangle = new Triangle();
            string line;
            bool isInsideBrackets = false;
            int lineIndex = 0;
            int? indexOfTransformation = null;

            while ((line = streamReader.ReadLine()) != null && line.Trim() != "}")
            {
                if (isInsideBrackets)
                {
                    string[] values = line.Trim().Split(" ");

                    if (indexOfTransformation == null) indexOfTransformation = Int32.Parse(values[0]);
                    else
                    {
                        switch (lineIndex)
                        {
                            case 0:
                                triangle = new Triangle();
                                triangle.setIndexOfTransformation(indexOfTransformation ?? default);
                                triangle.setIndexOfMaterial(Int32.Parse(values[0]));
                                triangle.setMaterial(this.materials[Int32.Parse(values[0])]);
                                break;

                            case 1:
                                triangle.setV1(new Vector3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                                break;

                            case 2:
                                triangle.setV2(new Vector3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                                break;

                            case 3:
                                triangle.setV3(new Vector3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                                triangles.Add(triangle);
                                break;
                        }

                        if (lineIndex == 3) lineIndex = 0;
                        else lineIndex++;
                    }
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return triangles;
        }

        private string writeTriangles(List<Triangle> triangles)
        {
            string text = "Triangles\n{\n";
            text += "\t" + triangles[0].getIndexOfTransformation() + "\n";

            string writeVertex(Vector3 vertex)
            {
                double x = Math.Round(vertex.getX(), 6),
                       y = Math.Round(vertex.getY(), 6),
                       z = Math.Round(vertex.getZ(), 6);

                return "\t" + x + " " + y + " " + z + "\n";
            }

            foreach(Triangle triangle in triangles)
            {
                text += "\t" + triangle.getIndexOfMaterial() + "\n";
                text += writeVertex(triangle.getV1());
                text += writeVertex(triangle.getV2());
                text += writeVertex(triangle.getV3());
            }

            text += "}\n";

            return text;
        }
    }
}
