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
            this.lblMapName = new System.Windows.Forms.Label();
            this.tbxMapName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnMinotaur = new System.Windows.Forms.Button();
            this.btnTheseus = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnWW = new System.Windows.Forms.Button();
            this.btnEW = new System.Windows.Forms.Button();
            this.btnSW = new System.Windows.Forms.Button();
            this.btnNW = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(656, 671);
            this.pnlBackground.TabIndex = 5;
            this.pnlBackground.Click += new System.EventHandler(this.pnlBackground_Click);
            this.pnlBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBackground_Paint);
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(694, 306);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(62, 13);
            this.lblMapName.TabIndex = 25;
            this.lblMapName.Text = "Map Name:";
            // 
            // tbxMapName
            // 
            this.tbxMapName.Location = new System.Drawing.Point(697, 332);
            this.tbxMapName.Name = "tbxMapName";
            this.tbxMapName.Size = new System.Drawing.Size(162, 20);
            this.tbxMapName.TabIndex = 24;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(758, 376);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 65);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMinotaur
            // 
            this.btnMinotaur.Location = new System.Drawing.Point(749, 144);
            this.btnMinotaur.Name = "btnMinotaur";
            this.btnMinotaur.Size = new System.Drawing.Size(75, 23);
            this.btnMinotaur.TabIndex = 22;
            this.btnMinotaur.Text = "Minotaur";
            this.btnMinotaur.UseVisualStyleBackColor = true;
            this.btnMinotaur.Click += new System.EventHandler(this.btnMinotaur_Click);
            // 
            // btnTheseus
            // 
            this.btnTheseus.Location = new System.Drawing.Point(749, 198);
            this.btnTheseus.Name = "btnTheseus";
            this.btnTheseus.Size = new System.Drawing.Size(75, 23);
            this.btnTheseus.TabIndex = 21;
            this.btnTheseus.Text = "Theseus";
            this.btnTheseus.UseVisualStyleBackColor = true;
            this.btnTheseus.Click += new System.EventHandler(this.btnTheseus_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(749, 250);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnWW
            // 
            this.btnWW.Location = new System.Drawing.Point(681, 65);
            this.btnWW.Name = "btnWW";
            this.btnWW.Size = new System.Drawing.Size(75, 23);
            this.btnWW.TabIndex = 19;
            this.btnWW.Text = "West Wall";
            this.btnWW.UseVisualStyleBackColor = true;
            this.btnWW.Click += new System.EventHandler(this.btnWW_Click);
            // 
            // btnEW
            // 
            this.btnEW.Location = new System.Drawing.Point(819, 65);
            this.btnEW.Name = "btnEW";
            this.btnEW.Size = new System.Drawing.Size(75, 23);
            this.btnEW.TabIndex = 18;
            this.btnEW.Text = "East Wall";
            this.btnEW.UseVisualStyleBackColor = true;
            this.btnEW.Click += new System.EventHandler(this.btnEW_Click);
            // 
            // btnSW
            // 
            this.btnSW.Location = new System.Drawing.Point(749, 94);
            this.btnSW.Name = "btnSW";
            this.btnSW.Size = new System.Drawing.Size(75, 23);
            this.btnSW.TabIndex = 17;
            this.btnSW.Text = "South Wall";
            this.btnSW.UseVisualStyleBackColor = true;
            this.btnSW.Click += new System.EventHandler(this.btnSW_Click);
            // 
            // btnNW
            // 
            this.btnNW.Location = new System.Drawing.Point(749, 36);
            this.btnNW.Name = "btnNW";
            this.btnNW.Size = new System.Drawing.Size(75, 23);
            this.btnNW.TabIndex = 16;
            this.btnNW.Text = "North Wall";
            this.btnNW.UseVisualStyleBackColor = true;
            this.btnNW.Click += new System.EventHandler(this.btnNW_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(749, 595);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 26;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FrmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 719);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.btnNW);
            this.Controls.Add(this.tbxMapName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSW);
            this.Controls.Add(this.btnTheseus);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnWW);
            this.Controls.Add(this.btnEW);
            this.Controls.Add(this.btnMinotaur);
            this.Name = "FrmDesigner";
            this.Text = "FrmDesigner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.TextBox tbxMapName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMinotaur;
        private System.Windows.Forms.Button btnTheseus;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnWW;
        private System.Windows.Forms.Button btnEW;
        private System.Windows.Forms.Button btnSW;
        private System.Windows.Forms.Button btnNW;
        private System.Windows.Forms.Button btnClear;
    }
}