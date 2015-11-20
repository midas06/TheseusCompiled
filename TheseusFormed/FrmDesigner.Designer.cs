namespace TheseusFormed
{
    partial class FrmDesigner
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
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.btnNW = new System.Windows.Forms.Button();
            this.btnSW = new System.Windows.Forms.Button();
            this.btnEW = new System.Windows.Forms.Button();
            this.btnWW = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTheseus = new System.Windows.Forms.Button();
            this.btnMinotaur = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbxMapName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.Location = new System.Drawing.Point(13, 13);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(447, 394);
            this.pnlBackground.TabIndex = 5;
            this.pnlBackground.Click += new System.EventHandler(this.pnlBackground_Click);
            this.pnlBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBackground_Paint);
            // 
            // btnNW
            // 
            this.btnNW.Location = new System.Drawing.Point(88, 413);
            this.btnNW.Name = "btnNW";
            this.btnNW.Size = new System.Drawing.Size(75, 23);
            this.btnNW.TabIndex = 6;
            this.btnNW.Text = "North Wall";
            this.btnNW.UseVisualStyleBackColor = true;
            this.btnNW.Click += new System.EventHandler(this.btnNW_Click);
            // 
            // btnSW
            // 
            this.btnSW.Location = new System.Drawing.Point(88, 476);
            this.btnSW.Name = "btnSW";
            this.btnSW.Size = new System.Drawing.Size(75, 23);
            this.btnSW.TabIndex = 7;
            this.btnSW.Text = "South Wall";
            this.btnSW.UseVisualStyleBackColor = true;
            this.btnSW.Click += new System.EventHandler(this.btnSW_Click);
            // 
            // btnEW
            // 
            this.btnEW.Location = new System.Drawing.Point(160, 442);
            this.btnEW.Name = "btnEW";
            this.btnEW.Size = new System.Drawing.Size(75, 23);
            this.btnEW.TabIndex = 8;
            this.btnEW.Text = "East Wall";
            this.btnEW.UseVisualStyleBackColor = true;
            this.btnEW.Click += new System.EventHandler(this.btnEW_Click);
            // 
            // btnWW
            // 
            this.btnWW.Location = new System.Drawing.Point(13, 442);
            this.btnWW.Name = "btnWW";
            this.btnWW.Size = new System.Drawing.Size(75, 23);
            this.btnWW.TabIndex = 9;
            this.btnWW.Text = "West Wall";
            this.btnWW.UseVisualStyleBackColor = true;
            this.btnWW.Click += new System.EventHandler(this.btnWW_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(31, 530);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTheseus
            // 
            this.btnTheseus.Location = new System.Drawing.Point(135, 530);
            this.btnTheseus.Name = "btnTheseus";
            this.btnTheseus.Size = new System.Drawing.Size(75, 23);
            this.btnTheseus.TabIndex = 11;
            this.btnTheseus.Text = "Theseus";
            this.btnTheseus.UseVisualStyleBackColor = true;
            this.btnTheseus.Click += new System.EventHandler(this.btnTheseus_Click);
            // 
            // btnMinotaur
            // 
            this.btnMinotaur.Location = new System.Drawing.Point(243, 530);
            this.btnMinotaur.Name = "btnMinotaur";
            this.btnMinotaur.Size = new System.Drawing.Size(75, 23);
            this.btnMinotaur.TabIndex = 12;
            this.btnMinotaur.Text = "Minotaur";
            this.btnMinotaur.UseVisualStyleBackColor = true;
            this.btnMinotaur.Click += new System.EventHandler(this.btnMinotaur_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(385, 488);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 65);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxMapName
            // 
            this.tbxMapName.Location = new System.Drawing.Point(324, 444);
            this.tbxMapName.Name = "tbxMapName";
            this.tbxMapName.Size = new System.Drawing.Size(162, 20);
            this.tbxMapName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Map Name:";
            // 
            // FrmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 584);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxMapName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnMinotaur);
            this.Controls.Add(this.btnTheseus);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWW);
            this.Controls.Add(this.btnEW);
            this.Controls.Add(this.btnSW);
            this.Controls.Add(this.btnNW);
            this.Controls.Add(this.pnlBackground);
            this.Name = "FrmDesigner";
            this.Text = "FrmDesigner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Button btnNW;
        private System.Windows.Forms.Button btnSW;
        private System.Windows.Forms.Button btnEW;
        private System.Windows.Forms.Button btnWW;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnTheseus;
        private System.Windows.Forms.Button btnMinotaur;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbxMapName;
        private System.Windows.Forms.Label label1;
    }
}