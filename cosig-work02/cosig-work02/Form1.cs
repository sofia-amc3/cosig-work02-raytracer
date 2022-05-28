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
        public RayTracer()
        {
            InitializeComponent();
        }

        // FIRST SCREEN ----------------------------------------------------------------------------------------------------------------------------------------------------------
        private void startBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1; // goes to application
        }

        // GLOBAL ----------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void loadSceneBtn_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Text|*.txt";

            if(open.ShowDialog() == DialogResult.OK)
            {
                Parser.parseFile(open.FileName); // FileName = path

                // display 3D Scene #############################################################################################
            }
        }

        private void saveImgBtn_Click(object sender, EventArgs e)
        {
            if(imageUploaded.BackgroundImage != null)
            {
                SaveFileDialog dialog = new SaveFileDialog
                {
                    Filter = "Images|*.png;*.bmp;*.jpg"
                };

                if (dialog.ShowDialog() == DialogResult.OK) imageUploaded.BackgroundImage.Save(dialog.FileName, ImageFormat.Png);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0; // goes to main menu
        }
    }
}
