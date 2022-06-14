using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cosig_work02
{
    public partial class RayTracer : Form
    {
        // File to read
        OpenFileDialog file;

        private List<Image> images = new List<Image>();
        private List<Transformation> transformations = new List<Transformation>();
        private List<Material> materials = new List<Material>();
        private List<Camera> cameras = new List<Camera>();
        private List<Light> lights = new List<Light>();
        private List<Object3D> objects = new List<Object3D>(); // Spheres, Boxes, Triangles
        private Ray[,] rays;

        // Lighting
        private bool hasAmbient = true,
                     hasDiffuse = true,
                     hasSpecular = true,
                     hasRefraction = true;

        // Recursion Depth
        int recursionDepth = 2;

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
            Object3D foundObject = new Triangle();

            foreach (Object3D object3D in objects)
            {
                bool found = object3D.intersect(ray, hit);
                if (found) foundObject = object3D;
            }

            if (hit.getFoundState() == true)
            {
                 Color3 color = new Color3(0, 0, 0);

                 foreach (Light light in lights) 
                 {
                    if (hasAmbient)
                    {
                        // calculates ambient reflection 
                        Color3 a = Color3.multiplyColors(light.getColor(), hit.getMaterial().getColor()),
                               b = Color3.multiplyColorByScalar(hit.getMaterial().getAmbient(), a);
                        color = Color3.addColors(color, b);
                    }

                    if (hasDiffuse)
                    {
                        // calculates diffuse reflection
                        Vector3 lightPosition = light.getTransformation().applyTransformationToPoint(new Vector3(0, 0, 0)),
                                i = Vector3.subtractVectors(lightPosition, hit.getPoint());
                        double tLight = Vector3.calculateVectorLength(i);
                        i = Vector3.normalizeVector(i);

                        double cosTheta = Vector3.calculateDotProduct(hit.getNormal(), i);
                        if (cosTheta > 0.0)
                        {
                            Ray shadowRay = new Ray(hit.getPoint(), i);
                            Hit shadowHit = new Hit();
                            shadowHit.setFoundState(false);
                            shadowHit.setTMin(tLight);

                            foreach (Object3D object3D in objects)
                            {
                                if (object3D == foundObject) continue; // don't calculate the shadow on the object itself

                                object3D.intersect(shadowRay, shadowHit);

                                if (shadowHit.getFoundState() == true) break;
                            }

                            if (shadowHit.getFoundState() == false)
                            {
                                Color3 c = Color3.multiplyColors(light.getColor(), hit.getMaterial().getColor()),
                                       d = Color3.multiplyColorByScalar(hit.getMaterial().getDiffuse(), c),
                                       e = Color3.multiplyColorByScalar(cosTheta, d);
                                color = Color3.addColors(color, e);
                            }
                        }
                    }
                 }

                 if(rec > 0)
                 {
                    double cosThetaV = -Vector3.calculateDotProduct(ray.getDirection(), hit.getNormal()),
                           specular = hit.getMaterial().getSpecular(),
                           refraction = hit.getMaterial().getRefraction(),
                           indexOfRefraction = hit.getMaterial().getIndexOfRefraction(),
                           epsilon = 1.0 * Math.Pow(10, -6);

                    if (hasSpecular)
                    {
                        // calculates specular reflection
                        if (specular > 0.0) // the material reflects specular light
                        {
                            // calculate reflected ray's direction
                            Vector3 reflectedRayDirection = Vector3.multiplyVectorByScalar(2.0 * cosThetaV, hit.getNormal());
                            reflectedRayDirection = Vector3.addVectors(ray.getDirection(), reflectedRayDirection);
                            reflectedRayDirection = Vector3.normalizeVector(reflectedRayDirection);

                            // create reflected ray
                            Vector3 temp0 = Vector3.multiplyVectorByScalar(epsilon, hit.getNormal()),
                                    reflectedRayOrigin = Vector3.addVectors(hit.getPoint(), temp0);
                            Ray reflectedRay = new Ray(reflectedRayOrigin, reflectedRayDirection);

                            // apply reflection
                            // schlick approximation
                            double temp1 = 1.0 - specular,
                                   temp2 = Math.Pow(1.0 - cosThetaV, 5),
                                   temp3 = specular + (temp1 * temp2);
                            Color3 temp4 = Color3.multiplyColorByScalar(temp3, hit.getMaterial().getColor()),
                                   temp5 = Color3.multiplyColors(temp4, traceRay(reflectedRay, rec - 1));
                            color = Color3.addColors(color, temp5);
                        }
                    }

                    if (hasRefraction)
                    {
                        // calculates refraction 
                        if (refraction > 0.0) // the material refracts light
                        {
                            double eta = 1.0 / indexOfRefraction,
                                   cosThetaR = Math.Sqrt(1.0 - eta * eta * (1.0 - cosThetaV * cosThetaV));

                            if (cosThetaV < 0.0)
                            {
                                eta = indexOfRefraction;
                                cosThetaR = -cosThetaR;
                            }

                            // calculates refracted ray's direction  
                            double calc1 = eta * cosThetaV - cosThetaR;
                            Vector3 calc2 = Vector3.multiplyVectorByScalar(calc1, hit.getNormal()),
                                    calc3 = Vector3.multiplyVectorByScalar(eta, ray.getDirection()),
                                    refractedRayDirection = Vector3.addVectors(calc2, calc3);
                            refractedRayDirection = Vector3.normalizeVector(refractedRayDirection);

                            // create refracted ray
                            Ray refractedRay = new Ray(hit.getPoint(), refractedRayDirection);

                            // apply refraction
                            Color3 calc4 = Color3.multiplyColorByScalar(indexOfRefraction, traceRay(refractedRay, rec - 1)),
                                   calc5 = Color3.multiplyColors(hit.getMaterial().getColor(), calc4);
                            color = Color3.addColors(color, calc5);
                        }
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

            if (open.ShowDialog() == DialogResult.OK)
            {
                file = open;
                fileName.Text = Path.GetFileName(file.FileName);
                startError.Visible = false;

                objects.Clear();

                // Reads File
                Parser parser = new Parser(file.FileName); // FileName -> File path

                images = parser.images;
                transformations = parser.transformations;
                materials = parser.materials;
                cameras = parser.cameras;
                lights = parser.lights;
                objects.AddRange(parser.spheres);
                objects.AddRange(parser.boxes);
                //objects.AddRange(parser.triangles);
            }
        }

        private void display3DScene()
        {
            if (file != null)
            {
                rays = Ray.createRays(cameras[0], images[0]);

                Bitmap image = new Bitmap(images[0].getHRes(), images[0].getVRes());

                for (int i = 0; i < rays.GetLength(0); i++)
                {
                    for (int j = 0; j < rays.GetLength(1); j++)
                    {
                        Color3 pixel = traceRay(rays[i, j], recursionDepth);
                        image.SetPixel(i, j, pixel.convertToColor());
                    }
                }

                imageRender.Image = image;
            }
            else startError.Visible = true;
        }

        // Save Image
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

        // Save Scene
        private void saveSceneBtn_Click(object sender, EventArgs e)
        {
            // reverse parser ###################################################
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0; // goes to main menu

            // clears scene
            objects.Clear();
            images = new List<Image>();
            transformations = new List<Transformation>();
            materials = new List<Material>();
            cameras = new List<Camera>();
            lights = new List<Light>();
            imageRender.Image = null;
            fileName.Text = "";
            file = null;
            startError.Visible = false;
        }

        // RENDER ---------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void startRenderBtn_Click(object sender, EventArgs e) // Starts Render
        {
            display3DScene();
        }

        private void startRenderBtn_MouseEnter(object sender, EventArgs e) // Start Btn Hover
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 80, 80, 80);
        }

        private void startRenderBtn_MouseLeave(object sender, EventArgs e) // Start Btn Not Hover
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 40, 40, 40);
        }

        // Lights
        private void ambientCheckbox_CheckedChanged(object sender, EventArgs e) 
        {
            hasAmbient = !hasAmbient;
        }

        private void diffuseCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            hasDiffuse = !hasDiffuse;
        }

        private void specularCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            hasSpecular = !hasSpecular;
        }

        private void refractionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            hasRefraction = !hasRefraction;
        }

        private void recursionDepthInput_ValueChanged(object sender, EventArgs e) // Recursion Depth
        {
            recursionDepth = (int)recursionDepthInput.Value;
        }
    }
}
