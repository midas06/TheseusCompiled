namespace TheseusFormed
{
    partial class FrmSplash
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
            this.btnLoadBuilder = new System.Windows.Forms.Button();
            this.btnLoadFiler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLoadBuilder
            // 
            this.btnLoadBuilder.Location = new System.Drawing.Point(172, 117);
            this.btnLoadBuilder.Name = "btnLoadBuilder";
            this.btnLoadBuilder.Size = new System.Drawing.Size(143, 23);
            this.btnLoadBuilder.TabIndex = 0;
            this.btnLoadBuilder.Text = "Design your own Level";
            this.btnLoadBuilder.UseVisualStyleBackColor = true;
            this.btnLoadBuilder.Click += new System.EventHandler(this.btnLoadBuilder_Click);
            // 
            // btnLoadFiler
            // 
            this.btnLoadFiler.Location = new System.Drawing.Point(172, 210);
            this.btnLoadFiler.Name = "btnLoadFiler";
            this.btnLoadFiler.Size = new System.Drawing.Size(143, 23);
            this.btnLoadFiler.TabIndex = 1;
            this.btnLoadFiler.Text = "Open an Existing Level";
            this.btnLoadFiler.UseVisualStyleBackColor = true;
            this.btnLoadFiler.Click += new System.EventHandler(this.btnLoadFiler_Click);
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.ControlBox = false;
            this.Controls.Add(this.btnLoadFiler);
            this.Controls.Add(this.btnLoadBuilder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSplash";
            this.Text = "Theseus and the Minotaur";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadBuilder;
        private System.Windows.Forms.Button btnLoadFiler;
    }
}

