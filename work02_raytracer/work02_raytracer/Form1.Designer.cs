
namespace work02_raytracer
{
    partial class RayTracer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RayTracer));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mainMenu = new System.Windows.Forms.TabPage();
            this.startBtn = new System.Windows.Forms.Button();
            this.credits = new System.Windows.Forms.Label();
            this.projectTitle = new System.Windows.Forms.Label();
            this.application = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBarLabel = new System.Windows.Forms.Label();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.bgColorBInput = new System.Windows.Forms.NumericUpDown();
            this.bgColorBLabel = new System.Windows.Forms.Label();
            this.bgColorGInput = new System.Windows.Forms.NumericUpDown();
            this.bgColorGLabel = new System.Windows.Forms.Label();
            this.bgColorRInput = new System.Windows.Forms.NumericUpDown();
            this.bgColorRLabel = new System.Windows.Forms.Label();
            this.colorComponentsLabel = new System.Windows.Forms.Label();
            this.dividerBottom = new System.Windows.Forms.Label();
            this.dividerTop = new System.Windows.Forms.Label();
            this.camFieldInput = new System.Windows.Forms.NumericUpDown();
            this.camFieldLabel = new System.Windows.Forms.Label();
            this.camDistanceInput = new System.Windows.Forms.NumericUpDown();
            this.camDistanceLabel = new System.Windows.Forms.Label();
            this.cameraLabel = new System.Windows.Forms.Label();
            this.transformOrientLabel = new System.Windows.Forms.Label();
            this.transformVInput = new System.Windows.Forms.NumericUpDown();
            this.transformVLabel = new System.Windows.Forms.Label();
            this.transformHInput = new System.Windows.Forms.NumericUpDown();
            this.transformHLabel = new System.Windows.Forms.Label();
            this.transformCenterLabel = new System.Windows.Forms.Label();
            this.transformZInput = new System.Windows.Forms.NumericUpDown();
            this.transformZLabel = new System.Windows.Forms.Label();
            this.transformYInput = new System.Windows.Forms.NumericUpDown();
            this.transformYLabel = new System.Windows.Forms.Label();
            this.transformXInput = new System.Windows.Forms.NumericUpDown();
            this.transformXLabel = new System.Windows.Forms.Label();
            this.transformationLabel = new System.Windows.Forms.Label();
            this.imageResVInput = new System.Windows.Forms.NumericUpDown();
            this.imageResVLabel = new System.Windows.Forms.Label();
            this.imageResHInput = new System.Windows.Forms.NumericUpDown();
            this.imageResHLabel = new System.Windows.Forms.Label();
            this.imageResLabel = new System.Windows.Forms.Label();
            this.refractionCheckbox = new System.Windows.Forms.CheckBox();
            this.specularCheckbox = new System.Windows.Forms.CheckBox();
            this.diffuseCheckbox = new System.Windows.Forms.CheckBox();
            this.ambientCheckbox = new System.Windows.Forms.CheckBox();
            this.lightingLabel = new System.Windows.Forms.Label();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.startRenderBtn = new System.Windows.Forms.Button();
            this.recursionDepthInput = new System.Windows.Forms.NumericUpDown();
            this.recursionDepthLabel = new System.Windows.Forms.Label();
            this.imageUploaded = new System.Windows.Forms.PictureBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.saveImgBtn = new System.Windows.Forms.Button();
            this.loadSceneBtn = new System.Windows.Forms.Button();
            this.rendererLabel = new System.Windows.Forms.Label();
            this.globalLabel = new System.Windows.Forms.Label();
            this.saveSceneBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.application.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorBInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorGInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorRInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camFieldInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camDistanceInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformVInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformHInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformZInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformYInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformXInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageResVInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageResHInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageUploaded)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.mainMenu);
            this.tabControl1.Controls.Add(this.application);
            this.tabControl1.Location = new System.Drawing.Point(-6, -29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1276, 718);
            this.tabControl1.TabIndex = 0;
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mainMenu.Controls.Add(this.startBtn);
            this.mainMenu.Controls.Add(this.credits);
            this.mainMenu.Controls.Add(this.projectTitle);
            this.mainMenu.Location = new System.Drawing.Point(4, 25);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(3);
            this.mainMenu.Size = new System.Drawing.Size(1268, 689);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "mainMenu";
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.startBtn.FlatAppearance.BorderSize = 0;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startBtn.Location = new System.Drawing.Point(532, 438);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(204, 60);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // credits
            // 
            this.credits.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.credits.Location = new System.Drawing.Point(334, 274);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(600, 135);
            this.credits.TabIndex = 1;
            this.credits.Text = resources.GetString("credits.Text");
            this.credits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // projectTitle
            // 
            this.projectTitle.Font = new System.Drawing.Font("Montserrat", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.projectTitle.Location = new System.Drawing.Point(14, 181);
            this.projectTitle.Name = "projectTitle";
            this.projectTitle.Size = new System.Drawing.Size(1240, 79);
            this.projectTitle.TabIndex = 0;
            this.projectTitle.Text = "RayTracer";
            this.projectTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // application
            // 
            this.application.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.application.Controls.Add(this.saveSceneBtn);
            this.application.Controls.Add(this.progressBar1);
            this.application.Controls.Add(this.progressBarLabel);
            this.application.Controls.Add(this.backgroundColorLabel);
            this.application.Controls.Add(this.bgColorBInput);
            this.application.Controls.Add(this.bgColorBLabel);
            this.application.Controls.Add(this.bgColorGInput);
            this.application.Controls.Add(this.bgColorGLabel);
            this.application.Controls.Add(this.bgColorRInput);
            this.application.Controls.Add(this.bgColorRLabel);
            this.application.Controls.Add(this.colorComponentsLabel);
            this.application.Controls.Add(this.dividerBottom);
            this.application.Controls.Add(this.dividerTop);
            this.application.Controls.Add(this.camFieldInput);
            this.application.Controls.Add(this.camFieldLabel);
            this.application.Controls.Add(this.camDistanceInput);
            this.application.Controls.Add(this.camDistanceLabel);
            this.application.Controls.Add(this.cameraLabel);
            this.application.Controls.Add(this.transformOrientLabel);
            this.application.Controls.Add(this.transformVInput);
            this.application.Controls.Add(this.transformVLabel);
            this.application.Controls.Add(this.transformHInput);
            this.application.Controls.Add(this.transformHLabel);
            this.application.Controls.Add(this.transformCenterLabel);
            this.application.Controls.Add(this.transformZInput);
            this.application.Controls.Add(this.transformZLabel);
            this.application.Controls.Add(this.transformYInput);
            this.application.Controls.Add(this.transformYLabel);
            this.application.Controls.Add(this.transformXInput);
            this.application.Controls.Add(this.transformXLabel);
            this.application.Controls.Add(this.transformationLabel);
            this.application.Controls.Add(this.imageResVInput);
            this.application.Controls.Add(this.imageResVLabel);
            this.application.Controls.Add(this.imageResHInput);
            this.application.Controls.Add(this.imageResHLabel);
            this.application.Controls.Add(this.imageResLabel);
            this.application.Controls.Add(this.refractionCheckbox);
            this.application.Controls.Add(this.specularCheckbox);
            this.application.Controls.Add(this.diffuseCheckbox);
            this.application.Controls.Add(this.ambientCheckbox);
            this.application.Controls.Add(this.lightingLabel);
            this.application.Controls.Add(this.elapsedTimeLabel);
            this.application.Controls.Add(this.startRenderBtn);
            this.application.Controls.Add(this.recursionDepthInput);
            this.application.Controls.Add(this.recursionDepthLabel);
            this.application.Controls.Add(this.imageUploaded);
            this.application.Controls.Add(this.exitBtn);
            this.application.Controls.Add(this.saveImgBtn);
            this.application.Controls.Add(this.loadSceneBtn);
            this.application.Controls.Add(this.rendererLabel);
            this.application.Controls.Add(this.globalLabel);
            this.application.Location = new System.Drawing.Point(4, 25);
            this.application.Name = "application";
            this.application.Padding = new System.Windows.Forms.Padding(3);
            this.application.Size = new System.Drawing.Size(1268, 689);
            this.application.TabIndex = 1;
            this.application.Text = "application";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.progressBar1.Location = new System.Drawing.Point(530, 610);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 31);
            this.progressBar1.TabIndex = 53;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // progressBarLabel
            // 
            this.progressBarLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.progressBarLabel.Location = new System.Drawing.Point(528, 574);
            this.progressBarLabel.Name = "progressBarLabel";
            this.progressBarLabel.Size = new System.Drawing.Size(204, 33);
            this.progressBarLabel.TabIndex = 52;
            this.progressBarLabel.Text = "Progress Bar";
            this.progressBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.progressBarLabel.Visible = false;
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.BackColor = System.Drawing.Color.Transparent;
            this.backgroundColorLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backgroundColorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.backgroundColorLabel.Location = new System.Drawing.Point(1068, 181);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(99, 23);
            this.backgroundColorLabel.TabIndex = 51;
            this.backgroundColorLabel.Text = "Background";
            this.backgroundColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bgColorBInput
            // 
            this.bgColorBInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bgColorBInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bgColorBInput.ForeColor = System.Drawing.Color.White;
            this.bgColorBInput.Location = new System.Drawing.Point(1093, 260);
            this.bgColorBInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bgColorBInput.Name = "bgColorBInput";
            this.bgColorBInput.Size = new System.Drawing.Size(43, 18);
            this.bgColorBInput.TabIndex = 50;
            // 
            // bgColorBLabel
            // 
            this.bgColorBLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bgColorBLabel.Location = new System.Drawing.Point(1068, 251);
            this.bgColorBLabel.Name = "bgColorBLabel";
            this.bgColorBLabel.Size = new System.Drawing.Size(26, 33);
            this.bgColorBLabel.TabIndex = 49;
            this.bgColorBLabel.Text = "B";
            this.bgColorBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bgColorGInput
            // 
            this.bgColorGInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bgColorGInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bgColorGInput.ForeColor = System.Drawing.Color.White;
            this.bgColorGInput.Location = new System.Drawing.Point(1093, 233);
            this.bgColorGInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bgColorGInput.Name = "bgColorGInput";
            this.bgColorGInput.Size = new System.Drawing.Size(43, 18);
            this.bgColorGInput.TabIndex = 48;
            // 
            // bgColorGLabel
            // 
            this.bgColorGLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bgColorGLabel.Location = new System.Drawing.Point(1068, 224);
            this.bgColorGLabel.Name = "bgColorGLabel";
            this.bgColorGLabel.Size = new System.Drawing.Size(26, 33);
            this.bgColorGLabel.TabIndex = 47;
            this.bgColorGLabel.Text = "G";
            this.bgColorGLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bgColorRInput
            // 
            this.bgColorRInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bgColorRInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bgColorRInput.ForeColor = System.Drawing.Color.White;
            this.bgColorRInput.Location = new System.Drawing.Point(1093, 207);
            this.bgColorRInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bgColorRInput.Name = "bgColorRInput";
            this.bgColorRInput.Size = new System.Drawing.Size(43, 18);
            this.bgColorRInput.TabIndex = 46;
            // 
            // bgColorRLabel
            // 
            this.bgColorRLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bgColorRLabel.Location = new System.Drawing.Point(1068, 198);
            this.bgColorRLabel.Name = "bgColorRLabel";
            this.bgColorRLabel.Size = new System.Drawing.Size(26, 33);
            this.bgColorRLabel.TabIndex = 45;
            this.bgColorRLabel.Text = "R";
            this.bgColorRLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorComponentsLabel
            // 
            this.colorComponentsLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.colorComponentsLabel.Location = new System.Drawing.Point(1068, 148);
            this.colorComponentsLabel.Name = "colorComponentsLabel";
            this.colorComponentsLabel.Size = new System.Drawing.Size(204, 33);
            this.colorComponentsLabel.TabIndex = 44;
            this.colorComponentsLabel.Text = "Color Components";
            this.colorComponentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dividerBottom
            // 
            this.dividerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dividerBottom.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dividerBottom.Location = new System.Drawing.Point(706, 539);
            this.dividerBottom.Name = "dividerBottom";
            this.dividerBottom.Size = new System.Drawing.Size(514, 3);
            this.dividerBottom.TabIndex = 43;
            this.dividerBottom.Text = " ";
            this.dividerBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dividerTop
            // 
            this.dividerTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dividerTop.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dividerTop.Location = new System.Drawing.Point(528, 107);
            this.dividerTop.Name = "dividerTop";
            this.dividerTop.Size = new System.Drawing.Size(690, 3);
            this.dividerTop.TabIndex = 42;
            this.dividerTop.Text = " ";
            this.dividerTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // camFieldInput
            // 
            this.camFieldInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.camFieldInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.camFieldInput.ForeColor = System.Drawing.Color.White;
            this.camFieldInput.Location = new System.Drawing.Point(1167, 379);
            this.camFieldInput.Name = "camFieldInput";
            this.camFieldInput.Size = new System.Drawing.Size(43, 18);
            this.camFieldInput.TabIndex = 41;
            // 
            // camFieldLabel
            // 
            this.camFieldLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.camFieldLabel.Location = new System.Drawing.Point(1068, 370);
            this.camFieldLabel.Name = "camFieldLabel";
            this.camFieldLabel.Size = new System.Drawing.Size(96, 33);
            this.camFieldLabel.TabIndex = 40;
            this.camFieldLabel.Text = "Field of View";
            this.camFieldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // camDistanceInput
            // 
            this.camDistanceInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.camDistanceInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.camDistanceInput.ForeColor = System.Drawing.Color.White;
            this.camDistanceInput.Location = new System.Drawing.Point(1167, 353);
            this.camDistanceInput.Name = "camDistanceInput";
            this.camDistanceInput.Size = new System.Drawing.Size(43, 18);
            this.camDistanceInput.TabIndex = 39;
            // 
            // camDistanceLabel
            // 
            this.camDistanceLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.camDistanceLabel.Location = new System.Drawing.Point(1068, 344);
            this.camDistanceLabel.Name = "camDistanceLabel";
            this.camDistanceLabel.Size = new System.Drawing.Size(77, 33);
            this.camDistanceLabel.TabIndex = 38;
            this.camDistanceLabel.Text = "Distance";
            this.camDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cameraLabel
            // 
            this.cameraLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cameraLabel.Location = new System.Drawing.Point(1068, 310);
            this.cameraLabel.Name = "cameraLabel";
            this.cameraLabel.Size = new System.Drawing.Size(204, 33);
            this.cameraLabel.TabIndex = 37;
            this.cameraLabel.Text = "Camera";
            this.cameraLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformOrientLabel
            // 
            this.transformOrientLabel.BackColor = System.Drawing.Color.Transparent;
            this.transformOrientLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformOrientLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.transformOrientLabel.Location = new System.Drawing.Point(817, 407);
            this.transformOrientLabel.Name = "transformOrientLabel";
            this.transformOrientLabel.Size = new System.Drawing.Size(126, 23);
            this.transformOrientLabel.TabIndex = 36;
            this.transformOrientLabel.Text = "Orientation";
            this.transformOrientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformVInput
            // 
            this.transformVInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.transformVInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transformVInput.ForeColor = System.Drawing.Color.White;
            this.transformVInput.Location = new System.Drawing.Point(900, 459);
            this.transformVInput.Name = "transformVInput";
            this.transformVInput.Size = new System.Drawing.Size(43, 18);
            this.transformVInput.TabIndex = 35;
            // 
            // transformVLabel
            // 
            this.transformVLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformVLabel.Location = new System.Drawing.Point(817, 450);
            this.transformVLabel.Name = "transformVLabel";
            this.transformVLabel.Size = new System.Drawing.Size(77, 33);
            this.transformVLabel.TabIndex = 34;
            this.transformVLabel.Text = "Vertical";
            this.transformVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformHInput
            // 
            this.transformHInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.transformHInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transformHInput.ForeColor = System.Drawing.Color.White;
            this.transformHInput.Location = new System.Drawing.Point(900, 433);
            this.transformHInput.Name = "transformHInput";
            this.transformHInput.Size = new System.Drawing.Size(43, 18);
            this.transformHInput.TabIndex = 33;
            // 
            // transformHLabel
            // 
            this.transformHLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformHLabel.Location = new System.Drawing.Point(817, 424);
            this.transformHLabel.Name = "transformHLabel";
            this.transformHLabel.Size = new System.Drawing.Size(77, 33);
            this.transformHLabel.TabIndex = 32;
            this.transformHLabel.Text = "Horizontal";
            this.transformHLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformCenterLabel
            // 
            this.transformCenterLabel.BackColor = System.Drawing.Color.Transparent;
            this.transformCenterLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformCenterLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.transformCenterLabel.Location = new System.Drawing.Point(817, 295);
            this.transformCenterLabel.Name = "transformCenterLabel";
            this.transformCenterLabel.Size = new System.Drawing.Size(81, 23);
            this.transformCenterLabel.TabIndex = 31;
            this.transformCenterLabel.Text = "Center";
            this.transformCenterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformZInput
            // 
            this.transformZInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.transformZInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transformZInput.ForeColor = System.Drawing.Color.White;
            this.transformZInput.Location = new System.Drawing.Point(842, 374);
            this.transformZInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.transformZInput.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.transformZInput.Name = "transformZInput";
            this.transformZInput.Size = new System.Drawing.Size(43, 18);
            this.transformZInput.TabIndex = 30;
            // 
            // transformZLabel
            // 
            this.transformZLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformZLabel.Location = new System.Drawing.Point(817, 365);
            this.transformZLabel.Name = "transformZLabel";
            this.transformZLabel.Size = new System.Drawing.Size(26, 33);
            this.transformZLabel.TabIndex = 29;
            this.transformZLabel.Text = "Z";
            this.transformZLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformYInput
            // 
            this.transformYInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.transformYInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transformYInput.ForeColor = System.Drawing.Color.White;
            this.transformYInput.Location = new System.Drawing.Point(842, 347);
            this.transformYInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.transformYInput.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.transformYInput.Name = "transformYInput";
            this.transformYInput.Size = new System.Drawing.Size(43, 18);
            this.transformYInput.TabIndex = 28;
            // 
            // transformYLabel
            // 
            this.transformYLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformYLabel.Location = new System.Drawing.Point(817, 338);
            this.transformYLabel.Name = "transformYLabel";
            this.transformYLabel.Size = new System.Drawing.Size(26, 33);
            this.transformYLabel.TabIndex = 27;
            this.transformYLabel.Text = "Y";
            this.transformYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformXInput
            // 
            this.transformXInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.transformXInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transformXInput.ForeColor = System.Drawing.Color.White;
            this.transformXInput.Location = new System.Drawing.Point(842, 321);
            this.transformXInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.transformXInput.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.transformXInput.Name = "transformXInput";
            this.transformXInput.Size = new System.Drawing.Size(43, 18);
            this.transformXInput.TabIndex = 26;
            // 
            // transformXLabel
            // 
            this.transformXLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformXLabel.Location = new System.Drawing.Point(817, 312);
            this.transformXLabel.Name = "transformXLabel";
            this.transformXLabel.Size = new System.Drawing.Size(26, 33);
            this.transformXLabel.TabIndex = 25;
            this.transformXLabel.Text = "X";
            this.transformXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // transformationLabel
            // 
            this.transformationLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.transformationLabel.Location = new System.Drawing.Point(817, 262);
            this.transformationLabel.Name = "transformationLabel";
            this.transformationLabel.Size = new System.Drawing.Size(204, 33);
            this.transformationLabel.TabIndex = 24;
            this.transformationLabel.Text = "Transformation";
            this.transformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageResVInput
            // 
            this.imageResVInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.imageResVInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageResVInput.ForeColor = System.Drawing.Color.White;
            this.imageResVInput.Location = new System.Drawing.Point(900, 217);
            this.imageResVInput.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.imageResVInput.Name = "imageResVInput";
            this.imageResVInput.Size = new System.Drawing.Size(43, 18);
            this.imageResVInput.TabIndex = 23;
            // 
            // imageResVLabel
            // 
            this.imageResVLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imageResVLabel.Location = new System.Drawing.Point(817, 208);
            this.imageResVLabel.Name = "imageResVLabel";
            this.imageResVLabel.Size = new System.Drawing.Size(77, 33);
            this.imageResVLabel.TabIndex = 22;
            this.imageResVLabel.Text = "Vertical";
            this.imageResVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageResHInput
            // 
            this.imageResHInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.imageResHInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageResHInput.ForeColor = System.Drawing.Color.White;
            this.imageResHInput.Location = new System.Drawing.Point(900, 191);
            this.imageResHInput.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.imageResHInput.Name = "imageResHInput";
            this.imageResHInput.Size = new System.Drawing.Size(43, 18);
            this.imageResHInput.TabIndex = 21;
            // 
            // imageResHLabel
            // 
            this.imageResHLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imageResHLabel.Location = new System.Drawing.Point(817, 182);
            this.imageResHLabel.Name = "imageResHLabel";
            this.imageResHLabel.Size = new System.Drawing.Size(77, 33);
            this.imageResHLabel.TabIndex = 20;
            this.imageResHLabel.Text = "Horizontal";
            this.imageResHLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageResLabel
            // 
            this.imageResLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.imageResLabel.Location = new System.Drawing.Point(817, 148);
            this.imageResLabel.Name = "imageResLabel";
            this.imageResLabel.Size = new System.Drawing.Size(204, 33);
            this.imageResLabel.TabIndex = 19;
            this.imageResLabel.Text = "Image Resolution";
            this.imageResLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // refractionCheckbox
            // 
            this.refractionCheckbox.AutoSize = true;
            this.refractionCheckbox.Location = new System.Drawing.Point(530, 269);
            this.refractionCheckbox.Name = "refractionCheckbox";
            this.refractionCheckbox.Size = new System.Drawing.Size(90, 20);
            this.refractionCheckbox.TabIndex = 18;
            this.refractionCheckbox.Text = "Refraction";
            this.refractionCheckbox.UseVisualStyleBackColor = true;
            // 
            // specularCheckbox
            // 
            this.specularCheckbox.AutoSize = true;
            this.specularCheckbox.Location = new System.Drawing.Point(530, 243);
            this.specularCheckbox.Name = "specularCheckbox";
            this.specularCheckbox.Size = new System.Drawing.Size(78, 20);
            this.specularCheckbox.TabIndex = 17;
            this.specularCheckbox.Text = "Specular";
            this.specularCheckbox.UseVisualStyleBackColor = true;
            // 
            // diffuseCheckbox
            // 
            this.diffuseCheckbox.AutoSize = true;
            this.diffuseCheckbox.Location = new System.Drawing.Point(530, 217);
            this.diffuseCheckbox.Name = "diffuseCheckbox";
            this.diffuseCheckbox.Size = new System.Drawing.Size(68, 20);
            this.diffuseCheckbox.TabIndex = 16;
            this.diffuseCheckbox.Text = "Diffuse";
            this.diffuseCheckbox.UseVisualStyleBackColor = true;
            // 
            // ambientCheckbox
            // 
            this.ambientCheckbox.AutoSize = true;
            this.ambientCheckbox.Location = new System.Drawing.Point(530, 191);
            this.ambientCheckbox.Name = "ambientCheckbox";
            this.ambientCheckbox.Size = new System.Drawing.Size(79, 20);
            this.ambientCheckbox.TabIndex = 15;
            this.ambientCheckbox.Text = "Ambient";
            this.ambientCheckbox.UseVisualStyleBackColor = true;
            // 
            // lightingLabel
            // 
            this.lightingLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lightingLabel.Location = new System.Drawing.Point(530, 146);
            this.lightingLabel.Name = "lightingLabel";
            this.lightingLabel.Size = new System.Drawing.Size(204, 33);
            this.lightingLabel.TabIndex = 14;
            this.lightingLabel.Text = "Lighting";
            this.lightingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.elapsedTimeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.elapsedTimeLabel.Location = new System.Drawing.Point(528, 524);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(172, 33);
            this.elapsedTimeLabel.TabIndex = 13;
            this.elapsedTimeLabel.Text = "Elapsed time: 00:00:00";
            this.elapsedTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // startRenderBtn
            // 
            this.startRenderBtn.BackColor = System.Drawing.Color.Transparent;
            this.startRenderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startRenderBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.startRenderBtn.FlatAppearance.BorderSize = 2;
            this.startRenderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startRenderBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.startRenderBtn.Location = new System.Drawing.Point(530, 478);
            this.startRenderBtn.Name = "startRenderBtn";
            this.startRenderBtn.Size = new System.Drawing.Size(123, 43);
            this.startRenderBtn.TabIndex = 12;
            this.startRenderBtn.Text = "START";
            this.startRenderBtn.UseVisualStyleBackColor = false;
            // 
            // recursionDepthInput
            // 
            this.recursionDepthInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.recursionDepthInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recursionDepthInput.ForeColor = System.Drawing.Color.White;
            this.recursionDepthInput.Location = new System.Drawing.Point(659, 349);
            this.recursionDepthInput.Name = "recursionDepthInput";
            this.recursionDepthInput.Size = new System.Drawing.Size(43, 18);
            this.recursionDepthInput.TabIndex = 11;
            // 
            // recursionDepthLabel
            // 
            this.recursionDepthLabel.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recursionDepthLabel.Location = new System.Drawing.Point(530, 343);
            this.recursionDepthLabel.Name = "recursionDepthLabel";
            this.recursionDepthLabel.Size = new System.Drawing.Size(123, 33);
            this.recursionDepthLabel.TabIndex = 10;
            this.recursionDepthLabel.Text = "Recursion Depth";
            this.recursionDepthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageUploaded
            // 
            this.imageUploaded.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.imageUploaded.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageUploaded.Location = new System.Drawing.Point(48, 107);
            this.imageUploaded.Name = "imageUploaded";
            this.imageUploaded.Size = new System.Drawing.Size(440, 440);
            this.imageUploaded.TabIndex = 9;
            this.imageUploaded.TabStop = false;
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitBtn.Location = new System.Drawing.Point(1056, 598);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(159, 44);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "EXIT";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // saveImgBtn
            // 
            this.saveImgBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.saveImgBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveImgBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.saveImgBtn.FlatAppearance.BorderSize = 0;
            this.saveImgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveImgBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveImgBtn.Location = new System.Drawing.Point(882, 598);
            this.saveImgBtn.Name = "saveImgBtn";
            this.saveImgBtn.Size = new System.Drawing.Size(159, 44);
            this.saveImgBtn.TabIndex = 6;
            this.saveImgBtn.Text = "SAVE IMAGE";
            this.saveImgBtn.UseVisualStyleBackColor = false;
            this.saveImgBtn.Click += new System.EventHandler(this.saveImgBtn_Click);
            // 
            // loadSceneBtn
            // 
            this.loadSceneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.loadSceneBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadSceneBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.loadSceneBtn.FlatAppearance.BorderSize = 0;
            this.loadSceneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadSceneBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.loadSceneBtn.Location = new System.Drawing.Point(51, 598);
            this.loadSceneBtn.Name = "loadSceneBtn";
            this.loadSceneBtn.Size = new System.Drawing.Size(159, 44);
            this.loadSceneBtn.TabIndex = 5;
            this.loadSceneBtn.Text = "LOAD SCENE";
            this.loadSceneBtn.UseVisualStyleBackColor = false;
            this.loadSceneBtn.Click += new System.EventHandler(this.loadImgBtn_Click);
            // 
            // rendererLabel
            // 
            this.rendererLabel.Font = new System.Drawing.Font("Montserrat SemiBold", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rendererLabel.Location = new System.Drawing.Point(530, 310);
            this.rendererLabel.Name = "rendererLabel";
            this.rendererLabel.Size = new System.Drawing.Size(204, 33);
            this.rendererLabel.TabIndex = 4;
            this.rendererLabel.Text = "Renderer";
            this.rendererLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // globalLabel
            // 
            this.globalLabel.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.globalLabel.Location = new System.Drawing.Point(41, 15);
            this.globalLabel.Name = "globalLabel";
            this.globalLabel.Size = new System.Drawing.Size(295, 79);
            this.globalLabel.TabIndex = 3;
            this.globalLabel.Text = "Global";
            this.globalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveSceneBtn
            // 
            this.saveSceneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.saveSceneBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveSceneBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.saveSceneBtn.FlatAppearance.BorderSize = 0;
            this.saveSceneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveSceneBtn.Font = new System.Drawing.Font("Montserrat SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveSceneBtn.Location = new System.Drawing.Point(225, 598);
            this.saveSceneBtn.Name = "saveSceneBtn";
            this.saveSceneBtn.Size = new System.Drawing.Size(159, 44);
            this.saveSceneBtn.TabIndex = 54;
            this.saveSceneBtn.Text = "SAVE SCENE";
            this.saveSceneBtn.UseVisualStyleBackColor = false;
            this.saveSceneBtn.Visible = false;
            // 
            // RayTracer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "RayTracer";
            this.Text = "RayTracer";
            this.tabControl1.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.application.ResumeLayout(false);
            this.application.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorBInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorGInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgColorRInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camFieldInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camDistanceInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformVInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformHInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformZInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformYInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformXInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageResVInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageResHInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageUploaded)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mainMenu;
        private System.Windows.Forms.Label credits;
        private System.Windows.Forms.Label projectTitle;
        private System.Windows.Forms.TabPage application;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button loadSceneBtn;
        private System.Windows.Forms.Label rendererLabel;
        private System.Windows.Forms.Label globalLabel;
        private System.Windows.Forms.Label dividerBottom;
        private System.Windows.Forms.Label dividerTop;
        private System.Windows.Forms.NumericUpDown camFieldInput;
        private System.Windows.Forms.Label camFieldLabel;
        private System.Windows.Forms.NumericUpDown camDistanceInput;
        private System.Windows.Forms.Label camDistanceLabel;
        private System.Windows.Forms.Label cameraLabel;
        private System.Windows.Forms.Label transformOrientLabel;
        private System.Windows.Forms.NumericUpDown transformVInput;
        private System.Windows.Forms.Label transformVLabel;
        private System.Windows.Forms.NumericUpDown transformHInput;
        private System.Windows.Forms.Label transformHLabel;
        private System.Windows.Forms.Label transformCenterLabel;
        private System.Windows.Forms.NumericUpDown transformZInput;
        private System.Windows.Forms.Label transformZLabel;
        private System.Windows.Forms.NumericUpDown transformYInput;
        private System.Windows.Forms.Label transformYLabel;
        private System.Windows.Forms.NumericUpDown transformXInput;
        private System.Windows.Forms.Label transformXLabel;
        private System.Windows.Forms.Label transformationLabel;
        private System.Windows.Forms.NumericUpDown imageResVInput;
        private System.Windows.Forms.Label imageResVLabel;
        private System.Windows.Forms.NumericUpDown imageResHInput;
        private System.Windows.Forms.Label imageResHLabel;
        private System.Windows.Forms.Label imageResLabel;
        private System.Windows.Forms.CheckBox refractionCheckbox;
        private System.Windows.Forms.CheckBox specularCheckbox;
        private System.Windows.Forms.CheckBox diffuseCheckbox;
        private System.Windows.Forms.CheckBox ambientCheckbox;
        private System.Windows.Forms.Label lightingLabel;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Button startRenderBtn;
        private System.Windows.Forms.NumericUpDown recursionDepthInput;
        private System.Windows.Forms.Label recursionDepthLabel;
        private System.Windows.Forms.PictureBox imageUploaded;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button saveImgBtn;
        private System.Windows.Forms.Label backgroundColorLabel;
        private System.Windows.Forms.NumericUpDown bgColorBInput;
        private System.Windows.Forms.Label bgColorBLabel;
        private System.Windows.Forms.NumericUpDown bgColorGInput;
        private System.Windows.Forms.Label bgColorGLabel;
        private System.Windows.Forms.NumericUpDown bgColorRInput;
        private System.Windows.Forms.Label bgColorRLabel;
        private System.Windows.Forms.Label colorComponentsLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressBarLabel;
        private System.Windows.Forms.Button saveSceneBtn;
    }
}

