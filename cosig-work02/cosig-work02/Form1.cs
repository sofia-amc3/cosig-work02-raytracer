﻿using System;
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
        private List<Sphere> spheres = new List<Sphere>();
        private List<Box> boxes = new List<Box>();
        private List<Triangles> triangles = new List<Triangles>();
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
                spheres = parser.spheres;
                boxes = parser.boxes;
                triangles = parser.triangles;

                // display 3D Scene 
                rays = Ray.createRays(cameras[0], images[0]);

                Bitmap image = new Bitmap(images[0].getHRes(), images[0].getVRes());

                for (int i = 0; i < rays.GetLength(0); i++) 
                {
                    for (int j = 0; j < rays.GetLength(1); j++) 
                    {
                        Color3 pixel = Ray.traceRay(rays[i, j], 1);
                        image.SetPixel(i, j, pixel.convertToColor());
                    }
                }

                imageRender.Image = image;
            }
        }

        private void saveImgBtn_Click(object sender, EventArgs e)
        {
            if(imageRender.BackgroundImage != null)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Images|*.png;*.bmp;*.jpg"
                };

                if (dialog.ShowDialog() == DialogResult.OK) imageRender.BackgroundImage.Save(dialog.FileName, ImageFormat.Png);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0; // goes to main menu
        }
    }
}
