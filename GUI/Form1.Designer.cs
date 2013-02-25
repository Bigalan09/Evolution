namespace GUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMutRate = new System.Windows.Forms.Label();
            this.trackMutation = new System.Windows.Forms.TrackBar();
            this.lblRepRate = new System.Windows.Forms.Label();
            this.trackReproduction = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCrossover = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblGrowRate = new System.Windows.Forms.Label();
            this.trackGrowth = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackReproduction)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGrowth)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seed number:";
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(112, 13);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(139, 20);
            this.txtSeed.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 338);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(420, 38);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Simulation";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSeed);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 43);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation Properties";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(257, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Leave blank for a random seed.";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox2.Controls.Add(this.lblMutRate);
            this.groupBox2.Controls.Add(this.trackMutation);
            this.groupBox2.Controls.Add(this.lblRepRate);
            this.groupBox2.Controls.Add(this.trackReproduction);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbCrossover);
            this.groupBox2.Location = new System.Drawing.Point(12, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 176);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Creature Properties";
            // 
            // lblMutRate
            // 
            this.lblMutRate.AutoSize = true;
            this.lblMutRate.Location = new System.Drawing.Point(237, 99);
            this.lblMutRate.Name = "lblMutRate";
            this.lblMutRate.Size = new System.Drawing.Size(21, 13);
            this.lblMutRate.TabIndex = 16;
            this.lblMutRate.Text = "0%";
            // 
            // trackMutation
            // 
            this.trackMutation.Location = new System.Drawing.Point(112, 70);
            this.trackMutation.Maximum = 100;
            this.trackMutation.Name = "trackMutation";
            this.trackMutation.Size = new System.Drawing.Size(302, 45);
            this.trackMutation.TabIndex = 3;
            this.trackMutation.Scroll += new System.EventHandler(this.trackMutation_Scroll);
            // 
            // lblRepRate
            // 
            this.lblRepRate.AutoSize = true;
            this.lblRepRate.Location = new System.Drawing.Point(237, 48);
            this.lblRepRate.Name = "lblRepRate";
            this.lblRepRate.Size = new System.Drawing.Size(21, 13);
            this.lblRepRate.TabIndex = 14;
            this.lblRepRate.Text = "0%";
            // 
            // trackReproduction
            // 
            this.trackReproduction.Location = new System.Drawing.Point(112, 19);
            this.trackReproduction.Maximum = 100;
            this.trackReproduction.Name = "trackReproduction";
            this.trackReproduction.Size = new System.Drawing.Size(302, 45);
            this.trackReproduction.TabIndex = 2;
            this.trackReproduction.Scroll += new System.EventHandler(this.trackReproduction_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mutation Rate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Reproduction Rate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Crossover:";
            // 
            // cmbCrossover
            // 
            this.cmbCrossover.FormattingEnabled = true;
            this.cmbCrossover.Location = new System.Drawing.Point(112, 140);
            this.cmbCrossover.Name = "cmbCrossover";
            this.cmbCrossover.Size = new System.Drawing.Size(302, 21);
            this.cmbCrossover.TabIndex = 4;
            this.cmbCrossover.Text = "Select Crossover";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox3.Controls.Add(this.lblGrowRate);
            this.groupBox3.Controls.Add(this.trackGrowth);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 243);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 76);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resource Properties";
            // 
            // lblGrowRate
            // 
            this.lblGrowRate.AutoSize = true;
            this.lblGrowRate.Location = new System.Drawing.Point(237, 48);
            this.lblGrowRate.Name = "lblGrowRate";
            this.lblGrowRate.Size = new System.Drawing.Size(27, 13);
            this.lblGrowRate.TabIndex = 15;
            this.lblGrowRate.Text = "50%";
            // 
            // trackGrowth
            // 
            this.trackGrowth.Location = new System.Drawing.Point(112, 19);
            this.trackGrowth.Maximum = 100;
            this.trackGrowth.Name = "trackGrowth";
            this.trackGrowth.Size = new System.Drawing.Size(302, 45);
            this.trackGrowth.TabIndex = 5;
            this.trackGrowth.Scroll += new System.EventHandler(this.trackGrowth_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Growth Rate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(442, 385);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adaptation by Natural Selection";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackReproduction)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackGrowth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCrossover;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblGrowRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackReproduction;
        private System.Windows.Forms.Label lblRepRate;
        private System.Windows.Forms.TrackBar trackMutation;
        private System.Windows.Forms.Label lblMutRate;
        private System.Windows.Forms.TrackBar trackGrowth;
        private System.Windows.Forms.Label label6;
    }
}

