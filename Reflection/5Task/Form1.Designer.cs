namespace _5Task
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
            this.btnLoadAssembly = new System.Windows.Forms.Button();
            this.textBoxLoadInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadAssembly
            // 
            this.btnLoadAssembly.Location = new System.Drawing.Point(181, 2);
            this.btnLoadAssembly.Name = "btnLoadAssembly";
            this.btnLoadAssembly.Size = new System.Drawing.Size(144, 23);
            this.btnLoadAssembly.TabIndex = 0;
            this.btnLoadAssembly.Text = "Завантажити";
            this.btnLoadAssembly.UseVisualStyleBackColor = true;
            this.btnLoadAssembly.Click += new System.EventHandler(this.btnLoadAssembly_Click);
            // 
            // textBoxLoadInfo
            // 
            this.textBoxLoadInfo.Location = new System.Drawing.Point(13, 31);
            this.textBoxLoadInfo.Multiline = true;
            this.textBoxLoadInfo.Name = "textBoxLoadInfo";
            this.textBoxLoadInfo.Size = new System.Drawing.Size(716, 395);
            this.textBoxLoadInfo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Виберіть збірку (DLL або EXE):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLoadInfo);
            this.Controls.Add(this.btnLoadAssembly);
            this.Name = "Form1";
            this.Text = "Програма-рефлектор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadAssembly;
        private System.Windows.Forms.TextBox textBoxLoadInfo;
        private System.Windows.Forms.Label label1;
    }
}

