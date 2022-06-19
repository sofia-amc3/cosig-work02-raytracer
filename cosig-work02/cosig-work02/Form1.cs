using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace cosig_work02
{
    public partial class RayTracer : Form
    {
        // File to read
        OpenFileDialog file = null;

        // Lists of Scene's content 
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

        // DISPLAYS/CREATES SCENE ------------------------------------------------------------------------------------------------------------------------------------------------
        private Color3 traceRay(Ray ray, int rec)
        {
            Hit hit = new Hit();
            hit.setFoundState(false);
            hit.setTMin(1 * Math.Pow(10, 12));
            Object3D foundObject = new Triangle();

            foreach (Object3D object3D in objects)
            {
                bool found = object3D.intersect(ray, hit);
                // if the current object is intersected, saves it (we'll use this on the shadow's calculations)
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
                        // https://www.scratchapixel.com/lessons/3d-basic-rendering/introduction-to-shading/reflection-refraction-fresnel
                        if (refraction > 0.0) // the material refracts light
                        {
                            Vector3 n = hit.getNormal(),
                                    i = ray.getDirection();
                            double max = 1,
                                   min = -1,
                                   etai = 1,
                                   etat = hit.getMaterial().getIndexOfRefraction(); 

                            // in the previous if (reflection) this value is negative, let's make it positive
                            cosThetaV = -cosThetaV;
                            Math.Clamp(cosThetaV, min, max);

                            if (cosThetaV < 0) cosThetaV = -cosThetaV;
                            else
                            {
                                // swap etai with etat
                                double temp = etai;
                                etai = etat;
                                etat = temp;
                                // normal = -normal
                                n = new Vector3(-n.getX(), -n.getY(), -n.getZ());
                            }

                            double eta = etai / etat,
                                   cosThetaR = 1 - eta * eta * (1 - cosThetaV * cosThetaV);
                            Vector3 refractedRayDirection = new Vector3(0, 0, 0);

                            if (cosThetaR >= 0) 
                            {
                                double calc1 = eta * cosThetaV - Math.Sqrt(cosThetaR);
                                Vector3 calc2 = Vector3.multiplyVectorByScalar(calc1, n),
                                        calc3 = Vector3.multiplyVectorByScalar(eta, i),
                                        calc4 = Vector3.addVectors(calc3, calc2);

                                refractedRayDirection = calc4;
                            }

                            refractedRayDirection = Vector3.normalizeVector(refractedRayDirection);

                            // create refracted ray
                            Ray refractedRay = new Ray(hit.getPoint(), refractedRayDirection);

                            // apply refraction
                            Color3 calc5 = Color3.multiplyColorByScalar(etat, traceRay(refractedRay, rec - 1)),
                                   calc6 = Color3.multiplyColors(hit.getMaterial().getColor(), calc5);
                            color = Color3.addColors(color, calc6); 
                        }
                    }
                 }
                 return color; // if an object is intersected, returns its color
            }
            else return images[0].getColor(); // else puts the image's background color 
        }

        private void display3DScene() // called after clicking on "Start"
        {
            rays = Ray.createRays(cameras[0], images[0]); // creates initial rays

            Bitmap image = new Bitmap(images[0].getHRes(), images[0].getVRes()); // creates bitmap

            for (int i = 0; i < rays.GetLength(0); i++)
            {
                for (int j = 0; j < rays.GetLength(1); j++)
                {
                    Color3 pixel = traceRay(rays[i, j], recursionDepth);
                    image.SetPixel(i, j, Color3.convertToColor(pixel));
                }
            }

            imageRender.Image = image; // applies the created bitmap into the picturebox
        }

        // SCENE CONTROLS ------------------------------------------------------------------------------------------------------------------------------------
        private void loadSceneBtn_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                clearScene(); // Clears any previous loaded scenes
                file = open;
                fileName.Text = Path.GetFileName(file.FileName);

                // Reads File
                Parser parser = new Parser(file.FileName); // FileName -> File path
                images = parser.images;
                transformations = parser.transformations;
                materials = parser.materials;
                cameras = parser.cameras;
                lights = parser.lights;
                objects.AddRange(parser.spheres);
                objects.AddRange(parser.boxes);
                objects.AddRange(parser.triangles);

                // Puts values in inputs
                // Transformation - Center
                Vector3 camTransformation = cameras[0].getTransformation().getTranslation(),
                        camRotation = cameras[0].getTransformation().getRotation();
                transformXInput.Value = (decimal) camTransformation.getX();
                transformYInput.Value = (decimal) camTransformation.getY();
                transformZInput.Value = (decimal) camTransformation.getZ();
                // Transformation - Orientation
                transformHInput.Value = (decimal) camRotation.getX(); // Rx
                transformVInput.Value = (decimal) camRotation.getZ(); // Rz 
                // Camera
                camDistanceInput.Value = (decimal) cameras[0].getDistance();
                camFieldInput.Value = (decimal) cameras[0].getFieldOfVision(); 
                // Image
                Color newColor = Color3.convertToColor(images[0].getColor());
                imageResHInput.Value = images[0].getHRes();
                imageResVInput.Value = images[0].getVRes();
                bgColorRInput.Value = newColor.R;
                bgColorGInput.Value = newColor.G;
                bgColorBInput.Value = newColor.B;
            }
        }

        // Save Image (PNG File)
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

        // Save Scene (TXT File)
        private void saveSceneBtn_Click(object sender, EventArgs e)
        {
            // reverse parser #########################################################################################################################################
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0; // goes to main menu
            clearScene();
        }

        private void clearScene()
        {
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
        // Starts Render
        private void startRenderBtn_Click(object sender, EventArgs e) 
        {
            if (file != null)
            {
                // get final object's tranformation
                foreach (Object3D object3D in objects)
                {
                                   // gets object's transformation
                    Transformation objectTransformation = this.transformations[object3D.getIndexOfTransformation()],
                                   // clones the camera's transformation, not to interfer with its original one
                                   transformation = this.cameras[0].getTransformation().clone();
                    // multiplies camera's transformation by the object's one
                    transformation.multiplyByMatrix(objectTransformation.getTransformationMatrix());
                    // sets object transformation
                    object3D.setTransformation(transformation);
                }

                // get final lights' tranformation
                foreach (Light light in lights)
                {
                                   // gets light's transformation
                    Transformation objectTransformation = this.transformations[light.getIndexOfTransformation()],
                                   // clones the camera's transformation, not to interfer with its original one
                                   transformation = this.cameras[0].getTransformation().clone();
                    // multiplies camera's transformation by the light's one
                    transformation.multiplyByMatrix(objectTransformation.getTransformationMatrix());
                    // sets light transformation
                    light.setTransformation(transformation);
                }

                display3DScene();
            }
            else startError.Visible = true;
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

        // Recursion Depth
        private void recursionDepthInput_ValueChanged(object sender, EventArgs e) 
        {
            recursionDepth = (int)recursionDepthInput.Value;
        }

        // Transformation - Center
        private void transformXInput_ValueChanged(object sender, EventArgs e)
        {
            if (cameras.Count > 0)
            {
                // calculates the difference between the new translation (set on the input) and the previously obtained one
                double x = (double)transformXInput.Value - cameras[0].getTransformation().getTranslation().getX();
                cameras[0].getTransformation().translate(x, 0, 0);
            }
        }

        private void transformYInput_ValueChanged(object sender, EventArgs e)
        {
            if (cameras.Count > 0)
            {
                // calculates the difference between the new translation (set on the input) and the previously obtained one
                double y = (double)transformYInput.Value - cameras[0].getTransformation().getTranslation().getY();
                cameras[0].getTransformation().translate(0, y, 0);
            }
        }

        private void transformZInput_ValueChanged(object sender, EventArgs e)
        {
            if (cameras.Count > 0)
            {
                // calculates the difference between the new translation (set on the input) and the previously obtained one
                double z = (double)transformZInput.Value - cameras[0].getTransformation().getTranslation().getZ();
                cameras[0].getTransformation().translate(0, 0, z);
            }
        }

        // Transformation - Orientation
        private void transformHInput_ValueChanged(object sender, EventArgs e)
        {
            if (cameras.Count > 0)
            {
                // calculates the difference between the new rotation (set on the input) and the previously obtained one
                double x = (double)transformHInput.Value - cameras[0].getTransformation().getRotation().getX();
                cameras[0].getTransformation().rotateX(x);
            }
        }

        private void transformVInput_ValueChanged(object sender, EventArgs e)
        {
            if (cameras.Count > 0)
            {
                // calculates the difference between the new rotation (set on the input) and the previously obtained one
                double z = (double)transformVInput.Value - cameras[0].getTransformation().getRotation().getZ();
                cameras[0].getTransformation().rotateZ(z);
            }
        }

        // Camera 
        private void camDistanceInput_ValueChanged(object sender, EventArgs e)
        {
            if (cameras.Count > 0) cameras[0].setDistance((double)camDistanceInput.Value);
        }

        private void camFieldInput_ValueChanged(object sender, EventArgs e)
        {
            if (cameras.Count > 0) cameras[0].setFieldOfVision((double)camFieldInput.Value);
        }

        // Image
        private void imageResHInput_ValueChanged(object sender, EventArgs e)
        {
            if (images.Count > 0) images[0].setHRes((int)imageResHInput.Value);
        }

        private void imageResVInput_ValueChanged(object sender, EventArgs e)
        {
            if (images.Count > 0) images[0].setVRes((int)imageResVInput.Value);
        }

        // Image - Background Color
        private void setImageBgColor(Nullable<int> r, Nullable<int> g, Nullable<int> b)
        {
            if (images.Count > 0)
            {
                Color color = Color3.convertToColor(images[0].getColor());

                if (r == null) r = color.R;
                if (g == null) g = color.G;
                if (b == null) b = color.B;

                images[0].setColor(Color3.convertFromColor(Color.FromArgb(255, r ?? default, g ?? default, b ?? default)));
            }
        }

        private void bgColorRInput_ValueChanged(object sender, EventArgs e)
        {
            setImageBgColor((int)bgColorRInput.Value, null, null);
        }

        private void bgColorGInput_ValueChanged(object sender, EventArgs e)
        {
            setImageBgColor(null, (int)bgColorGInput.Value, null);
        }

        private void bgColorBInput_ValueChanged(object sender, EventArgs e)
        {
            setImageBgColor(null, null, (int)bgColorBInput.Value);
        }
    }
}
