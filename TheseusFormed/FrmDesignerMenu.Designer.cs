namespace TheseusFormed
{
    partial class FrmDesignerMenu
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
            this.btnNewMap = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewMap
            // 
            this.btnNewMap.Location = new System.Drawing.Point(159, 106);
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(139, 23);
            this.btnNewMap.TabIndex = 0;
            this.btnNewMap.Text = "Create a New Map";
            this.btnNewMap.UseVisualStyleBackColor = true;
            this.btnNewMap.Click += new System.EventHandler(this.btnNewMap_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(159, 240);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit an Existing Map";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FrmDesignerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNewMap);
            this.Name = "FrmDesignerMenu";
            this.Text = "FrmDesignerMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewMap;
        private System.Windows.Forms.Button btnEdit;
    }
}