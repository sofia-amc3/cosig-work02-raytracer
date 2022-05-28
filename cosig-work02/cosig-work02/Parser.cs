using System;
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
            StreamReader streamReader = new StreamReader(path);
            string line;

            while((line = streamReader.ReadLine()) != null)
            {
                switch(line.Trim())
                {
                    case "Image":
                        Image image = readImage(streamReader);
                        break;

                    case "Transformation":
                        break;

                    case "Camera":
                        break;

                    case "Light":
                        break;

                    case "Material":
                        break;

                    case "Triangles":
                        break;

                    case "Sphere":
                        break;

                    case "Box":
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
                        image.setImageResWidth(Int32.Parse(values[0]));
                        image.setImageResHeight(Int32.Parse(values[1]));
                    } else if(values.Length == 3)
                    {
                        image.setImageColor(new Color3(Double.Parse(values[0]), Double.Parse(values[1]), Double.Parse(values[2])));
                    }
                }

                if (line.Trim() == "{") isInsideBrackets = true;
            }

            return image;
        }
    }
}
