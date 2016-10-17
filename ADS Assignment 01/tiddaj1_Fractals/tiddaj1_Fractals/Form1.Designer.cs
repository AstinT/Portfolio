namespace tiddaj1_Fractals
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
            this.lblDepth = new System.Windows.Forms.Label();
            this.tbDepth = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.gbFractalDesigns = new System.Windows.Forms.GroupBox();
            this.rbGrain = new System.Windows.Forms.RadioButton();
            this.rbKochSnowflake = new System.Windows.Forms.RadioButton();
            this.rbTree = new System.Windows.Forms.RadioButton();
            this.rbCircles = new System.Windows.Forms.RadioButton();
            this.rbSierTri = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.gbFractalDesigns.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepth.Location = new System.Drawing.Point(30, 36);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(87, 31);
            this.lblDepth.TabIndex = 0;
            this.lblDepth.Text = "Depth";
            // 
            // tbDepth
            // 
            this.tbDepth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDepth.Location = new System.Drawing.Point(123, 33);
            this.tbDepth.Name = "tbDepth";
            this.tbDepth.Size = new System.Drawing.Size(111, 38);
            this.tbDepth.TabIndex = 1;
            this.tbDepth.Text = "0";
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Gray;
            this.panel.Location = new System.Drawing.Point(300, 33);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1250, 800);
            this.panel.TabIndex = 8;
            // 
            // gbFractalDesigns
            // 
            this.gbFractalDesigns.Controls.Add(this.rbGrain);
            this.gbFractalDesigns.Controls.Add(this.rbKochSnowflake);
            this.gbFractalDesigns.Controls.Add(this.rbTree);
            this.gbFractalDesigns.Controls.Add(this.rbCircles);
            this.gbFractalDesigns.Controls.Add(this.rbSierTri);
            this.gbFractalDesigns.Location = new System.Drawing.Point(36, 111);
            this.gbFractalDesigns.Name = "gbFractalDesigns";
            this.gbFractalDesigns.Size = new System.Drawing.Size(198, 240);
            this.gbFractalDesigns.TabIndex = 9;
            this.gbFractalDesigns.TabStop = false;
            this.gbFractalDesigns.Text = "Fractal Designs";
            // 
            // rbGrain
            // 
            this.rbGrain.AutoSize = true;
            this.rbGrain.Location = new System.Drawing.Point(16, 200);
            this.rbGrain.Name = "rbGrain";
            this.rbGrain.Size = new System.Drawing.Size(50, 17);
            this.rbGrain.TabIndex = 4;
            this.rbGrain.TabStop = true;
            this.rbGrain.Text = "Grain";
            this.rbGrain.UseVisualStyleBackColor = true;
            // 
            // rbKochSnowflake
            // 
            this.rbKochSnowflake.AutoSize = true;
            this.rbKochSnowflake.Location = new System.Drawing.Point(16, 159);
            this.rbKochSnowflake.Name = "rbKochSnowflake";
            this.rbKochSnowflake.Size = new System.Drawing.Size(103, 17);
            this.rbKochSnowflake.TabIndex = 3;
            this.rbKochSnowflake.TabStop = true;
            this.rbKochSnowflake.Text = "Koch Snowflake";
            this.rbKochSnowflake.UseVisualStyleBackColor = true;
            // 
            // rbTree
            // 
            this.rbTree.AutoSize = true;
            this.rbTree.Location = new System.Drawing.Point(16, 118);
            this.rbTree.Name = "rbTree";
            this.rbTree.Size = new System.Drawing.Size(47, 17);
            this.rbTree.TabIndex = 2;
            this.rbTree.TabStop = true;
            this.rbTree.Text = "Tree";
            this.rbTree.UseVisualStyleBackColor = true;
            // 
            // rbCircles
            // 
            this.rbCircles.AutoSize = true;
            this.rbCircles.Location = new System.Drawing.Point(16, 77);
            this.rbCircles.Name = "rbCircles";
            this.rbCircles.Size = new System.Drawing.Size(161, 17);
            this.rbCircles.TabIndex = 1;
            this.rbCircles.TabStop = true;
            this.rbCircles.Text = "Sierpinskis Triangles (Circles)";
            this.rbCircles.UseVisualStyleBackColor = true;
            // 
            // rbSierTri
            // 
            this.rbSierTri.AutoSize = true;
            this.rbSierTri.Location = new System.Drawing.Point(16, 36);
            this.rbSierTri.Name = "rbSierTri";
            this.rbSierTri.Size = new System.Drawing.Size(116, 17);
            this.rbSierTri.TabIndex = 0;
            this.rbSierTri.TabStop = true;
            this.rbSierTri.Text = "Sierpinskis Triangle";
            this.rbSierTri.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(36, 419);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(198, 50);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.gbFractalDesigns);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tbDepth);
            this.Controls.Add(this.lblDepth);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fractals";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbFractalDesigns.ResumeLayout(false);
            this.gbFractalDesigns.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.TextBox tbDepth;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox gbFractalDesigns;
        private System.Windows.Forms.RadioButton rbCircles;
        private System.Windows.Forms.RadioButton rbSierTri;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RadioButton rbGrain;
        private System.Windows.Forms.RadioButton rbKochSnowflake;
        private System.Windows.Forms.RadioButton rbTree;
    }
}

