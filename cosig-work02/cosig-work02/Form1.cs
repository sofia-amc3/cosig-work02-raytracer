using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cosig_work02
{
    public partial class RayTracer : Form
    {
        private List<Image> images = new List<Image>();
        private List<Transformation> transformations = new List<Transformation>();
        private List<Material> materials = new List<Material>();
        private List<Camera> cameras = new List<Camera>();
        private List<Light> lights = new List<Light>();
        private List<Object3D> objects = new List<Object3D>(); // Spheres, Boxes, Triangles
        private Ray[,] rays;

        public RayTracer()
        {
            InitializeComponent();
        }

        // FIRST SCREEN ----------------------------------------------------------------------------------------------------------------------------------------------------------
        private void startBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1; // goes to application
        }

        // SCENE -----------------------------------------------------------------------------------------------------------------------------------------------------------------
        private Color3 traceRay(Ray ray, int rec)
        {
            Hit hit = new Hit();
            hit.setFoundState(false);
            hit.setTMin(1 * Math.Pow(10, 12));

            foreach(Object3D object3D in objects) object3D.intersect(ray, hit);

            if (hit.getFoundState() == true)
            {
                 Color3 color = new Color3(0, 0, 0);

                 foreach (Light light in lights) 
                 {
                     // calculates ambient reflection 
                     Color3 a = Color3.multiplyColors(light.getColor(), hit.getMaterial().getColor()),
                            b = Color3.multiplyColorByScalar(hit.getMaterial().getAmbient(), a);
                     color = Color3.addColors(color, b);

                     // calculates diffuse reflection
                     Vector3 i = Vector3.subtractVectors(light.getTransformation().applyTransformationToPoint(new Vector3(0, 0, 0)), hit.getPoint());
                     i = Vector3.normalizeVector(i);

                     double cosTheta = Vector3.calculateDotProduct(hit.getNormal(), i);
                     if (cosTheta > 0.0) 
                     {
                         Color3 c = Color3.multiplyColors(light.getColor(), hit.getMaterial().getColor()),
                                d = Color3.multiplyColorByScalar(hit.getMaterial().getDiffuse(), c),
                                e = Color3.multiplyColorByScalar(cosTheta, d);
                         color = Color3.addColors(color, e);
                     }
                 }

                 return Color3.multiplyColorByScalar(1 / lights.Count(), color);
            }
            else return images[0].getColor();
        }

        private void loadSceneBtn_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text|*.txt";

            if(open.ShowDialog() == DialogResult.OK)
            {
                Parser parser = new Parser(open.FileName); // FileName -> File path

                images = parser.images;
                transformations = parser.transformations;
                materials = parser.materials;
                cameras = parser.cameras;
                lights = parser.lights;
                objects.AddRange(parser.spheres);
                objects.AddRange(parser.boxes);
                objects.AddRange(parser.triangles);

                // display 3D Scene 
                rays = Ray.createRays(cameras[0], images[0]);

                Bitmap image = new Bitmap(images[0].getHRes(), images[0].getVRes());

                for (int i = 0; i < rays.GetLength(0); i++) 
                {
                    for (int j = 0; j < rays.GetLength(1); j++) 
                    {
                        Color3 pixel = traceRay(rays[i, j], 1);
                        image.SetPixel(i, j, pixel.convertToColor());
                    }
                }

                imageRender.Image = image;
            }
        }

        private void saveImgBtn_Click(object sender, EventArgs e)
        {
            if(imageRender.Image != null)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Images|*.png;*.bmp;*.jpg"
                };

                if (dialog.ShowDialog() == DialogResult.OK) imageRender.Image.Save(dialog.FileName, ImageFormat.Png);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0; // goes to main menu
        }
    }
}
