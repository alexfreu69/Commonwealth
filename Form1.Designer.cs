namespace Commonwealth
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
            this.lblDistance = new System.Windows.Forms.Label();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnBorder = new System.Windows.Forms.Button();
            this.btnTSP = new System.Windows.Forms.Button();
            this.btnMST = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDistance
            // 
            this.lblDistance.Location = new System.Drawing.Point(511, 15);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(70, 12);
            this.lblDistance.TabIndex = 0;
            this.lblDistance.Text = "...";
            this.lblDistance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(658, 14);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnBorder
            // 
            this.btnBorder.Location = new System.Drawing.Point(658, 43);
            this.btnBorder.Name = "btnBorder";
            this.btnBorder.Size = new System.Drawing.Size(75, 23);
            this.btnBorder.TabIndex = 2;
            this.btnBorder.Text = "Border";
            this.btnBorder.UseVisualStyleBackColor = true;
            this.btnBorder.Click += new System.EventHandler(this.btnBorder_Click);
            // 
            // btnTSP
            // 
            this.btnTSP.Location = new System.Drawing.Point(658, 72);
            this.btnTSP.Name = "btnTSP";
            this.btnTSP.Size = new System.Drawing.Size(75, 23);
            this.btnTSP.TabIndex = 3;
            this.btnTSP.Text = "TSP";
            this.btnTSP.UseVisualStyleBackColor = true;
            // 
            // btnMST
            // 
            this.btnMST.Location = new System.Drawing.Point(658, 101);
            this.btnMST.Name = "btnMST";
            this.btnMST.Size = new System.Drawing.Size(75, 23);
            this.btnMST.TabIndex = 4;
            this.btnMST.Text = "MST";
            this.btnMST.UseVisualStyleBackColor = true;
            this.btnMST.Click += new System.EventHandler(this.btnMST_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 532);
            this.Controls.Add(this.btnMST);
            this.Controls.Add(this.btnTSP);
            this.Controls.Add(this.btnBorder);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.lblDistance);
            this.Name = "Form1";
            this.Text = "Commonwealth";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnBorder;
        private System.Windows.Forms.Button btnTSP;
        private System.Windows.Forms.Button btnMST;
    }
}

