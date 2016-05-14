namespace GreyScottSimulator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.gbLaplacian = new System.Windows.Forms.GroupBox();
            this.rbDeltaMeans = new System.Windows.Forms.RadioButton();
            this.rbConvolution = new System.Windows.Forms.RadioButton();
            this.rbPerpendicular = new System.Windows.Forms.RadioButton();
            this.gbColour = new System.Windows.Forms.GroupBox();
            this.rbYellowToRed = new System.Windows.Forms.RadioButton();
            this.rbLongRainbow = new System.Windows.Forms.RadioButton();
            this.rbGrayScale = new System.Windows.Forms.RadioButton();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.tbKillB = new System.Windows.Forms.TextBox();
            this.tbFeedA = new System.Windows.Forms.TextBox();
            this.lblKillB = new System.Windows.Forms.Label();
            this.lblFeedA = new System.Windows.Forms.Label();
            this.btn5000Steps = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.gbLaplacian.SuspendLayout();
            this.gbColour.SuspendLayout();
            this.gbValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(554, 426);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(170, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbLaplacian
            // 
            this.gbLaplacian.Controls.Add(this.rbDeltaMeans);
            this.gbLaplacian.Controls.Add(this.rbConvolution);
            this.gbLaplacian.Controls.Add(this.rbPerpendicular);
            this.gbLaplacian.Location = new System.Drawing.Point(554, 130);
            this.gbLaplacian.Name = "gbLaplacian";
            this.gbLaplacian.Size = new System.Drawing.Size(170, 142);
            this.gbLaplacian.TabIndex = 1;
            this.gbLaplacian.TabStop = false;
            this.gbLaplacian.Text = "Laplacian Functions";
            // 
            // rbDeltaMeans
            // 
            this.rbDeltaMeans.AutoSize = true;
            this.rbDeltaMeans.Location = new System.Drawing.Point(15, 105);
            this.rbDeltaMeans.Name = "rbDeltaMeans";
            this.rbDeltaMeans.Size = new System.Drawing.Size(85, 17);
            this.rbDeltaMeans.TabIndex = 2;
            this.rbDeltaMeans.TabStop = true;
            this.rbDeltaMeans.Text = "Delta Means";
            this.rbDeltaMeans.UseVisualStyleBackColor = true;
            // 
            // rbConvolution
            // 
            this.rbConvolution.AutoSize = true;
            this.rbConvolution.Location = new System.Drawing.Point(15, 67);
            this.rbConvolution.Name = "rbConvolution";
            this.rbConvolution.Size = new System.Drawing.Size(81, 17);
            this.rbConvolution.TabIndex = 1;
            this.rbConvolution.TabStop = true;
            this.rbConvolution.Text = "Convolution";
            this.rbConvolution.UseVisualStyleBackColor = true;
            // 
            // rbPerpendicular
            // 
            this.rbPerpendicular.AutoSize = true;
            this.rbPerpendicular.Location = new System.Drawing.Point(15, 29);
            this.rbPerpendicular.Name = "rbPerpendicular";
            this.rbPerpendicular.Size = new System.Drawing.Size(147, 17);
            this.rbPerpendicular.TabIndex = 0;
            this.rbPerpendicular.TabStop = true;
            this.rbPerpendicular.Text = "Perpendicular Neighbours";
            this.rbPerpendicular.UseVisualStyleBackColor = true;
            // 
            // gbColour
            // 
            this.gbColour.Controls.Add(this.rbYellowToRed);
            this.gbColour.Controls.Add(this.rbLongRainbow);
            this.gbColour.Controls.Add(this.rbGrayScale);
            this.gbColour.Location = new System.Drawing.Point(554, 278);
            this.gbColour.Name = "gbColour";
            this.gbColour.Size = new System.Drawing.Size(170, 142);
            this.gbColour.TabIndex = 2;
            this.gbColour.TabStop = false;
            this.gbColour.Text = "Colour";
            // 
            // rbYellowToRed
            // 
            this.rbYellowToRed.AutoSize = true;
            this.rbYellowToRed.Location = new System.Drawing.Point(15, 105);
            this.rbYellowToRed.Name = "rbYellowToRed";
            this.rbYellowToRed.Size = new System.Drawing.Size(91, 17);
            this.rbYellowToRed.TabIndex = 2;
            this.rbYellowToRed.TabStop = true;
            this.rbYellowToRed.Text = "Yellow to Red";
            this.rbYellowToRed.UseVisualStyleBackColor = true;
            // 
            // rbLongRainbow
            // 
            this.rbLongRainbow.AutoSize = true;
            this.rbLongRainbow.Location = new System.Drawing.Point(15, 67);
            this.rbLongRainbow.Name = "rbLongRainbow";
            this.rbLongRainbow.Size = new System.Drawing.Size(94, 17);
            this.rbLongRainbow.TabIndex = 1;
            this.rbLongRainbow.TabStop = true;
            this.rbLongRainbow.Text = "Long Rainbow";
            this.rbLongRainbow.UseVisualStyleBackColor = true;
            // 
            // rbGrayScale
            // 
            this.rbGrayScale.AutoSize = true;
            this.rbGrayScale.Location = new System.Drawing.Point(15, 29);
            this.rbGrayScale.Name = "rbGrayScale";
            this.rbGrayScale.Size = new System.Drawing.Size(77, 17);
            this.rbGrayScale.TabIndex = 0;
            this.rbGrayScale.TabStop = true;
            this.rbGrayScale.Text = "Gray Scale";
            this.rbGrayScale.UseVisualStyleBackColor = true;
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.tbKillB);
            this.gbValues.Controls.Add(this.tbFeedA);
            this.gbValues.Controls.Add(this.lblKillB);
            this.gbValues.Controls.Add(this.lblFeedA);
            this.gbValues.Location = new System.Drawing.Point(554, 12);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(170, 112);
            this.gbValues.TabIndex = 3;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Values";
            // 
            // tbKillB
            // 
            this.tbKillB.Location = new System.Drawing.Point(63, 73);
            this.tbKillB.Name = "tbKillB";
            this.tbKillB.Size = new System.Drawing.Size(98, 20);
            this.tbKillB.TabIndex = 10;
            // 
            // tbFeedA
            // 
            this.tbFeedA.Location = new System.Drawing.Point(63, 31);
            this.tbFeedA.Name = "tbFeedA";
            this.tbFeedA.Size = new System.Drawing.Size(98, 20);
            this.tbFeedA.TabIndex = 9;
            // 
            // lblKillB
            // 
            this.lblKillB.AutoSize = true;
            this.lblKillB.Location = new System.Drawing.Point(12, 76);
            this.lblKillB.Name = "lblKillB";
            this.lblKillB.Size = new System.Drawing.Size(30, 13);
            this.lblKillB.TabIndex = 8;
            this.lblKillB.Text = "Kill B";
            // 
            // lblFeedA
            // 
            this.lblFeedA.AutoSize = true;
            this.lblFeedA.Location = new System.Drawing.Point(12, 34);
            this.lblFeedA.Name = "lblFeedA";
            this.lblFeedA.Size = new System.Drawing.Size(41, 13);
            this.lblFeedA.TabIndex = 7;
            this.lblFeedA.Text = "Feed A";
            // 
            // btn5000Steps
            // 
            this.btn5000Steps.AllowDrop = true;
            this.btn5000Steps.Location = new System.Drawing.Point(554, 456);
            this.btn5000Steps.Name = "btn5000Steps";
            this.btn5000Steps.Size = new System.Drawing.Size(170, 23);
            this.btn5000Steps.TabIndex = 5;
            this.btn5000Steps.Text = "5000 Steps";
            this.btn5000Steps.UseVisualStyleBackColor = true;
            this.btn5000Steps.Click += new System.EventHandler(this.btn5000Steps_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.AllowDrop = true;
            this.btnAuto.Location = new System.Drawing.Point(554, 485);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(170, 23);
            this.btnAuto.TabIndex = 6;
            this.btnAuto.Text = "Run Automated";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 541);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btn5000Steps);
            this.Controls.Add(this.gbValues);
            this.Controls.Add(this.gbColour);
            this.Controls.Add(this.gbLaplacian);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Grey Scott Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLaplacian.ResumeLayout(false);
            this.gbLaplacian.PerformLayout();
            this.gbColour.ResumeLayout(false);
            this.gbColour.PerformLayout();
            this.gbValues.ResumeLayout(false);
            this.gbValues.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbLaplacian;
        private System.Windows.Forms.RadioButton rbDeltaMeans;
        private System.Windows.Forms.RadioButton rbConvolution;
        private System.Windows.Forms.RadioButton rbPerpendicular;
        private System.Windows.Forms.GroupBox gbColour;
        private System.Windows.Forms.RadioButton rbYellowToRed;
        private System.Windows.Forms.RadioButton rbLongRainbow;
        private System.Windows.Forms.RadioButton rbGrayScale;
        private System.Windows.Forms.GroupBox gbValues;
        private System.Windows.Forms.TextBox tbKillB;
        private System.Windows.Forms.TextBox tbFeedA;
        private System.Windows.Forms.Label lblKillB;
        private System.Windows.Forms.Label lblFeedA;
        private System.Windows.Forms.Button btn5000Steps;
        private System.Windows.Forms.Button btnAuto;
    }
}

