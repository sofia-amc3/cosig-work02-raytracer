using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace work02_raytracer
{
    public partial class RayTracer : Form
    {
        public RayTracer()
        {
            InitializeComponent();
            InitializeFont();
        }

        private void InitializeFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            int[] fontsLength =
            {
                Properties.Resources.Montserrat_Regular.Length,
                Properties.Resources.Montserrat_Italic.Length,
                Properties.Resources.Montserrat_Medium.Length,
                Properties.Resources.Montserrat_SemiBold.Length,
                Properties.Resources.Montserrat_Bold.Length,
                Properties.Resources.Montserrat_ExtraBold.Length
            };

            // create a buffer to read in to
            byte[][] fontsData =
            {
                Properties.Resources.Montserrat_Regular,
                Properties.Resources.Montserrat_Italic,
                Properties.Resources.Montserrat_Medium,
                Properties.Resources.Montserrat_SemiBold,
                Properties.Resources.Montserrat_Bold,
                Properties.Resources.Montserrat_ExtraBold
            };

            for (int i = 0; i < fontsLength.Length; i++)
            {
                // create an unsafe memory block for the font data
                System.IntPtr data = Marshal.AllocCoTaskMem(fontsLength[i]);

                // copy the bytes to the unsafe memory block
                Marshal.Copy(fontsData[i], 0, data, fontsLength[i]);

                // pass the font to the font collection
                pfc.AddMemoryFont(data, fontsLength[i]);
            }

            List<Control> labels = GetControls(this, typeof(Label));
            List<Control> buttons = GetControls(this, typeof(Button));

            foreach (Control label in labels)
            {
                if (label.GetType() == typeof(Label))
                {
                    ((Label)label).UseCompatibleTextRendering = true;
                    label.Font = new Font(pfc.Families[0], label.Font.Size);
                }
            }
        }

        public List<Control> GetControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type).ToList();
        }

        // FIRST SCREEN ----------------------------------------------------------------------------------------------------------------------------------------------------------
        private void startBtn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1; // goes to application
        }

        // GLOBAL ----------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void loadImgBtn_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Text|*.txt";

            if(open.ShowDialog() == DialogResult.OK)
            {
                // display 3D Scene ####################################################################
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
